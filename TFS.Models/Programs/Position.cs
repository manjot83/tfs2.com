﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models;
using System.ComponentModel.DataAnnotations;
using Iesi.Collections.Generic;

namespace TFS.Models.Programs
{
    public class Position : BaseDomainEntity
    {
        public virtual int? Id { get; private set; }

        [DomainEquality]
        [Required, StringLength(50)]
        public virtual string Title { get; set; }
    }
}
