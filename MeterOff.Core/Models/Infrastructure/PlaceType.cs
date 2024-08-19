using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MeterOff.Core.Models.Base;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class PlaceType : BaseEntity
    {
        public PlaceType()
        {
            Accounts = new HashSet<Consumer>();
        }
        [MaxLength(50)]
        public string Name { get; set; }
        public int? TariffTypeId { get; set; }
        public int Code { get; set; }
        [MaxLength(200)]
        public string Notes { get; set; }

        [ForeignKey("TariffTypeId")]
        public virtual ActivityType ActivityType { get; set; }
        public virtual ICollection<Consumer> Accounts { get; set; }
    }
}
