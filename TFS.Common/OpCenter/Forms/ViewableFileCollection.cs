using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Data;
using System.Data;

namespace TFS.OpCenter.Forms
{
    public class ViewableFileCollection : List<ViewableFile>
    {

        public SymanticForm EncapsulatedForm { get; private set; }

        public ViewableFileCollection(SymanticForm form)
        {
            this.EncapsulatedForm = form;

            //pre-populate all the fields, along with any existing records
            FormfieldCollection allFields = new FormfieldCollection().Where(Formfield.Columns.Formid, this.EncapsulatedForm.Form.Id).Load();
            ///get the related fields
            this.relatedFields = new List<SymanticField>();
            for (int i = 0; i < allFields.Count; i++)
            {                
                EditableField field = new EditableField(allFields[i]);
                this.relatedFields.Add(field);
            }
            /// Sort the fields in field order
            this.relatedFields = this.relatedFields.OrderBy(field => field.Metadata.FieldOrder).ToList();
        }

        public ViewableFileCollection(Form form)
            :this(new SymanticForm(form))
        {

        }

        public ViewableFileCollection(int formId)
            :this(Form.FetchByID(formId))
        {

        }

        /// <summary>
        /// The fields related to this form
        /// </summary>
        private List<SymanticField> relatedFields;

        /// <summary>
        /// The sorted fields related to this form
        /// </summary>
        public List<SymanticField> Fields
        {
            get
            {
                return relatedFields;
            }
        }

        /// <summary>
        /// Loads the entire collection of files
        /// </summary>
        public ViewableFileCollection LoadAll()
        {
            this.Clear();
            foreach (Formfile formFile in this.EncapsulatedForm.Form.Formfiles())
            {
                ViewableFile file = new ViewableFile(formFile);
                this.Add(file);
            }
            return this;
        }

        /// <summary>
        /// Loads a specific File. Returns null if the file doesn't exist
        /// </summary>
        public static ViewableFile GetFile(int id)
        {
            Formfile formFile = Formfile.FetchByID(id);
            ViewableFile file = null;
            if (formFile != null)
            {
                file = new ViewableFile(formFile);
            }
            else
            {
                throw new Exception("File doesn't exist");
            }
            return file;
        }

        /// <summary>
        /// Converts this collection into a datatable that is bindable to various databinding controls. This is a read-only memory table.
        /// </summary>
        public DataTable ToDataTable()
        {
            DataTable readonlyDataTable = new DataTable();
            /// First we need to encapsulate the various columns for the data table
            /// Start with the various columns we need
            readonlyDataTable.Columns.Add("FileKey", typeof(string));
            readonlyDataTable.Columns.Add("FormId", typeof(string));
            readonlyDataTable.Columns.Add("FileId", typeof(string));
            /// audit columns
            readonlyDataTable.Columns.Add("createdon", typeof(DateTime));
            readonlyDataTable.Columns.Add("creadtedby", typeof(string));
            readonlyDataTable.Columns.Add("modifiedon", typeof(string));
            readonlyDataTable.Columns.Add("modifiedby", typeof(string));
            foreach (SymanticField field in this.Fields)
            {
                readonlyDataTable.Columns.Add(field.FormField.Name, typeof(string));
            }            
            /// Now we need to encapsulate all of the loaded files, getting the text value for column            
            foreach (ViewableFile file in this)
            {
                DataRow row = readonlyDataTable.NewRow();
                /// Start with FormId and FileId fields which we need
                row["FileKey"] = file.FileKeyValue;
                row["FormId"] = file.FormId;
                row["FileId"] = file.FileId;
                /// audit columns
                if (file.FormFile.Createdon.HasValue)
                    row["createdon"] = file.FormFile.Createdon.Value;
                else
                    row["createdon"] = string.Empty;
                row["creadtedby"] = Utility.ResolveDisplayName(file.FormFile.Createdby);
                if (file.FormFile.Modifiedon.HasValue)
                    row["modifiedon"] = file.FormFile.Modifiedon.Value.ToShortDateString();
                else
                    row["modifiedon"] = string.Empty;
                row["modifiedby"] = Utility.ResolveDisplayName(file.FormFile.Modifiedby);
                foreach (SymanticField field in this.Fields)
                {
                    row[field.FormField.Name] = file.GetStoredValue(field.FormField.Name);
                }
                readonlyDataTable.Rows.Add(row);
            }
            return readonlyDataTable;
        }

        /// <summary>
        /// Sorts each file in this collection and returns the sorted collection
        /// </summary>
        public ViewableFileCollection OrderByAsc(string fieldName)
        {
            var sortedFiles = this.OrderBy(file => file.GetStoredValue(fieldName));
            ViewableFileCollection sortedCollection = new ViewableFileCollection(this.EncapsulatedForm);
            sortedCollection.Clear();
            sortedCollection.AddRange(sortedFiles);
            return sortedCollection;
        }

        /// <summary>
        /// Sorts each file in descending order in this collection and returns the sorted collection
        /// </summary>
        public ViewableFileCollection OrderByDesc(string fieldName)
        {
            var sortedFiles = this.OrderByDescending(file => file.GetStoredValue(fieldName));
            ViewableFileCollection sortedCollection = new ViewableFileCollection(this.EncapsulatedForm);
            sortedCollection.Clear();
            sortedCollection.AddRange(sortedFiles);
            return sortedCollection;
        }

        /// <summary>
        /// Gets this as a list.
        /// </summary>
        public List<ViewableFile> GetList()
        {
            return this;
        }

    }
}
