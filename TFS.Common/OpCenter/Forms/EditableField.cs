using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Data;

namespace TFS.OpCenter.Forms
{
    /// <summary>
    /// Encapsulates the logic of a field and it's associated record/value
    /// </summary>
    public class EditableField : SymanticField
    {

		#region Instance Variables 

        private int? workingCodeValue;
        private string workingTextValue;

		#endregion Instance Variables 

		#region Constructors 

        /// <summary>
        /// Encapsulates an existing record for this field
        /// </summary>
        /// <param name="formrecord"></param>
        public EditableField(Formrecord formrecord)
            :this(formrecord.Formfield)
        {
            this.FormRecord = formrecord;
            this.Status = FieldStatus.Unmodified;
            this.workingTextValue = this.FormRecord.Storedvalue;
            this.workingCodeValue = this.FormRecord.Codeid;
        }

        public EditableField(Formfield formfield)
            : base(formfield)
        {
            this.Status = FieldStatus.New;
        }

        public EditableField(Formfield formfield, Formrecord formrecord)
            :this(formrecord)
        {
            if (formrecord.Formfield.Id != formfield.Id)
                throw new NotSupportedException("Cannot encapsulate a record with a different field (Field IDs do not match)");
        }

		#endregion Constructors 

		#region Public Methods 

        /// <summary>
        /// Resets values back to their original values before a store.
        /// </summary>
        public void Reset()
        {
            if (this.Status == FieldStatus.New)
            {
                //don't fire events
                this.workingTextValue = null;
                this.workingCodeValue = null;
            }
            else if (this.Status == FieldStatus.Modified)
            {
                //don't fire events
                this.workingTextValue = this.FormRecord.Storedvalue;
                this.workingCodeValue = this.FormRecord.Codeid;
                this.Status = FieldStatus.Unmodified;
            }
        }

        /// <summary>
        /// Stores the working values into the a record.
        /// </summary>
        public void Store()
        {
            EditableFieldStoringCallbackArgs fieldStoringCallbackArgs = new EditableFieldStoringCallbackArgs();
            if (this.FieldStoringCallback != null)
                this.FieldStoringCallback(this, fieldStoringCallbackArgs);

            if (this.Status == FieldStatus.New)
            {
                if (!fieldStoringCallbackArgs.FileId.HasValue)
                    throw new NotSupportedException("Cannot save a new field without a file id provided by the field storing callback method");
                int fileid = fieldStoringCallbackArgs.FileId.Value;

                this.FormRecord = Formrecord.CreateNew(fileid, this.FormField.Id);
                if (this.FormRecord == null)
                    throw new NotSupportedException("Cannot store a new field without first creating the associated record");                
                this.Status = FieldStatus.Modified;
            }
            
            if (this.Status == FieldStatus.Modified)
            {
                this.FormRecord.Storedvalue = this.TextValue;
                this.FormRecord.Codeid = null; //default
                if (this.Type == FieldType.SingleOption)
                {
                    /// For single option we actually set the code value
                    this.FormRecord.Codeid = this.CodeValue;
                    if (this.CodeValue.HasValue &&
                        this.LookupCodes.Count(lookup => lookup.Id == this.CodeValue.Value) > 0)
                        this.FormRecord.Storedvalue = this.LookupCodes.Where(Formcode.Columns.Id, this.FormRecord.Codeid.Value)[0].Label;                    
                }
                this.FormRecord.Save(Utility.GetActiveUsername());
                this.Status = FieldStatus.Unmodified;
            }
        }

		#endregion Public Methods 

		#region Public Properties 

        /// <summary>
        /// Gets or sets the current code based value for the field as a nullable type
        /// </summary>
        public int? CodeValue
        {
            get
            {
                return this.workingCodeValue;
            }
            set
            {                
                if (value == null)
                    return;
                bool changed = value != this.workingCodeValue;
                if (changed)
                {
                    if (this.Status == FieldStatus.Unmodified)
                        this.Status = FieldStatus.Modified;
                    this.workingCodeValue = value;
                    this.workingTextValue = this.LookupCodes.First<Formcode>(code => code.Id == this.workingCodeValue).Label;
                }
                if (changed && this.CodeValueChanged != null)                
                    this.CodeValueChanged(this, EventArgs.Empty);
                
            }
        }
        

        /// <summary>
        /// The encapsulated Formrecord object for this field representation
        /// </summary>
        /// <remarks>
        /// This can be null if the field is considered new
        /// </remarks>
        public Formrecord FormRecord { get; private set; }

        /// <summary>
        /// Gets or sets the field status. Whether it is new, modified, or unmodified
        /// </summary>
        public FieldStatus Status { get; private set; }

        /// <summary>
        /// Gets or sets the current Text based value for the field
        /// </summary>
        public string TextValue
        {
            get
            {
                return this.workingTextValue;
            }
            set
            {
                if (value == null)
                    return;
                bool changed = value != this.workingTextValue;
                if (changed)
                {
                    if (this.Status == FieldStatus.Unmodified)
                        this.Status = FieldStatus.Modified;
                    this.workingTextValue = value;
                }
                if (changed && this.TextValueChanged != null)
                    this.TextValueChanged(this, EventArgs.Empty);
            }
        }

		#endregion Public Properties 
                /// <summary>
        /// Fires when the code value of the field is changed
        /// </summary>
        public event EventHandler CodeValueChanged;
        /// <summary>
        /// Fires when the text value of the field is changed
        /// </summary>
        public event EventHandler TextValueChanged;
        /// <summary>
        /// Fires when the field is being stored. This will be handled by some callback method which will provide information needed to store the field record.
        /// </summary>
        public event EventHandler<EditableFieldStoringCallbackArgs> FieldStoringCallback;

        
        /// <summary>
        /// Attempts to set the value for this field. If necessary it will parse as a code.
        /// </summary>
        public void SetValue(string value)
        {
            if (this.Type == FieldType.Textvalue)
            {  
                this.TextValue = value;                
                return;
            }
            if (this.Type == FieldType.SingleOption)
            {
                int parsedCode = -1;
                if (!Int32.TryParse(value, out parsedCode))
                    throw new ArgumentException("Cannot parse the given value as a code");
                this.CodeValue = parsedCode;
                return;
            }
            if (this.Type == FieldType.MultipleOption)
            {
                /// For multiple values, we need to decode the string and call the special store method for multiple values
                this.SetMultipleValues(EditableField.ParseTextForCheckboxValue(value));
                return;
            }
        }

        /// <summary>
        /// Attempts to set the values for this field. If necessary it will parse as a code. It will only work if this is a multiple option field
        /// </summa
        public void SetMultipleValues(string[] values)
        {
            if (this.Type != FieldType.MultipleOption)
            {
                throw new NotSupportedException("Cannot set multiple values when the field typ eis not multiple option");
            }            
            /// Attempt to parse each value, we can only store parseable values
            /// The last code in the list will be the one stored in the code value field
            foreach (string value in values)
            {
                int parsedCode = -1;
                if (!Int32.TryParse(value, out parsedCode))
                    throw new ArgumentException("Cannot parse the given value as a code");                
            }
            /// We don't set a code value. We only set text for this.
            this.TextValue = EditableField.CombineTextFromCheckboxValue(values);
        }



        /// <summary>
        /// Helper method to parse the "encoded" string value to extract values for multiple options
        /// </summary>
        /// <remarks>
        /// Each value is seperated by whitespace and the vertical line character
        /// </remarks>
        public static string[] ParseTextForCheckboxValue(string value)
        {
            if (string.IsNullOrEmpty(value))
                return new string[0];
            string[] values = value.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = values[i].Trim();
            }
            return values;
        }

        /// <summary>
        /// Combines values from a multiple option list into a single "encoded" string value
        /// </summary>
        /// <remarks>
        /// Each value is seperated by whitespace and the vertical line character
        /// </remarks>
        internal static string CombineTextFromCheckboxValue(string[] values)
        {
            string encodedValue = string.Empty;
            for (int i = 0; i < values.Length; i++)
            {
                encodedValue += values[i];
                if (i != values.Length - 1)
                {
                    encodedValue += " | ";
                }
            }
            return encodedValue;
        }
    }
}