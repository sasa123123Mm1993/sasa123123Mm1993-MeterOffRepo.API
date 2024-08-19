using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class Tamper : BaseEntity
    {
        public Tamper()
        {
            AccountTampers = new HashSet<ConsumerTamper>();
            TariffTampers = new HashSet<TariffTamper>();
        }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Notes { get; set; }
        [MaxLength(100)]
        public string Code { get; set; }
        public decimal Amount { get; set; }
        public bool IsMustPay { get; set; }
        public bool IsAvailableInCharge { get; set; }
        public bool IsStopRecharge { get; set; }
        public virtual ICollection<ConsumerTamper> AccountTampers { get; set; }
        public virtual ICollection<TariffTamper> TariffTampers { get; set; }
    }
}
