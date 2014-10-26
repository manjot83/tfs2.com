using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Serialization;

namespace TFS.OpCenter.Forms
{

    /// <summary>
    /// The field metadata is used to store values used for validation and UI
    /// </summary>
    /// <remarks>
    /// Internally it stores string values in Key/Value pairs. These are serialized to XML and stored in SQL server
    /// </remarks>
    public class FieldMetadata
    {

        private SerializableDictionary<string, string> propertyDictionary;

        /// <summary>
        /// The property dictionary containing all mete data fields
        /// </summary>
        internal SerializableDictionary<string, string> PropertyDictionary
        {
            get
            {
                return this.propertyDictionary;
            }
        }

        public FieldMetadata()
        {
            this.propertyDictionary = new SerializableDictionary<string, string>();            
        }

        /// <summary>
        /// Initialize the class with a given property dictionary.
        /// </summary>
        /// <param name="propertyDictionary"></param>
        internal FieldMetadata(SerializableDictionary<string, string> propertyDictionary)
        {
            this.propertyDictionary = propertyDictionary;
        }

        /// <summary>
        /// Attempts to retrieve a property. If the value does not exist then the default value is used.
        /// </summary>
        private string GetProperty(string propertyKey, string defaultValue)
        {
            if (!this.PropertyDictionary.ContainsKey(propertyKey))
            {
                ///Set the default
                this.PropertyDictionary[propertyKey] = defaultValue;
            }
            return this.PropertyDictionary[propertyKey];
        }

        /// <summary>
        /// Attempts to retrieve a property. If the value does not exist then the empty string default is used.
        /// </summary>
        private string GetProperty(string propertyKey)
        {
            return this.GetProperty(propertyKey, string.Empty);
        }

        /// <summary>
        /// Sets a property value given a key.
        /// </summary>
        /// <param name="propertykey"></param>
        /// <param name="value"></param>
        private void SetProperty(string propertykey, string value)
        {
            this.PropertyDictionary[propertykey] = value;
        }

        /// <summary>
        /// Property key for ControlType property.
        /// </summary>
        /// <remarks>
        /// Do not change this property key. It will break compatibility
        /// </remarks>
        public const string ControlTypePropertyKey = "CONTROLTYPE";

        /// <summary>
        /// Property key for ValidationType property.
        /// </summary>
        /// <remarks>
        /// Do not change this property key. It will break compatibility
        /// </remarks>
        public const string ValidationTypePropertyKey = "VALIDATIONTYPE";

        /// <summary>
        /// Property key for FieldOrder property.
        /// </summary>
        /// <remarks>
        /// Do not change this property key. It will break compatibility
        /// </remarks>
        public const string FieldOrderPropertyKey = "FIELDORDER";

        /// <summary>
        /// The type of control to use for input rendering
        /// </summary>
        /// <remarks>
        /// Acceptable values are:
        /// - Textbox
        /// - Textarea
        /// - DatePicker
        /// - Checkbox
        /// - RichTextarea
        /// - Dropdownbox
        /// </remarks>
        public FieldControlType ControlType
        {
            get
            {
                return this.GetControlType();
            }
            set
            {
                this.SetProperty(ControlTypePropertyKey, value.ToString());
            }
        }

        /// <summary>
        /// The type of the validator for this field
        /// </summary>
        public string ValidationType
        {
            get
            {
                return this.GetProperty(ValidationTypePropertyKey);
            }
            set
            {
                this.SetProperty(ValidationTypePropertyKey, value);
            }
        }

        /// <summary>
        /// This is used to sort the fields in a single numerical order.
        /// </summary>
        public int FieldOrder
        {
            get
            {
                int order = -1;
                Int32.TryParse(this.GetProperty(FieldOrderPropertyKey, order.ToString()), out order);
                return order;
            }
            set
            {
                this.SetProperty(FieldOrderPropertyKey, value.ToString());
            }
        }
        
        /// <summary>
        /// Private helper class for the control type property
        /// </summary>
        /// <returns></returns>
        private FieldControlType GetControlType()
        {            
            string value = this.GetProperty(ControlTypePropertyKey, "Textbox");

            if (value.Equals("Textbox", StringComparison.InvariantCultureIgnoreCase))
            {
                return FieldControlType.Textbox;
            }
            else if (value.Equals("Textarea", StringComparison.InvariantCultureIgnoreCase))
            {
                return FieldControlType.Textarea;
            }
            else if (value.Equals("DatePicker", StringComparison.InvariantCultureIgnoreCase))
            {
                return FieldControlType.DatePicker;
            }
            else if (value.Equals("Checkbox", StringComparison.InvariantCultureIgnoreCase))
            {
                return FieldControlType.Checkbox;
            }
            else if (value.Equals("RichTextarea", StringComparison.InvariantCultureIgnoreCase))
            {
                return FieldControlType.RichTextarea;
            }
            else if (value.Equals("Dropdownbox", StringComparison.InvariantCultureIgnoreCase))
            {
                return FieldControlType.Dropdownbox;
            }
            return FieldControlType.Unknown;
        }
    }
}
