using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class SubstitutionType : BaseEntity
    {
        public SubstitutionType()
        {
           Accounts = new HashSet<Consumer>();
        }
        [MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Consumer> Accounts { get; set; }
    }
}
