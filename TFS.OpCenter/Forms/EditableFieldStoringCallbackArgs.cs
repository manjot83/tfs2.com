using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.OpCenter.Forms
{
    public class EditableFieldStoringCallbackArgs : EventArgs
    {
        /// <summary>
        /// ID of the File to related the field record to. This is set by the callback method.
        /// </summary>
        public int? FileId { get; set; }
    }
}
