using System;

namespace TFS.OpCenter.Forms
{

    /// <summary>
    /// Representation of the status of the field
    /// </summary>
    public enum FieldStatus
    {
        /// <summary>
        /// A new record which is to be added
        /// </summary>
        New,
        /// <summary>
        /// An existing record which has been modified
        /// </summary>
        Modified,
        /// <summary>
        /// An existing record which has not been modified
        /// </summary>
        Unmodified
    }
}
