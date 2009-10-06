using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using TFS.OpCenter.Forms;

namespace TFS.Web.Forms
{
    public partial class FileView : System.Web.UI.Page
    {
        protected ViewableFile file;

        protected void Page_Load(object sender, EventArgs e)
        {
            int fileid = 0;
            bool fileidspecified = (int.TryParse(this.Request.Params["file"], out fileid));

            if (fileidspecified)
            {
                this.file = ViewableFileCollection.GetFile(fileid);

                this.EditLink.NavigateUrl = string.Format("Editor.aspx?file={0}&form={1}", fileid, this.file.FormId);
                this.PreviousLink.Visible = false;
                this.NextLink.Visible = false;
            }
            else
            {
                throw new Exception("File ID not specified");
            }
        }


        protected string TransformMarkdown(string text)
        {
            return new anrControls.Markdown().Transform(text);
        }
    }
}
