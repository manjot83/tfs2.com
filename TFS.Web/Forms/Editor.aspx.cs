using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Elmah.Assertions;
using StructureMap;
using StructureMap.Pipeline;
using StructureMap.Query;
using TFS.Intranet.Data.Billing;
using TFS.OpCenter;
using TFS.OpCenter.Forms.UI;
using TFS.OpCenter.Data;
using TFS.Web.Mvc;
using TFS.Web.ViewModels;

namespace TFS.Web.Forms
{
    public partial class Editor : System.Web.UI.Page
    {

        protected FormFileController controller;
        private string fileType = null;
        private int _fileid = 0;
        private bool _isNewFileRequestParam = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            fileType = this.Request.Params["filetype"];

            bool newfile = !(int.TryParse(this.Request.Params["file"], out _fileid));

            if (!bool.TryParse(this.Request.Params["newFile"], out _isNewFileRequestParam))
                _isNewFileRequestParam = false;

            int formid = int.Parse(this.Request.Params["form"]);

            this.controller = new FormFileController(formid);

            if (newfile)
            {
                Formfile file = this.controller.CreateFile();
                // redirect to the correct page
                Response.Redirect(string.Format("Editor.aspx?file={0}&form={1}&fileType={2}&newFile=true", file.Id, formid, fileType));
            }
            else
                this.controller.LoadFile(_fileid);

            if (!this.IsPostBack)
                this.EditForm.EditableForm = this.controller.EditableForm;
        }

        protected void OnSaveButtonPressed(object sender, EventArgs e)
        {
            if (!_isNewFileRequestParam)
                editorRedirectHelper(); //exit

            TFS.OpCenter.UI.EditableFileFormEventArgs customEventArgs;

            try
            {
                //cast will fail when user has not entered the Subject and Content of an SRF/FCIF
                customEventArgs = (TFS.OpCenter.UI.EditableFileFormEventArgs)e;
            }
            catch (System.InvalidCastException exception)
            {
                //just continue if cannot be casted, not point in sending email notifications
                editorRedirectHelper();
                return;
            }

            var catController = new ArticlecategoryController();
            var category = catController.FetchAll().SingleOrDefault(item => item.Name.ToLower() == "general");
            var categoryId = 5; //general category id;


            if (category != null)
            {
                categoryId = category.Id;
            }

            var url = string.Empty;

            switch (fileType.ToLower())
            {
                case "srf":
                    url = "{0}/Forms/SRFView.aspx?file={1}";
                    break;
                case "fcif":
                    url = "{0}/Forms/FCIFListing.aspx?file={1}";
                    break;
            }

            if (string.IsNullOrEmpty(url))
                editorRedirectHelper();
            url = string.Format(url, Utility.GetCurrentWebsiteRoot(), _fileid);
            var subject = string.Format("{0} {1} Released", fileType.ToUpper(), customEventArgs.SrfFcifNumber);
            var content = string.Format("{0} <a href=\"{1}\">Click Here</a>", subject, url);

            var newPostController = new NewspostController();
            var newsPostId = newPostController.Insert(DateTime.Now, HttpContext.Current.User.Identity.Name, categoryId, subject, content, true);


            WebRequestHelper.UserControllerSendNewsPostNotificationRequest(newsPostId);

            editorRedirectHelper();
        }

        protected void OnDeleteButtonPressed(object sender, EventArgs e)
        {
            editorRedirectHelper();
        }

        protected void OnCancelButtonPressed(object sender, EventArgs e)
        {
            editorRedirectHelper();
        }

        private void editorRedirectHelper()
        {
            if (string.IsNullOrEmpty(fileType))
                return;

            var url = string.Empty;

            switch (fileType.ToLower())
            {
                case "srf":
                    url = "~/Forms/SRFListing.aspx";
                    break;
                case "fcif":
                    url = "~/Forms/FCIFListing.aspx";
                    break;
            }

            if (!string.IsNullOrEmpty(url))
                Response.Redirect(url);
        }

    }
}
