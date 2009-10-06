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

public partial class Controls_html_head : System.Web.UI.UserControl
{

    protected String pageTitle = "Tactical Flight Services II, Inc.";

    public String PageTitle
    {
        get
        {
            return pageTitle;
        }
        set
        {
            pageTitle = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
