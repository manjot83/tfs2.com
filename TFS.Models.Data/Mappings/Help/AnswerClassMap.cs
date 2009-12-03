using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Help;
using FluentNHibernate.Mapping;
using TFS.Models.Data.UserTypes;

namespace TFS.Models.Data.Mappings.Help
{
    public class AnswerClassMap : ClassMap<Answer>
    {
        public AnswerClassMap()
        {
            Table("Answers");

            Id(x => x.Id)
                .GeneratedBy.Identity()
                .Not.Nullable();

            Map(x => x.Content)
                .WithMaxLength()
                .Not.Nullable();
            Map(x => x.AnsweredOnDate)
                .CustomType<UtcDateTimeUserType>()
                .Not.Nullable();

            References(x => x.Question)
                .ForeignKey("FK_Answers_Questions")
                .Column("QuestionId")
                .Not.Nullable();
        }
    }
}
