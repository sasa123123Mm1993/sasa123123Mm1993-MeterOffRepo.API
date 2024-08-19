using System.ComponentModel.DataAnnotations.Schema;
using MeterOff.Core.Models.Base;

using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public class MeterChargeHistory : BaseEntity
    {
        [MaxLength(50)]
        public string RechargeTime { get; set; }
        [MaxLength(50)]
        public string RechargeValue { get; set; }
        public int InstantaneousReadingId { get; set; }
        [ForeignKey("InstantaneousReadingId")]
        public virtual CurrentReading InstantaneousReading { get; set; }
    }
}
