using System.ComponentModel.DataAnnotations;

namespace TFS.Models.FlightPrograms
{
    public class Position : BaseDomainObject
    {
        public virtual int? Id { get; private set; }

        [DomainEquality]
        [Required, StringLength(50)]
        public virtual string Title { get; set; }
    }
}
