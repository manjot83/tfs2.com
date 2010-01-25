using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Models.Images;
using TFS.Web.Mvc;

namespace TFS.Web.Controllers
{
    public partial class ImagesController : TransactionalController
    {
        private IImageFinder imageFinder;

        public ImagesController(IImageFinder imageFinder)
        {
            this.imageFinder = imageFinder;
        }

        public virtual ActionResult StaticImage(Guid id)
        {
            var imageInfo = imageFinder.GetStaticImage(id);
            if (imageInfo == null)
                return new EmptyResult();
            //return File(string.Empty, imageInfo.MimeType);
            throw new NotImplementedException();
        }
    }
}
