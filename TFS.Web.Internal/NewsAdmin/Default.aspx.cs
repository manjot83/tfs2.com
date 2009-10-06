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
using TFS.OpCenter.UI;
using TFS.OpCenter.News;

public partial class news_admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void HandleNewsItemCommand(object sender, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "MarkIsUrgent")
        {
            NewsController controller = new NewsController();            
            CommandCheckBox checkbox = (CommandCheckBox)e.CommandSource;
            controller.SelectNewsPost((int)e.CommandArgument);
            controller.UpdateIsUrgent(checkbox.Checked);
        }
    }
}
