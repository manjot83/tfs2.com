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
using System.Drawing;

public partial class images_ImageView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int id = Int32.Parse(Request.Params["id"]);
        int size = Int32.Parse(Request.Params["size"]);
        //String imagePath = ConfigurationManager.AppSettings["ImageURLPrefix"];
        String imagePath = ConfigurationManager.AppSettings["ImageFileLocation"];
        //Response.Redirect("" + imagePath + "image_" + id + "_size_" + size + ".jpg"
        Response.ContentType = "image/jpeg";
        Response.TransmitFile("" + imagePath + "image_" + id + "_size_" + size + ".jpg");
        /*Bitmap bitmap = null;
        bitmap = ImageProvider.getImage(id, size);
        bitmap.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);*/
    }


}
