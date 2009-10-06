using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Data;
using TFS.OpCenter.Serialization;

namespace TFS.OpCenter.Forms
{
    public class SymanticField
    {

		#region Instance Variables 

        private FormcodeCollection lookupCodes;

		#endregion Instance Variables 

		#region Constructors 

        /// <summary>
        /// Encapsulates a field into this form
        /// </summary>
        /// <param name="formfield"></param>
        public SymanticField(Formfield formfield)
        {
            this.FormField = formfield;
        }

		#endregion Constructors 

		#region Public Properties 

        /// <summary>
        /// The encapsulated FormField object for this field representation
        /// </summary>
        /// <remarks>
        /// This should not be null.
        /// </remarks>
        public Formfield FormField { get; private set; }

        /// <summary>
        /// The type of the Field, usually for determining how to get and store the values
        /// </summary>
        /// <remarks>
        /// This is derived by examining the field definition.
        /// </remarks>
        public FieldType Type
        {
            get
            {
                /// It is an option if we have codes available for the field
                /// Otherwise it is a simple text value
                if (this.LookupCodes.Count > 0)
                {
                    /// At this point, we don't really know if it's going to be multiple values. We
                    /// can look at the field metedata. If it's a checkbox then it will be multiple values.
                    /// In the future this should be part of the general field definition and not determined on the
                    /// metadata.
                    if (this.Metadata.ControlType == FieldControlType.Checkbox)
                        return FieldType.MultipleOption;
                    else
                        return FieldType.SingleOption;
                }
                else
                {
                    return FieldType.Textvalue;
                }
            }
        }

        protected FieldMetadata cachedMetaData;

        /// <summary>
        /// Metadata for this field. Contains rendering and validation information.
        /// </summary>
        public FieldMetadata Metadata
        {
            get
            {
                if (this.cachedMetaData == null)
                {
                    if (string.IsNullOrEmpty(this.FormField.Metadata))
                        this.cachedMetaData = new FieldMetadata();
                    else
                    {
                        /// Attempt to deserialize the dictionary
                        SerializableDictionary<string, string> propertyDictionary = Serialization.Serializer.ConvertFromXml<SerializableDictionary<string, string>>(this.FormField.Metadata);
                        if (propertyDictionary != null)
                            this.cachedMetaData = new FieldMetadata(propertyDictionary);
                        else
                            this.cachedMetaData = new FieldMetadata();                        
                    }
                }
                return this.cachedMetaData;
            }
        }

		#endregion Public Properties 

		#region Internal Properties 

        /// <summary>
        /// Lookup codes for the form field
        /// </summary>
        public FormcodeCollection LookupCodes
        {
            get
            {
                if (lookupCodes == null)
                    lookupCodes = this.FormField.Formcodes();
                return lookupCodes;
            }
        }

        /// <summary>
        /// Reloads the cached lookup codes. Returns the number of codes.
        /// </summary>
        /// <returns></returns>
        protected int ReloadLookupCodes()
        {
            this.lookupCodes = null;
            return this.LookupCodes.Count;
        }

		#endregion Internal Properties 

    }
}
