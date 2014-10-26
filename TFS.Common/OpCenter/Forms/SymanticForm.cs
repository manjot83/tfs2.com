using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Data;

namespace TFS.OpCenter.Forms
{

    /// <summary>
    /// Encapsulates the logic of a form instance (represented by a template and fields)
    /// </summary>
    public class SymanticForm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="form">The form to encapsulate</param>
        public SymanticForm(Form form)
        {
            this.Form = form;
        }        

        /// <summary>
        /// The encapsulated form
        /// </summary>
        public Form Form { get; private set; }

        
    }
}
