using System;
using System.ComponentModel.DataAnnotations;
using TFS.Models;
using TFS.Models.Messages;
using TFS.Models.Validation;

namespace TFS.Web.ViewModels.Messages
{
    public abstract class MessageViewModel : BaseValidatableObject
    {
        public int? Id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required, DateTimeKind(DateTimeKind.Utc)]
        public DateTime? ActiveFromDate { get; set; }

        [Required, DateTimeKind(DateTimeKind.Utc)]
        public DateTime? ActiveToDate { get; set; }

        [Required]
        public string Content { get; set; }

        public MessageType MessageType { get; set; }

        public bool CanEdit { get; set; }

        public AnnouncementViewModel AsAnnouncement()
        {
            return this as AnnouncementViewModel;
        }

        public SystemAlertViewModel AsSystemAlert()
        {
            return this as SystemAlertViewModel;
        }

        public UserAlertViewModel AsUserAlert()
        {
            return this as UserAlertViewModel;
        }
    }
}
