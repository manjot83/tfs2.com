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



namespace TFS.Web.Forms
{
    public partial class SRFListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ///Apply default sorting for the list view
                this.FilesListView.Sort("SRF NUMBER", SortDirection.Descending);
                this.AddFileLink.DataBind();
            }
        }

        protected bool UserCanEdit()
        {
            return HttpContext.Current.User.IsInRole("UserAdmins");
        }
    }
}
