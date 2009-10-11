using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Site;
using FluentNHibernate.Mapping;

namespace TFS.Models.Data.Site
{
    public class PageMapping : ClassMap<Page>
    {
        public PageMapping()
        {
            Table("pages");
            Id(x => x.Id)
                .GeneratedBy.Guid()
                .Not.Nullable();
            Map(x => x.URI)
                .Not.Nullable();
            Map(x => x.Title)
                .Not.Nullable();            
            Map(x => x.Content)
                .Not.Nullable();
        }
    }
}
