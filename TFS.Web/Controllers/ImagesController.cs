using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using TFS.Models.Images;
using Centro.Web.Mvc.ActionFilters;

namespace TFS.Web.Controllers
{
    public partial class ImagesController : Controller
    {
        private IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [RequireTransaction]
        public virtual ActionResult StaticImage(Guid id)
        {
            var imageInfo = imageRepository.GetStaticImage(id);
            if (imageInfo == null)
                return new EmptyResult();
            //return File(string.Empty, imageInfo.MimeType);
            throw new NotImplementedException();
        }
    }
}
