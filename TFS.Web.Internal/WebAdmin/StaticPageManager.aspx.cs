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
using TFS.OpCenter.Imaging;
using TFS.CMS;

public partial class StaticPageManager : System.Web.UI.Page
{    

    protected void Page_Load(object csender, EventArgs e)
    {
    }


    protected void upbutton_Click(object sender, EventArgs e)
    {
        LinkButton button = (LinkButton)sender;
        String[] args = button.CommandArgument.Split(new String[] { " " }, StringSplitOptions.None);
        int currentPosition = Int32.Parse(args[1]);
        int newPosition = currentPosition - 1;
        if (newPosition < 0)
            return;
        String uri = args[0];
        SQLProvider.swapLinkPosition(uri, currentPosition, newPosition);
        PagesRepeater.DataBind();
    }

    protected void downbutton_Click(object sender, EventArgs e)
    {
        LinkButton button = (LinkButton)sender;
        String[] args = button.CommandArgument.Split(new String[] { " " }, StringSplitOptions.None);
        int currentPosition = Int32.Parse(args[1]);
        int newPosition = currentPosition + 1;
        if (newPosition >= PagesRepeater.Items.Count)
            return;
        String uri = args[0];
        SQLProvider.swapLinkPosition(uri, currentPosition, newPosition);
        PagesRepeater.DataBind();
    }

    protected void homebutton_Click(object sender, EventArgs e)
    {
        Response.Redirect("http://www.tfs2.com");
    }

    protected void addapage_Click(object sender, EventArgs e)
    {
        Response.Redirect("NewPage.aspx");
    }

    protected void addimage_Click(object sender, EventArgs e)
    {
        Response.Redirect("UploadImage.aspx");
    }

    protected void deletepage_Click(object sender, EventArgs e)
    {
        LinkButton button = (LinkButton)sender;
        SQLProvider.deletePage(button.CommandArgument);
        PagesRepeater.DataBind();
    }

    protected void deleteimage_Click(object sender, EventArgs e)
    {        
        LinkButton button = (LinkButton)sender;
        image_id_to_delete.Value = button.CommandArgument;
        int image_id = Int32.Parse(image_id_to_delete.Value);
        ImageProvider.DeleteImage(image_id);
        //ImagesDataSource.Delete();
        ImagesRepeater.DataBind();
    }
    
    /*protected void image_deleting(object sender, SqlDataSourceCommandEventArgs e)
    {
        e.Command.Parameters.Clear();
        e.Command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@ID", image_id_to_delete.Value));
        
    }*/ 

    protected void ActiveCheck_Toggle(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        RepeaterItem repeaterRow = (RepeaterItem)checkbox.Parent;
        String uri = ((Label)repeaterRow.FindControl("urilabel")).Text;

        SQLProvider.setActive(uri, checkbox.Checked);
        PagesRepeater.DataBind();
    }
}
