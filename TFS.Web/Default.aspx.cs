using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using TFS.OpCenter.Data;
using System.Collections.Generic;

public partial class main_Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            IEnumerable<Newspost> urgentNews = new NewspostController().FetchUrgent();
            NewspostCollection news = new NewspostController().FetchAllNotDeleted();
            HelparticleCollection helparticles = new HelparticleController().FetchAllNotDeleted();

            news.Sort(Newspost.Columns.Createdon, false);
            helparticles.Sort(Helparticle.Columns.Createdon, false);

            this.HotItems.DataSource = urgentNews;
            this.HotItems.DataBind();

            this.NewsEntries.DataSource = news;
            this.NewsEntries.DataBind();

            this.HelpEntries.DataSource = helparticles;
            this.HelpEntries.DataBind();
        }
    }
}
