﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Site;
using FluentNHibernate.Mapping;
using TFS.Models.Images;

namespace TFS.Models.Data.Mappings.Site
{
    public class PageMap : ClassMap<Page>
    {
        public PageMap()
        {
            Table("Pages");

            Id(x => x.Id)
                .GeneratedBy.GuidComb()
                .Not.Nullable();

            Map(x => x.URI)
                .Not.Nullable()
                .Length(50);
            Map(x => x.Title)
                .Not.Nullable()
                .Length(100);
            Map(x => x.Content)
                .Not.Nullable();
            Map(x => x.BannerFileName)
                .Not.Nullable()
                .Length(100);
            Map(x => x.HeaderFileName)
                .Not.Nullable()
                .Length(100);

            HasManyToMany(x => x.Images)
                .Table("PageStaticImages")
                .ForeignKeyConstraintNames("FK_PageStaticImages_Pages","FK_PageStaticImages_StaticImages")
                .LazyLoad()
                .ParentKeyColumn("PageId")
                .ChildKeyColumn("StaticImageId")
                .Cascade.SaveUpdate();
        }
    }
}