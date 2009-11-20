﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace TFS.Models.Data
{
    public static class SessionExtensions
    {
        public static TObject SaveOrUpdateCopy<TObject>(this ISession session, TObject entity)
        {
            return (TObject)session.SaveOrUpdateCopy(entity);
        }
    }
}
