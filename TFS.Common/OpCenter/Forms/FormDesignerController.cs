using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Data;

namespace TFS.OpCenter.Forms
{
    public class FormDesignerController
    {

        /// <summary>
        /// The designable version of the loaded form.
        /// </summary>
        public DesignableForm DesignableForm { get; private set; }

        /// <summary>
        /// The form for this designer
        /// </summary>
        public Form Form { get; private set; }

        public FormDesignerController(int formId)
            :this(Form.FetchByID(formId))
        {

        }
        
        public FormDesignerController(Form form)
        {
            this.Form = form;
            this.DesignableForm = new DesignableForm(form);
        }

    }
}
