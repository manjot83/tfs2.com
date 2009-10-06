using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Data;

namespace TFS.OpCenter.Forms
{
    public class DesignableForm : SymanticForm
    {

        public DesignableForm(Form form)
            :base(form)
        {
            this.ReloadFields();

            this.workingName = this.Form.Name;
        }

        /// <summary>
        /// Reloads the field records
        /// </summary>
        private void ReloadFields()
        {
            /// pre-populate all the fields, along with any existing records
            FormfieldCollection allFields = new FormfieldCollection().Where(Formfield.Columns.Formid, this.Form.Id).Load();

            if (this.relatedFields == null)
                this.relatedFields = new List<DesignableField>();
            foreach (DesignableField field in this.relatedFields)
                field.FieldDeleted -= this.HandleFieldDeleted; //make sure it's unhooked if it's there
            this.relatedFields.Clear();
            for (int i = 0; i < allFields.Count; i++)
            {
                DesignableField field = new DesignableField(allFields[i], this);
                this.relatedFields.Add(field);
                field.FieldDeleted += new EventHandler(HandleFieldDeleted);
            }            

            /// First sort the fields based on the information we have
            this.SortFields();
            /// Now reset their FieldOrder ID if it's not right
            for (int i = 0; i < this.relatedFields.Count; i++)
            {
                if (this.relatedFields[i].Metadata.FieldOrder != i)
                {
                    this.relatedFields[i].Metadata.FieldOrder = i;
                    this.relatedFields[i].Store();
                }
            }
        }

        /// <summary>
        /// Sorts the fields in field order
        /// </summary>
        public void SortFields()
        {
            this.relatedFields = this.relatedFields.OrderBy(field => field.Metadata.FieldOrder).ToList();
        }

        /// <summary>
        /// Unhooks and removes this field from the designer
        /// </summary>
        private void HandleFieldDeleted(object sender, EventArgs e)
        {
            DesignableField field = (DesignableField)sender;
            field.FieldDeleted -= this.HandleFieldDeleted;
            this.relatedFields.Remove(field);
        }

        private List<DesignableField> relatedFields;

        /// <summary>
        /// All related fields for the designer
        /// </summary>
        public List<DesignableField> RelatedFields
        {
            get
            {
                return this.relatedFields;
            }
        }

        /// <summary>
        /// Gets a specific field by it's database unique ID
        /// </summary>
        public DesignableField GetFieldByID(int id)
        {
            foreach (DesignableField field in this.RelatedFields)
            {
                if (field.FormField.Id == id)
                    return field;
            }
            return null;
        }

        /// <summary>
        /// Adds a new field to the form, and returns it's designer.
        /// </summary>
        public DesignableField AddField(string name)
        {
            Formfield field = new Formfield();
            field.Name = name;
            field.Form = this.Form;
            /// The field does not get saved until we store the form            
            DesignableField designer = new DesignableField(field, this);
            designer.FieldDeleted +=new EventHandler(HandleFieldDeleted);
            /// Set the default for the field ordering
            designer.Metadata.FieldOrder = this.relatedFields.Count;
            this.relatedFields.Add(designer);
            return designer;
        }

        /// <summary>
        /// Resets this form back to the database values
        /// </summary>
        public void Reset()
        {
            this.ReloadFields();
            ///Reset the fields
            foreach (DesignableField field in this.RelatedFields)
                field.Reset();
            this.workingName = null;
            this.workingShortName = null;
            this.workingTFSFNumber = null;
            this.workingCreatedDate = null;
        }

        /// <summary>
        /// Saves this form and it's changes
        /// </summary>
        public void Store()
        {
            ///Store the fields
            foreach (DesignableField field in this.RelatedFields)
                field.Store();

            if (!string.IsNullOrEmpty(this.workingName) && !this.Form.Name.Equals(this.workingName))
                this.Form.Name = this.Name;
            if (!string.IsNullOrEmpty(this.workingShortName) && !this.Form.Shortname.Equals(this.workingShortName))
                this.Form.Shortname = this.ShortName;
            if (!string.IsNullOrEmpty(this.workingTFSFNumber) && !this.Form.Name.Equals(this.workingTFSFNumber))
                this.Form.Tfsfnumber = this.TFSFNumber;
            if (this.workingCreatedDate != null && this.Form.Createdon != this.workingCreatedDate)
                this.Form.Createdon = this.CreatedDate;
            this.Form.Save(Utility.GetActiveUsername());
        }

        private string workingName;

        /// <summary>
        /// Gets or sets the name of the form
        /// </summary>
        public string Name
        {
            get
            {
                if (workingName == null)
                    workingName = this.Form.Name;
                return this.workingName;
            }
            set
            {
                this.workingName = value;
            }
        }

        private string workingShortName;
        private string workingTFSFNumber;
        private DateTime? workingCreatedDate;

        /// <summary>
        /// Gets or sets the short name of the form
        /// </summary>
        public string ShortName
        {
            get
            {
                if (workingShortName == null)
                    workingShortName = this.Form.Shortname;
                return this.workingShortName;
            }
            set
            {
                this.workingShortName = value;
            }
        }

        /// <summary>
        /// Gets or sets the TFSF Number of the form
        /// </summary>
        public string TFSFNumber
        {
            get
            {
                if (workingTFSFNumber == null)
                    workingTFSFNumber = this.Form.Tfsfnumber;
                return this.workingTFSFNumber;
            }
            set
            {
                this.workingTFSFNumber = value;
            }
        }

        /// <summary>
        /// Gets or sets the created date of the form
        /// </summary>
        public DateTime CreatedDate
        {
            get
            {
                if (workingCreatedDate == null)
                    workingCreatedDate = this.Form.Createdon;
                return this.workingCreatedDate.Value;
            }
            set
            {
                this.workingCreatedDate = value;
            }
        }

        /// <summary>
        /// Attempts to swap the ordering of the selected field with one that is higher.
        /// </summary>
        internal void SwapOrderingUp(DesignableField lowerField)
        {
            int lowerFieldOrder = lowerField.Metadata.FieldOrder;
            DesignableField higherField = null;
            for (int i = 0; i < this.RelatedFields.Count; i++)
            {
                if (this.RelatedFields[i] == lowerField)
                {
                    /// We have found our field. If we're not the first item in the list, then the proceeding one should be the "upper field"
                    if (i > 0)
                        higherField = this.RelatedFields[i - 1];
                    break;
                }
            }
            if (higherField != null)
            {
                int higherFieldOrder = higherField.Metadata.FieldOrder;
                ///Do the swap and save
                higherField.Metadata.FieldOrder = lowerFieldOrder;
                lowerField.Metadata.FieldOrder = higherFieldOrder;
                higherField.Store();
                lowerField.Store();
                this.SortFields();
            }
        }

        /// <summary>
        /// Attempts to swap the ordering of the selected field with one that is lower.
        /// </summary>
        internal void SwapOrderingDown(DesignableField higherField)
        {
            int higherFieldOrder = higherField.Metadata.FieldOrder;
            DesignableField lowerField = null;
            for (int i = 0; i < this.RelatedFields.Count; i++)
            {
                if (this.RelatedFields[i] == higherField)
                {
                    /// We have found our field. If we're not the last item in the list, then the proceeding one should be the "upper field"
                    if (i < this.RelatedFields.Count-1)
                        lowerField = this.RelatedFields[i + 1];
                    break;
                }
            }
            if (lowerField != null)
            {
                int lowerFieldOrder = lowerField.Metadata.FieldOrder;
                ///Do the swap and save
                higherField.Metadata.FieldOrder = lowerFieldOrder;
                lowerField.Metadata.FieldOrder = higherFieldOrder;
                higherField.Store();
                lowerField.Store();
                this.SortFields();
            }
        }

        /// <summary>
        /// Sets a specific field as the keyfield
        /// </summary>
        internal void SetKeyField(DesignableField designableField)
        {
            this.Form.Keyfieldid = designableField.FormField.Id;            
        }
    }
}
