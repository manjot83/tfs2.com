using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TFS.Models.Messages;

namespace TFS.Web.ViewModels.Messages
{
    public class AnnouncementViewModel : MessageViewModel
    {
        public string CreatedByFileByName { get; set; }
        [Required]
        public string CreatedByUsername { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public bool Urgent { get; set; }

        public override MessageType MessageType
        {
            get { return MessageType.Announcement; } 
        }
    }
}
