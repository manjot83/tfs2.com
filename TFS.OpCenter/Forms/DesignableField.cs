using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Data;
using TFS.OpCenter.Serialization;

namespace TFS.OpCenter.Forms
{
    public class DesignableField : SymanticField
    {

        private DesignableForm parentForm;

        public DesignableField(Formfield formfield, DesignableForm parentForm)
            : base(formfield)
        {
            this.parentForm = parentForm;
        }

        private string workingName;

        /// <summary>
        /// Gets or sets the name of the field
        /// </summary>
        public string Name
        {
            get
            {
                if (this.workingName == null)
                    this.workingName = this.FormField.Name;
                return this.workingName;
            }
            set
            {
                this.workingName = value;
            }
        }


        public void Reset()
        {
            this.workingName = this.FormField.Name;
        }

        /// <summary>
        /// Stores changes made to this field.
        /// </summary>
        public void Store()
        {
            if (!string.IsNullOrEmpty(this.workingName) && !this.FormField.Name.Equals(this.workingName))
                this.FormField.Name = this.workingName;

            ///Serialize the metadata property dictionary if it was changed
            ///if (this.MetadataChanged)
            this.FormField.Metadata = Serialization.Serializer.ConvertToXml<SerializableDictionary<string, string>>(this.Metadata.PropertyDictionary);

            this.FormField.Save(Utility.GetActiveUsername());
        }


        /// <summary>
        /// Gets or sets the field Metadata.
        /// </summary>
        /// <value>The field Metadata</value>
        public new FieldMetadata Metadata
        {
            get
            {
                return base.Metadata;
            }
            internal set
            {
                this.cachedMetaData = value;
            }
        }


        /// <summary>
        /// Adds a lookup code to this field. 
        /// </summary>
        /// <param name="label">A unique label for this code.</param>
        public void AddLookupCode(string label)
        {
            ///If this label is already used, then don't add it
            if (this.LookupCodes.Where<Formcode>(code => code.Label.Equals(label, StringComparison.InvariantCultureIgnoreCase)).Count() > 0)
                return;

            Formcode newCode = new Formcode();
            newCode.Formfield = this.FormField;
            newCode.Label = label;
            newCode.Save(Utility.GetActiveUsername());
            this.LookupCodes.Add(newCode);
        }

        /// <summary>
        /// Deletes a lookup code for this field. It is marked deleted, records that reference it will continue to hold their reference to the old code.
        /// </summary>
        /// <param name="code">The code to remove.</param>
        public void RemoveLookCode(Formcode code)
        {
            code.Deleted = true;
            code.Save(Utility.GetActiveUsername());
            this.ReloadLookupCodes();
        }

        /// <summary>
        /// Deletes the field (and all codes, and all records) from the form
        /// </summary>
        public void Delete()
        {
            foreach (Formrecord record in this.FormField.Formrecords())
                Formrecord.Delete(record.Id);
            foreach (Formcode code in this.FormField.Formcodes())
                Formcode.Delete(code.Id);
            Formfield.Delete(this.FormField.Id);
            if (this.FieldDeleted != null)
                this.FieldDeleted(this, EventArgs.Empty);
        }

        /// <summary>
        /// Fires when the field has been deleted
        /// </summary>
        public event EventHandler FieldDeleted;

        /// <summary>
        /// Attempts to move this field up one in the ordering. If it cannot, then nothing happens.
        /// </summary>
        public void MoveUp()
        {
            /// The parent form is responsible for the logic
            this.parentForm.SwapOrderingUp(this);
        }

        /// <summary>
        /// Attempts to move this field down one in the ordering. If it cannot, then nothing happens.
        /// </summary>
        public void MoveDown()
        {
            /// The parent form is responsible for the logic
            this.parentForm.SwapOrderingDown(this);
        }

        /// <summary>
        /// This field is the key field for the form it belongs to.
        /// </summary>
        /// <returns></returns>
        public bool IsKeyField()
        {
            if (this.parentForm.Form.Keyfieldid.HasValue == false)
                return false;
            if (this.FormField.Id == this.parentForm.Form.Keyfieldid.Value)
                return true;
            return false;
        }

        /// <summary>
        /// Makes this field the key field for the form it belongs to.
        /// </summary>
        public void SetAsKeyField()
        {
            this.parentForm.SetKeyField(this);
            this.parentForm.Store();
        }

    }
}
