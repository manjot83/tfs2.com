using System.ComponentModel.DataAnnotations;
using TFS.Models;

namespace TFS.Web.ViewModels
{
    public class UserViewModel : BaseValidatableEntity
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

        public bool Disabled { get; set; }
    }
}
