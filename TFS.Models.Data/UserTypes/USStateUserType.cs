using System;
using System.Data;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;
using TFS.Models.Geography;

namespace TFS.Models.Data.UserTypes
{
    public class USStateUserType : IUserType
    {
        object IUserType.NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var val = NHibernateUtil.String.NullSafeGet(rs, names);
            if (val == null)
                return null;
            var state = USState.FromAbbreviation(val.ToString());
            if (state == null)
                throw new InvalidCastException("Invalid US State Abbreviation");
            return state;
        }

        void IUserType.NullSafeSet(IDbCommand cmd, object value, int index)
        {
            if (value != null && value is USState)
            {
                var val = ((USState)value).Abbreviation;
                NHibernateUtil.String.NullSafeSet(cmd, val, index);
            }
            else
                NHibernateUtil.String.NullSafeSet(cmd, null, index);
        }

        SqlType[] IUserType.SqlTypes
        {
            get { return new[] { SqlTypeFactory.GetString(2) }; }
        }

        Type IUserType.ReturnedType
        {
            get { return typeof(USState); }
        }

        bool IUserType.IsMutable
        {
            get { return false; }
        }

        object IUserType.DeepCopy(object value)
        {
            return value;
        }

        object IUserType.Replace(object original, object target, object owner)
        {
            return original;
        }

        object IUserType.Assemble(object cached, object owner)
        {
            return cached;
        }

        object IUserType.Disassemble(object value)
        {
            return value;
        }

        bool IUserType.Equals(object x, object y)
        {
            if ((x != null) && (y != null))
                return x.Equals(y);
            return false;
        }

        int IUserType.GetHashCode(object x)
        {
            return x.GetHashCode();
        }
    }
}