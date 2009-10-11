using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Models.Site
{
    public class Page
    {
        public virtual Guid Id { get; private set; }

        public virtual string URI { get; set; }

        public virtual string Title { get; set; }

        public virtual string Content { get; set; }
    }
}
