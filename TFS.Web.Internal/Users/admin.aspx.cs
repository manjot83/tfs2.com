using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using TFS.Security.ActiveDirectory;
using TFS.OpCenter.People;
using TFS.OpCenter.Data;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            this.BindPersons();
        }
    }

    protected void BindPersons()
    {
        PersonController controller = new PersonController();
        PersonsListView.DataSource = controller.FetchAll();
        PersonsListView.DataBind();
    }

    protected void HandleOnPersonListViewItemCommand(object sender, ListViewCommandEventArgs e)
    {
        if (e.CommandName.Equals("Sync"))
        {
            this.BindPersons();
        }
    }

  


}
