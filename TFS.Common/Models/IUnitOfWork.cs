﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFS.Models
{
    public interface IUnitOfWork
    {
        void Start();
        void Finish();
        void Abort();
    }
}
