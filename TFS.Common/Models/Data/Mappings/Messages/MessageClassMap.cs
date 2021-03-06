﻿using FluentNHibernate.Mapping;
using TFS.Models.Data.UserTypes;
using TFS.Models.Messages;

namespace TFS.Models.Data.Mappings.Messages
{
    public class MessageClassMap : ClassMap<Message>
    {
        public MessageClassMap()
        {
            Table("Messages");

            Id(x => x.Id)
                .GeneratedBy.GuidComb();

            Map(x => x.Title)
                .Not.Nullable()
                .Length(100);
            Map(x => x.ActiveFromDate)
                .CustomType<UtcDateTimeUserType>()
                .Not.Nullable();
            Map(x => x.ActiveToDate)
                .CustomType<UtcDateTimeUserType>()
                .Not.Nullable();
            Map(x => x.Content)
                .Column("Content")
                .WithMaxLength()
                .Nullable(); // Must be nullable because of table-per-hierarchy

            HasMany(x => x.MessageStatusForUsers)
                .LazyLoad()
                .Inverse()
                .KeyColumn("MessageId");

            DiscriminateSubClassesOnColumn<int>("MessageType", (int)MessageType.Unknown);
        }
    }
}
