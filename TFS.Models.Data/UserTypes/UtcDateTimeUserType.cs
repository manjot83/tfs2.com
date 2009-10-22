using System;
using System.Data;
using NHibernate;
using NHibernate.SqlTypes;
using NHibernate.UserTypes;

namespace TFS.Models.Data.UserTypes
{
    public class UtcDateTimeUserType : IUserType
    {
        object IUserType.NullSafeGet(IDataReader rs, string[] names, object owner)
        {
            var val = (string)NHibernateUtil.String.NullSafeGet(rs, names);
            var date = val != null ? DateTime.Parse(val) : (DateTime?)null;
            return date.HasValue ? DateTime.SpecifyKind(date.Value, DateTimeKind.Utc) : (DateTime?)null;
        }

        void IUserType.NullSafeSet(IDbCommand cmd, object value, int index)
        {
            var dateValue = (DateTime?)value;

            //We seem to get a DateTime.MinValue in stead of a null, turn that value into a null
            if (dateValue.HasValue)
                dateValue = dateValue.Value == DateTime.MinValue ? null : dateValue;

            if (dateValue.HasValue)
            {
                if (dateValue.Value.Kind != DateTimeKind.Utc)
                    throw new NotSupportedException(string.Format("This field can only persist a DateTime with a .Kind of Utc. Param {0} in [{1}]",
                                                                    index, cmd.CommandText));

                NHibernateUtil.String.NullSafeSet(cmd, dateValue.ToString(), index);
            }
            else
                NHibernateUtil.String.NullSafeSet(cmd, null, index);

        }

        SqlType[] IUserType.SqlTypes
        {
#if SQLITE
            get { return new[] { SqlTypeFactory.DateTime }; }
#else
            get { return new[] { SqlTypeFactory.DateTime2 }; }
#endif
        }

        Type IUserType.ReturnedType
        {
            get { return typeof(DateTime); }
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
