using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Data;

namespace TFS.OpCenter.Forms
{
    public class ViewableFile : SymanticFile
    {

        #region Generics Support

        public ViewableFile()
            :base(null, null)
        {

        }

        internal void EncapsulateFormFile(Formfile encapsulatedFormFile)
        {
            this.FormFile = encapsulatedFormFile;
            this.SymanticForm = new SymanticForm(encapsulatedFormFile.Form);
        }

        #endregion

        public ViewableFile(Formfile encapsulatedFormFile)
            :base(encapsulatedFormFile)
        {
            
        }

        private List<ViewableField> fields;

        /// <summary>
        /// Collection of fields related to this file with values
        /// </summary>
        public List<ViewableField> Fields
        {
            get
            {
                if (this.fields == null)
                {
                    this.fields = new List<ViewableField>();
                    FormfieldCollection allFields = new FormfieldCollection().Where(Formfield.Columns.Formid, this.SymanticForm.Form.Id).Load();
                    for (int i = 0; i < allFields.Count; i++)
                    {                        
                        ViewableField field = new ViewableField(allFields[i], this);
                        this.fields.Add(field);
                    }

                    /// Sort the fields in field order
                    this.fields = this.fields.OrderBy(field => field.Metadata.FieldOrder).ToList();
                }
                return this.fields;
            }
        }

        /// <summary>
        /// The FileId for this File
        /// </summary>
        public int FileId
        {
            get
            {
                return this.FormFile.Id;
            }
        }

        /// <summary>
        /// The FormId for this File
        /// </summary>
        public int FormId
        {
            get
            {
                return this.SymanticForm.Form.Id;
            }
        }

        /// <summary>
        /// Gets the value of the Key Field for this file. If the form doesn't specify a key, string.Empty is returned.
        /// </summary>
        public string FileKeyValue
        {
            get
            {
                if (this.SymanticForm.Form.Keyfieldid.HasValue)
                {
                    int keyfieldid = this.SymanticForm.Form.Keyfieldid.Value;
                    Formfield keyfield = Formfield.FetchByID(keyfieldid);
                    return this.GetStoredValue(keyfield.Name);
                }
                return string.Empty;
            }
        }

        /// <summary>
        /// The named field exists for the form this file belongs to.
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        protected internal bool FieldExists(string fieldName)
        {
            return !(this.SymanticForm.Form.Formfields().Where<Formfield>(field => field.Name.Equals(fieldName, StringComparison.InvariantCultureIgnoreCase)).Count() == 0);
        }

        /// <summary>
        /// Gets a list of Formrecord objects for a particular field
        /// </summary>
        protected internal List<Formrecord> GetFieldRecords(string fieldName)
        {
            return this.FormFile.Formrecords().Where<Formrecord>(record => record.Formfield.Name.Equals(fieldName, StringComparison.InvariantCultureIgnoreCase)).ToList<Formrecord>();
        }

        /// <summary>
        /// Gets the stored value for a particular named field in the form
        /// </summary>
        public string GetStoredValue(string fieldName)
        {
            if (!this.FieldExists(fieldName))
                throw new Exception("Could not find form field of name: " + fieldName);

            var records = this.GetFieldRecords(fieldName);
            if (records.Count() == 0)
                return string.Empty;
            else
                return records.First().Storedvalue;
        }

        /// <summary>
        /// Gets the stored text (big text) for a particular named field in the form
        /// </summary>
        public int? GetCodeValue(string fieldName)
        {
            if (!this.FieldExists(fieldName))
                throw new Exception("Could not find form field of name: " + fieldName);

            var records = this.GetFieldRecords(fieldName);
            if (records.Count() == 0)
                return null;
            else
            {
                return records.First().Codeid;
            }
        }


        /// <summary>
        /// Attempts to get the stored value for a particular named field as a DateTime
        /// </summary>
        public DateTime GetStoredValueAsDateTime(string fieldName)
        {
            DateTime date = DateTime.MinValue;
            DateTime.TryParse(this.GetStoredValue(fieldName), out date);
            return date;
        }
            
    }
}
