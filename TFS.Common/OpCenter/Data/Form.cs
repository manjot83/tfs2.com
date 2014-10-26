using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.OpCenter.Data
{
    public partial class Form
    {
        public static Form FetchByShortName(string shortName)
        {
            FormCollection forms = new FormCollection().Where(Form.Columns.Shortname, shortName).Load();
            if (forms.Count() == 0)
                return null;
            return forms.First<Form>();
        }


        public static Form FetchByName(string formName)
        {
            FormCollection forms = new FormCollection().Where(Form.Columns.Name, formName).Load();
            if (forms.Count() == 0)
                return null;
            return forms.First<Form>();
        }

    }
}
