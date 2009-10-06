using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFS.OpCenter.Forms;

namespace TFS.Web.Forms
{
    public partial class FCIFPrintView : System.Web.UI.Page
    {
        protected ViewableFile file;

        protected void Page_Load(object sender, EventArgs e)
        {
            int fileid = 0;
            bool fileidspecified = (int.TryParse(this.Request.Params["file"], out fileid));

            if (fileidspecified)
            {
                this.file = ViewableFileCollection.GetFile(fileid);
            }
            else
            {
                throw new Exception("FCIF ID not specified");
            }

        }

        protected string TransformMarkdown(string text)
        {
            return new anrControls.Markdown().Transform(text);
        }
    }
}
