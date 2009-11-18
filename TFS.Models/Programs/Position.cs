using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models;

namespace TFS.Models.Programs
{
    public class Position : BaseEntity
    {
        public virtual int? Id { get; private set; }

        public virtual string Title { get; set; }
    }
}
