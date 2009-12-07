using FluentNHibernate.Mapping;
using TFS.Models.Data.UserTypes;
using TFS.Models.Messages;

namespace TFS.Models.Data.Mappings.Messages
{
    public class MessageStatusClassMap : ClassMap<MessageStatus>
    {
        public MessageStatusClassMap()
        {
            CompositeId()
                .KeyReference(x => x.User,
                              "UserId",
                              x => {
                                x.ForeignKey("FK_MessagesForUsers_Users");
                              })
                .KeyReference(x => x.Message,
                              "MessageId",
                              x => {
                                  x.ForeignKey("FK_MessagesForUsers_Messages");
                              });

            Map(x => x.SeenAtDate)
                .CustomType<UtcDateTimeUserType>()
                .Nullable();
        }
    }
}
