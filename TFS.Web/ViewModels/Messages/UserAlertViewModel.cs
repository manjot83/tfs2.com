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
        public string ForUsername { get; set; }
    }
}
