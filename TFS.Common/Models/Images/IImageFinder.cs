using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Models.Images
{
    public interface IImageFinder
    {
        StaticImage GetStaticImage(Guid id);
    }
}
