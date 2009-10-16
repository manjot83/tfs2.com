using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Centro.DomainModel;

namespace TFS.Models.Geography
{
    public class USAddress : BaseEntity
    {
        public virtual string StreetAddress { get; set; }
        public virtual string City { get; set; }
        public virtual USState State { get; set; }
        public virtual string ZipCode { get; set; }
    }
}
