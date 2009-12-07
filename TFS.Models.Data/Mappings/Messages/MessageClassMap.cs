using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TFS.Models.Messages;
using FluentNHibernate.Mapping;
using TFS.Models.Data.UserTypes;

namespace TFS.Models.Data.Mappings.Messages
{
    public class MessageClassMap : ClassMap<Message>
    {
        public MessageClassMap()
        {
            Id(x => x.Id)
                .GeneratedBy.Identity();

            Map(x => x.Title)
                .Not.Nullable()
                .Length(100);
            Map(x => x.ActiveFromDate)
                .CustomType<UtcDateTimeUserType>()
                .Not.Nullable();
            Map(x => x.ActiveToDate)
                .CustomType<UtcDateTimeUserType>()
                .Not.Nullable();

            HasMany(x => x.UserStatuses)
                .LazyLoad()
                .Table("MessagesForUsers")
                .KeyColumn("MessageId")
                .ForeignKeyConstraintName("FK_MessagesForUsers_Messages")
                .Component(c =>
                {
                    c.ParentReference(x => x.Message);
                    c.Map(x => x.SeenAtDate)
                        .CustomType<UtcDateTimeUserType>()
                        .Nullable();
                    c.References(x => x.User)
                        .Column("UserId")
                        .ForeignKey("FK_MessagesForUsers_Users")
                        .Not.Nullable();
                });
        }
    }
}
