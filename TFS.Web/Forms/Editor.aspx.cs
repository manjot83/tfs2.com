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
using TFS.OpCenter.Forms.UI;
using TFS.OpCenter.Data;

namespace TFS.Web.Forms
{
    public partial class Editor : System.Web.UI.Page
    {

        protected FormFileController controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            int fileid = 0;
            bool newfile = !(int.TryParse(this.Request.Params["file"], out fileid));

            int formid = int.Parse(this.Request.Params["form"]);            

            this.controller = new FormFileController(formid);

            if (newfile)
            {
                Formfile file = this.controller.CreateFile();
                // redirect to the correct page
                Response.Redirect(string.Format("Editor.aspx?file={0}&form={1}", file.Id, formid));
            }
            else
                this.controller.LoadFile(fileid);

            if (!this.IsPostBack)
                this.EditForm.EditableForm = this.controller.EditableForm;
        }
    }
}
