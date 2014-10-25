using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Help;
using FluentNHibernate.Mapping;
using TFS.Models.Data.UserTypes;

namespace TFS.Models.Data.Mappings.Help
{
    public class QuestionClassMap : ClassMap<Question>
    {
        public QuestionClassMap()
        {
            Table("Questions");

            Id(x => x.Id)
                .GeneratedBy.GuidComb()
                .Not.Nullable();

            Map(x => x.Title)
                .Length(100)
                .Not.Nullable();
            Map(x => x.AskedOnDate)
                .CustomType<UtcDateTimeUserType>()
                .Not.Nullable();
            Map(x => x.LastModifiedDate)
                .CustomType<UtcDateTimeUserType>()
                .Not.Nullable();
            Map(x => x.Content)
                .WithMaxLength()
                .Nullable();

            References(x => x.Answer)
                .ForeignKey("FK_Questions_Answers")
                .Column("AnswerId")
                .Nullable();
        }
    }
}
