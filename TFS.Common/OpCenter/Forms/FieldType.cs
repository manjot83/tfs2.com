using System;

namespace TFS.OpCenter.Forms
{

    /// <summary>
    /// The type of field, generally used for UI purposes
    /// </summary>
    public enum FieldType
    {
        /// <summary>
        /// A single text value, without codes, usually displayed in a textbox
        /// </summary>
        Textvalue,
        /// <summary>
        /// A single value derived from a lookup code
        /// </summary>
        SingleOption,
        /// <summary>
        /// One or more values derived from lookup codes
        /// </summary>
        MultipleOption,
    }
}
