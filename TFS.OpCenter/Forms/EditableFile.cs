using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Data;

namespace TFS.OpCenter.Forms
{
    /// <summary>
    /// Encapsulates the logic of a form instance (represented by a file) and it's fields/records
    /// </summary>
    public class EditableFile : SymanticFile
    {     

        public EditableFile(Formfile formFile)
            :base(formFile)
        {
            //pre-populate all the fields, along with any existing records
            FormfieldCollection allFields = new FormfieldCollection().Where(Formfield.Columns.Formid, this.SymanticForm.Form.Id).Load();

            this.relatedFields = new List<EditableField>();
            for (int i = 0; i < allFields.Count; i++)
			{                
                Formrecord candidateRecord = this.FormFile.Formrecords().FirstOrDefault<Formrecord>(record => record.Fieldid == allFields[i].Id);
                EditableField field;
                if (candidateRecord != null)
                    field = new EditableField(candidateRecord);
                else
                    field = new EditableField(allFields[i]);
                field.FieldStoringCallback += new EventHandler<EditableFieldStoringCallbackArgs>(HandleEditableFieldStoring);
                this.relatedFields.Add(field);
			}

            /// Sort the fields in field order
            this.relatedFields = this.relatedFields.OrderBy(field => field.Metadata.FieldOrder).ToList();
        }


        /// <summary>
        /// Handles the editable field storing callback to assign the file id value.
        /// </summary>
        public void HandleEditableFieldStoring(object sender, EditableFieldStoringCallbackArgs e)
        {
            e.FileId = this.FormFile.Id;
        }

        private List<EditableField> relatedFields;

        /// <summary>
        /// The fields related to this form
        /// </summary>
        public List<EditableField> Fields
        {
            get
            {                
                return relatedFields;
            }
        }

        /// <summary>
        /// Deletes the file in this form. It is a soft delete unless desotry == true
        /// </summary>
        internal void DeleteFile(bool destory)
        {
            if (!destory)
            {
                this.FormFile.Deleted = true;
                this.FormFile.Save(Utility.GetActiveUsername());                
            }
            else
            {
                Formfile.Delete(this.FormFile.Id);
            }
            this.FormFile = null;
            this.relatedFields.Clear();
        }

        /// <summary>
        /// Stores this file an all fields
        /// </summary>
        public void Store()
        {
            foreach (EditableField field in this.Fields)
            {
                field.Store();
            }
            this.FormFile.Save(Utility.GetActiveUsername());
        }
    }
}
