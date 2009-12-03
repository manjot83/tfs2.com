using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;

namespace TFS.Models.Data.Mappings
{
    public static class MappingExtensions
    {
        public static PropertyPart WithMaxLength(this PropertyPart propertyPart)
        {
            return propertyPart.Length(10000);
        }
    }
}
