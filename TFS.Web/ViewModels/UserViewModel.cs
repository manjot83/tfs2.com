using System.ComponentModel.DataAnnotations;
using Centro.DomainModel;

namespace TFS.Web.ViewModels
{
    public class UserViewModel : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string DisplayName { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public bool Disabled { get; set; }
    }
}
