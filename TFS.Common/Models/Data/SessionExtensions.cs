﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace TFS.Models.Data
{
    public static class SessionExtensions
    {
        public static object Save<TObject>(this ISession session, TObject entity) {
            return session.Save(entity);
        }

        public static TObject SaveOrUpdateCopy<TObject>(this ISession session, TObject entity) {
            return (TObject)session.SaveOrUpdateCopy(entity);
        }
    }
}
