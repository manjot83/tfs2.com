using System;
using System.Linq;
using System.Text;
using TFS.Models.Images;
using TFS.Models;
using Iesi.Collections.Generic;

namespace TFS.Models.Site
{
    public class Page : BaseDomainObject
    {
        public Page()
        {
            Images = new HashedSet<StaticImage>();
        }
        public virtual Guid? Id { get; private set; }
        public virtual string URI { get; set; }
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
        public virtual string BannerFileName { get; set; }
        public virtual string HeaderFileName { get; set; }
        public virtual ISet<StaticImage> Images { get; set; }
    }
}
