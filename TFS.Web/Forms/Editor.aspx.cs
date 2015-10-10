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
using Elmah.Assertions;
using TFS.OpCenter.Forms.UI;
using TFS.OpCenter.Data;

namespace TFS.Web.Forms
{
    public partial class Editor : System.Web.UI.Page
    {

        protected FormFileController controller;
        private string fileType = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            fileType = this.Request.Params["filetype"];

            int fileid = 0;
            bool newfile = !(int.TryParse(this.Request.Params["file"], out fileid));

            int formid = int.Parse(this.Request.Params["form"]);

            this.controller = new FormFileController(formid);

            if (newfile)
            {
                Formfile file = this.controller.CreateFile();
                // redirect to the correct page
                Response.Redirect(string.Format("Editor.aspx?file={0}&form={1}&fileType={2}", file.Id, formid, fileType));
            }
            else
                this.controller.LoadFile(fileid);

            if (!this.IsPostBack)
                this.EditForm.EditableForm = this.controller.EditableForm;
        }

        protected void OnSaveButtonPressed(object sender, EventArgs e)
        {
            editorRedirectHelper();
        }

        protected void OnDeleteButtonPressed(object sender, EventArgs e)
        {
            editorRedirectHelper();
        }

        protected void OnCancelButtonPressed(object sender, EventArgs e)
        {
            editorRedirectHelper();
        }

        private void editorRedirectHelper()
        {
            if (string.IsNullOrEmpty(fileType))
                return;

            var url = string.Empty;

            switch (fileType.ToLower())
            {
                case "srf":
                    url = "~/Forms/SRFListing.aspx";
                    break;
                case "fcif":
                    url = "~/Forms/FCIFListing.aspx";
                    break;

            }

            if (!string.IsNullOrEmpty(url))
                Response.Redirect(url);
        }
    }
}
