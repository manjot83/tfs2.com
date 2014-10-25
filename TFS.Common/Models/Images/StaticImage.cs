using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using TFS.Models;

namespace TFS.Models.Images
{
    public class StaticImage : BaseDomainObject
    {
        public virtual Guid? Id { get; private set; }
        public virtual string MimeType { get; set; }
        public virtual string Description { get; set; }
    }
}
