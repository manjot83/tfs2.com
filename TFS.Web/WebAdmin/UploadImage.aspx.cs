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
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using TFS.OpCenter.Imaging;

public partial class admin_UploadImage : System.Web.UI.Page
{

    
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void UploadBtn_Click(object sender, System.EventArgs e)
    {
        if (Page.IsValid) //save the image
        {
            string imgContentType = UploadFile.PostedFile.ContentType;
            string imgName = textImageName.Text;
            Bitmap bitmap = new Bitmap(UploadFile.PostedFile.InputStream);

            /*System.Drawing.Image img1 = ImageProvider.scaleToWidth(300, bitmap);
            Bitmap big = new Bitmap(img1);
            System.Drawing.Image img2 = ImageProvider.scaleToWidth(200, bitmap);
            Bitmap med = new Bitmap(img2);
            System.Drawing.Image img3 = ImageProvider.scaleToWidth(100, bitmap);
            Bitmap small = new Bitmap(img3);

            int RowsAffected = ImageProvider.SaveToDB(imgName, imgContentType, big, med, small);*/
            int errorCode = ImageProvider.SaveToDB(imgName, imgContentType, bitmap);

            if (errorCode == 0)
            {
                Response.Redirect(".");
            }
            else
            {
                Response.Write("<BR>An error occurred uploading the image");
            }
        }
    }

}
