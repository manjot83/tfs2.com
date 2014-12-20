using System.ComponentModel.DataAnnotations;
using TFS.Models;

namespace TFS.Web.ViewModels
{
    public class UserViewModel
    {
        [Required, StringLength(50)]
        public string Username { get; set; }

        [Required, StringLength(50)]
        public string FirstName { get; set; }

        [Required, StringLength(50)]
        public string LastName { get; set; }

        [Required, StringLength(100)]
        public string DisplayName { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public bool Disabled { get; set; }

        public bool RolesUserManager { get; set; }
        public bool RolesPersonnelManager { get; set; }
        public bool RolesProgramManager { get; set; }
        public bool RolesFlightLogManager { get; set; }
        public bool RolesPayrollAdmin { get; set; }

        public string Title { get; set; }
        public int RateGroup { get; set; }
    }
}
