using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public class TariffFee : BaseEntity
    {
        public int TariffId { get; set; }
        public int FeeId { get; set; }

        [ForeignKey("TariffId")]
        public virtual Tariff Tariff { get; set; }
        [ForeignKey("FeeId")]
        public virtual FeesType Fee { get; set; }
    }
}
