using System.ComponentModel.DataAnnotations;
using TFS.Models;
using System;

namespace TFS.Models.PersonnelRecords
{
    public class Certificate : BaseDomainObject
    {
        public virtual Guid? Id { get; private set; }
        [Required]
        public virtual CertificateType Type { get; set; }
        [Required]
        public virtual string Name { get; set; }
    }
}
