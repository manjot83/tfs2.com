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

using TFS.OpCenter.Forms;

namespace TFS.Web.Forms
{
    public partial class FileList : System.Web.UI.Page
    {
        protected int formid;

        protected void Page_Load(object sender, EventArgs e)
        {
            formid = int.Parse(this.Request.Params["form"]);            


            if (!this.IsPostBack)
            {
                
            }
        }

        
    }
}
