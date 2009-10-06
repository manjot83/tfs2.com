using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TFS.OpCenter.People;

namespace TFS.Web.Users
{
    public partial class DatabaseSynchronization : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.BindPersonsGridView();
            }
        }

        protected void BindPersonsGridView()
        {
            PersonsGridView.DataSource = PeopleCollection.GetPeopleFromActiveDirectory();
            PersonsGridView.DataBind();
        }

        protected void HandleRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Sync"))
            {
                string username = e.CommandArgument.ToString();
                PeopleCollection.GetPeopleFromActiveDirectory()[username].SyncToDatabase();
                this.BindPersonsGridView();
            }
        }

        protected void HandleSyncAllButtonClick(object sender, EventArgs e)
        {
            foreach (SyncEnabledPerson person in PeopleCollection.GetPeopleFromActiveDirectory())
            {
                if (person.HasDatabaseEntity == false)
                    person.SyncToDatabase();
            }
            this.BindPersonsGridView();
        }
    }
}
