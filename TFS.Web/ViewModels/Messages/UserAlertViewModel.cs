using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TFS.Models.Messages;

namespace TFS.Web.ViewModels.Messages
{
    public class UserAlertViewModel : MessageViewModel
    {
        public string ForFileByName { get; set; }
        [Required]
        public string ForUsername { get; set; }
        [Required]
        public string Content { get; set; }

        public override MessageType MessageType
        {
            get { return MessageType.UserAlert; }
        }
    }
}
