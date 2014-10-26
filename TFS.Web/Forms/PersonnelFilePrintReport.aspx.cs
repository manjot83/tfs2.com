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

using TFS.OpCenter.Forms.UI;
using TFS.OpCenter;
using TFS.OpCenter.Data;

namespace TFS.Web.Forms
{
    public partial class PersonnelFilePrintReport : System.Web.UI.Page
    {
        protected FormFileController controller;

        protected void Page_Load(object sender, EventArgs e)
        {
            TFS.OpCenter.Data.Form form = TFS.OpCenter.Data.Form.FetchByID(103);
            if (form == null)
                throw new Exception("Form is null");
            Person person = Utility.GetActivePerson();
            controller = new FormFileController(form);
            if (!controller.HasFile(person))
                controller.CreateFile(person);
            controller.LoadFile(person);

            if (!this.IsPostBack)
            {
                this.ViewableFileControl.FileId = controller.File.Id;
            }

        }
    }
}
