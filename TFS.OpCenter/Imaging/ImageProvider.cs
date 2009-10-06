using System;
using System.IO;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Drawing.Imaging;
using System.Drawing;

namespace TFS.OpCenter.Imaging
{

    public class ImageProvider
    {
        public enum ImageSize
        {
            big, medium, small
        }

        public static bool DoNothing()
        {
            return false;
        }

        public ImageProvider()
        {
        }

        public static Bitmap ScaleToWidth(int width, Bitmap bitmap)
        {
            double scale = ((double)width / (double)bitmap.Width);
            double height = bitmap.Height * scale;
            return new Bitmap(bitmap.GetThumbnailImage(width, (int)height, new System.Drawing.Image.GetThumbnailImageAbort(DoNothing), System.IntPtr.Zero));
        }

        public static Bitmap GetImage(int id, int size)
        {
            String savePath = ConfigurationManager.AppSettings["ImageFileLocation"];
            Bitmap image = new Bitmap("" + savePath + "image_" + id + "_size_" + size + ".jpg");
            return image;
        }

        //public static Bitmap getImage(int id, ImageSize size)
        //{

        //    String savePath = ConfigurationManager.AppSettings["ImageFileLocation"];
        //    Bitmap image = new Bitmap("" + savePath + "image_" + id + "_size_1.jpg");
        //    return image;

        //     /*Bitmap bitmap = null;

        //    //use the web.config to store the connection string
        //     SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["WebsiteConnString"].ConnectionString);    

        //    SqlCommand command = new SqlCommand("SELECT * FROM Images WHERE ID=@imageID", connection);
        //    SqlParameter param0 = new SqlParameter("@imageID", SqlDbType.Int);
        //    param0.Value = id;
        //    command.Parameters.Add(param0);
        //    command.Connection.Open();
        //    SqlDataReader dr = command.ExecuteReader();
        //        if ( dr.Read()) //yup we found our image
        //        {
        //            MemoryStream memStream1 = null;
        //            if (size == ImageSize.big)
        //                memStream1 = new MemoryStream((byte[])dr["BinaryBig"]);
        //            if (size == ImageSize.medium)
        //                memStream1 = new MemoryStream((byte[])dr["BinaryMedium"]);
        //            if (size == ImageSize.small)
        //                memStream1 = new MemoryStream((byte[])dr["BinarySmall"]);
        //            bitmap = new Bitmap(memStream1);
        //        }
        //    connection.Close();

        //    return bitmap;*/

        //}

        public static int SaveToDB(string imgName, string imgcontenttype, Bitmap mainImage)
        {
            System.Drawing.Image img1 = ImageProvider.ScaleToWidth(300, mainImage);
            Bitmap big = new Bitmap(img1);
            System.Drawing.Image img2 = ImageProvider.ScaleToWidth(200, mainImage);
            Bitmap med = new Bitmap(img2);
            System.Drawing.Image img3 = ImageProvider.ScaleToWidth(100, mainImage);
            Bitmap small = new Bitmap(img3);

            //use the web.config to store the connection string
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["WebsiteConnString"].ConnectionString);

            SqlCommand command = new SqlCommand("INSERT INTO Images VALUES ( @content_type, @img_desc)", connection);
            SqlParameter param0 = new SqlParameter("@content_type", SqlDbType.VarChar, 50);
            param0.Value = imgcontenttype;
            command.Parameters.Add(param0);
            SqlParameter param1 = new SqlParameter("@img_desc", SqlDbType.VarChar, 200);
            param1.Value = imgName;
            command.Parameters.Add(param1);
            connection.Open();
            int numRowsAffected = command.ExecuteNonQuery();
            connection.Close();

            //we'll try and get the id of the immage we just loaded, I hope
            SqlCommand getIdCmd = new SqlCommand("SELECT TOP 1 ID FROM Images ORDER BY ID DESC", connection);
            connection.Open();
            int imageID = Int32.Parse(getIdCmd.ExecuteScalar().ToString());
            connection.Close();

            String savePath = ConfigurationManager.AppSettings["ImageFileLocation"];
            big.Save("" + savePath + "image_" + imageID + "_size_3.jpg", ImageFormat.Jpeg);
            med.Save("" + savePath + "image_" + imageID + "_size_2.jpg", ImageFormat.Jpeg);
            small.Save("" + savePath + "image_" + imageID + "_size_1.jpg", ImageFormat.Jpeg);

            return 0;
        }

        /*public static int SaveToDB(string imgName, string imgcontenttype, Bitmap big, Bitmap med, Bitmap small)
        {

            MemoryStream memStream1 = new MemoryStream();
            big.Save(memStream1, ImageFormat.Jpeg);
            MemoryStream memStream2 = new MemoryStream();
            med.Save(memStream2, ImageFormat.Jpeg);
            MemoryStream memStream3 = new MemoryStream();
            small.Save(memStream3, ImageFormat.Jpeg);


            //use the web.config to store the connection string
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["WebsiteConnString"].ConnectionString);    


            SqlCommand command = new SqlCommand("INSERT INTO Images VALUES ( @content_type, @img_desc, @bin_big, @bin_med, @bin_small )", connection);
            SqlParameter param0 = new SqlParameter("@content_type", SqlDbType.VarChar, 50);
            param0.Value = imgcontenttype;
            command.Parameters.Add(param0);
            SqlParameter param1 = new SqlParameter("@img_desc", SqlDbType.VarChar, 200);
            param1.Value = imgName;
            command.Parameters.Add(param1);
            SqlParameter param2 = new SqlParameter("@bin_big", SqlDbType.Image);
            param2.Value = memStream1.GetBuffer();
            command.Parameters.Add(param2);
            SqlParameter param3 = new SqlParameter("@bin_med", SqlDbType.Image);
            param3.Value = memStream2.GetBuffer();
            command.Parameters.Add(param3);
            SqlParameter param4 = new SqlParameter("@bin_small", SqlDbType.Image);
            param4.Value = memStream3.GetBuffer();
            command.Parameters.Add(param4);
            connection.Open();
            int numRowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return numRowsAffected;
        }*/

        public static void DeleteImage(int id)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["WebsiteConnString"].ConnectionString);

            SqlCommand command = new SqlCommand("DELETE FROM Images WHERE ID=@id", connection);
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

            String savePath = ConfigurationManager.AppSettings["ImageFileLocation"];
            File.Delete("" + savePath + "image_" + id + "_size_1.jpg");
            File.Delete("" + savePath + "image_" + id + "_size_2.jpg");
            File.Delete("" + savePath + "image_" + id + "_size_3.jpg");

        }

    }
}