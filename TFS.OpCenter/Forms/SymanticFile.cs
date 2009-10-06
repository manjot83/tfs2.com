using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Data;

namespace TFS.OpCenter.Forms
{
    /// <summary>
    /// Encapsulates the logic of a form instance (represented by a file) and it's fields/records
    /// </summary>
    public class SymanticFile
    {

        /// <summary>
        /// The form this file belongs too
        /// </summary>
        public SymanticForm SymanticForm { get; protected set; }

        public Formfile FormFile { get; protected set; }

        public SymanticFile(Formfile formFile, SymanticForm form)
        {
            this.SymanticForm = form;
            this.FormFile = formFile;
        }

        public SymanticFile(Formfile formFile)
            : this(formFile, new SymanticForm(formFile.Form))
        {

        }

    }
}
