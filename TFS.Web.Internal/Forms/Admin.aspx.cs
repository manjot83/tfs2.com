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
using TFS.OpCenter.Data;

namespace TFS.Web.Forms
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void HandleAddFormButtonClick(object sender, EventArgs e)
        {
            //string formName = this.NewFormNameTextbox.Text;
            //if (string.IsNullOrEmpty(formName))
            //    return;
            //string formShortname = this.NewFormShortNameTextbox.Text;
            //string formTFSF = this.NewFormTFSFTextbox.Text;
            //string formRemarks = this.NewFormRemarksTexbox.Text;
            //TFS.OpCenter.Data.Form.Insert(formName, formShortname, formTFSF, formRemarks, false, null, null, null, null);
            //this.NewFormNameTextbox.Text = string.Empty;
            //this.NewFormShortNameTextbox.Text = string.Empty;
            //this.NewFormTFSFTextbox.Text = string.Empty;
            //this.NewFormRemarksTexbox.Text = string.Empty;
            //this.FormsRepeater.DataBind();
        }
    }
}
