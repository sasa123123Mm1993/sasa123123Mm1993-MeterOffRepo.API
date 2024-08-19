using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public class TariffTamper : BaseEntity
    {
        public int TariffId { get; set; }
        public int TamperId { get; set; }
        public decimal Amount { get; set; }

        [ForeignKey("TariffId")]
        public virtual Tariff Tariff { get; set; }
        [ForeignKey("TamperId")]
        public virtual Tamper Tamper { get; set; }
    }
}
