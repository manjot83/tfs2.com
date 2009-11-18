using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TFS.Models;

namespace TFS.Models
{
    [Serializable]
    public abstract class BaseEntity : BaseValidatableEntity
    {
        [ThreadStatic]
        private static Dictionary<Type, IEnumerable<PropertyInfo>> domainEqualityPropertiesDictionary;
        private const int HASH_MULTIPLIER = 42;

        public override bool Equals(object obj)
        {
            var compareTo = obj as BaseEntity;

            if (ReferenceEquals(this, compareTo))
                return true;

            return compareTo != null &&
                   GetType().Equals(compareTo.GetTypeUnproxied()) &&
                   HasSameDomainEqualityAs(compareTo);
        }

        public static bool operator ==(BaseEntity object1, BaseEntity object2)
        {
            var object1Null = object.ReferenceEquals(object1, null);
            var object2Null = object.ReferenceEquals(object2, null);
            if (object1Null && object2Null)
                return true;
            if (object1Null || object2Null)
                return false;
            return object1.Equals(object2);
        }

        public static bool operator !=(BaseEntity object1, BaseEntity object2)
        {
            return !(object1 == object2);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var domainEqualityProperties = GetDomainEqualityProperties();
                if (!domainEqualityProperties.Any())
                    return base.GetHashCode();

                int hashCode = GetType().GetHashCode();
                foreach (PropertyInfo property in domainEqualityProperties)
                {
                    var value = property.GetValue(this, null);
                    if (value != null)
                        hashCode = (hashCode * HASH_MULTIPLIER) ^ value.GetHashCode();
                }
                return base.GetHashCode();
            }
        }

        public virtual bool HasSameDomainEqualityAs(BaseEntity compareTo)
        {
            var domainEqualityProperties = GetDomainEqualityProperties();

            foreach (PropertyInfo property in domainEqualityProperties)
            {
                object valueOfThisObject = property.GetValue(this, null);
                object valueToCompareTo = property.GetValue(compareTo, null);

                if (valueOfThisObject == null && valueToCompareTo == null)
                    continue;

                if ((valueOfThisObject == null ^ valueToCompareTo == null) ||
                    (!valueOfThisObject.Equals(valueToCompareTo)))
                {
                    return false;
                }
            }

            return domainEqualityProperties.Any() || base.Equals(compareTo);
        }

        public virtual IEnumerable<PropertyInfo> GetDomainEqualityProperties()
        {
            if (domainEqualityPropertiesDictionary == null)
                domainEqualityPropertiesDictionary = new Dictionary<Type, IEnumerable<PropertyInfo>>();
            IEnumerable<PropertyInfo> properties;
            if (domainEqualityPropertiesDictionary.TryGetValue(GetType(), out properties))
                return properties;
            return (domainEqualityPropertiesDictionary[GetType()] = GetTypeSpecificDomainEqualityProperties());
        }

        protected virtual Type GetTypeUnproxied()
        {
            return GetType();
        }

        protected virtual IEnumerable<PropertyInfo> GetTypeSpecificDomainEqualityProperties()
        {
            return GetType().GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(DomainEqualityAttribute), true));
        }
    }
}
