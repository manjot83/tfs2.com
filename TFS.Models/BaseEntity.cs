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
        private static Dictionary<Type, IEnumerable<PropertyInfo>> signaturePropertiesDictionary;
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

        public override int GetHashCode()
        {
            unchecked
            {
                var signatureProperties = GetSignatureProperties();
                if (!signatureProperties.Any())
                    return base.GetHashCode();

                int hashCode = GetType().GetHashCode();
                foreach (PropertyInfo property in signatureProperties)
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
            var signatureProperties = GetSignatureProperties();

            foreach (PropertyInfo property in signatureProperties)
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

            return signatureProperties.Any() || base.Equals(compareTo);
        }

        public virtual IEnumerable<PropertyInfo> GetSignatureProperties()
        {
            if (signaturePropertiesDictionary == null)
                signaturePropertiesDictionary = new Dictionary<Type, IEnumerable<PropertyInfo>>();
            IEnumerable<PropertyInfo> properties;
            if (signaturePropertiesDictionary.TryGetValue(GetType(), out properties))
                return properties;
            return (signaturePropertiesDictionary[GetType()] = GetTypeSpecificSignatureProperties());
        }

        protected virtual Type GetTypeUnproxied()
        {
            return GetType();
        }

        protected virtual IEnumerable<PropertyInfo> GetTypeSpecificSignatureProperties()
        {
            return GetType().GetProperties()
                .Where(p => Attribute.IsDefined(p, typeof(DomainEqualityAttribute), true));
        }
    }
}
