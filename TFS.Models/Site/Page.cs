using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Images;
using TFS.Models;

namespace TFS.Models.Site
{
    public class Page 
    {
        public Page()
        {
            Images = new List<StaticImage>();
        }
        public virtual Guid? Id { get; private set; }
        public virtual string URI { get; set; }
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
        public virtual string BannerFileName { get; set; }
        public virtual string HeaderFileName { get; set; }
        public virtual IList<StaticImage> Images { get; set; }
    }
}
