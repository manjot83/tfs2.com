using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.PersonnelRecords;
using FluentNHibernate.Mapping;

namespace TFS.Models.Data.Mappings.PersonnelRecords
{
    public class CertificateMap : ClassMap<Certificate>
    {
        public CertificateMap()
        {
            Table("Certificates");

            Id(x => x.Id)
                .GeneratedBy.Identity()
                .Not.Nullable();

            Map(x => x.Type)
                .Not.Nullable()
                .CustomType<CertificateType>();
            Map(x => x.Name)
                .Length(50)
                .Not.Nullable();
        }
    }
}
