using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.OpCenter.Data;

namespace TFS.OpCenter.Forms
{

    public class ViewableField : SymanticField
    {


        private ViewableFile viewableFile;
        private Formrecord formrecord;       

        public ViewableField(Formfield formfield, ViewableFile viewableFile)
            : base(formfield)
        {
            this.viewableFile = viewableFile;
        }

        public string CurrentValue
        {
            get
            {
                return this.viewableFile.GetStoredValue(this.FormField.Name);
            }
        }


    }
}