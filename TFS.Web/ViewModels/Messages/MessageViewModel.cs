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

        public abstract MessageType MessageType { get; }

        public bool CanEdit { get; set; }
    }
}
