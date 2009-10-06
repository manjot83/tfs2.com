using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Data;

namespace TFS.OpCenter.Forms
{

    public class FormController
    {

        public FormController(string shortName)
            : this(Form.FetchByShortName(shortName))
        {

        }

        public FormController(int formId)
            :this(Form.FetchByID(formId))
        {

        }

        
        public FormController(Form form)
        {
            this.Form = form;
        }


        /// <summary>
        /// The Form from which files will be created and loaded.
        /// </summary>
        public Form Form { get; private set; }

        /// <summary>
        /// The ID of the form.
        /// </summary>
        public int FormId
        {
            get
            {
                return this.Form.Id;
            }
        }

    }
}
