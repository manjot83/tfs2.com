using System.ComponentModel.DataAnnotations;
using TFS.Models;

namespace TFS.Models.PersonnelRecords
{
    public class Certificate : BaseEntity
    {
        public virtual int? Id { get; private set; }
        [Required]
        public virtual CertificateType Type { get; set; }
        [Required]
        public virtual string Name { get; set; }
    }
}
