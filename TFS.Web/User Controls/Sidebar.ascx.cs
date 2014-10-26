using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TFS.OpCenter.Data;

public partial class User_Controls_Sidebar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.LinkRepeater.DataSource = Externallink.FetchAll();
        this.LinkRepeater.DataBind();
    }
}
