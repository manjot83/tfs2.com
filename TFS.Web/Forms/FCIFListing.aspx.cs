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
    public partial class FCIFListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.FilesListView.Sort("FCIF NUMBER", SortDirection.Descending);
                this.AddFileLink.DataBind();
            }
        }

        protected bool UserCanEdit()
        {
            return HttpContext.Current.User.IsInRole("UserManager");
        }
    }
}
