using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Images;
using FluentNHibernate.Mapping;

namespace TFS.Models.Data.Mappings.Images
{
    public class StaticImageMap : ClassMap<StaticImage>
    {
        public StaticImageMap()
        {
            Table("StaticImages");

            Id(x => x.Id)
                .Not.Nullable()
                .GeneratedBy.Guid();

            Map(x => x.MimeType)
                .Not.Nullable()
                .Length(50);
            Map(x => x.Description)
                .Not.Nullable()
                .Length(200);
        }
    }
}
