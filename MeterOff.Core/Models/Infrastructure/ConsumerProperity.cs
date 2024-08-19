using MeterOff.Core.Models.Base;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class ConsumerProperity : BaseEntity
    {
        public ConsumerProperity()
        {
            CustomerPropertySettlements = new HashSet<CustomerPropertySettlement>();
        }

        public int? CustomerTypeId { get; set; }
        public int? TariffTypeId { get; set; }
        public int? MeterReplacementTypeId { get; set; }
        public int? DebitTypeId { get; set; }
        public decimal DebitAmount { get; set; }
        public int NoOfInstallment { get; set; }
        public int initalBalance { get; set; }

        public virtual ActivityType ActivityType { get; set; }
        public virtual SettlementType DebitType { get; set; }
        public virtual ConsumerType CustomerType { get; set; }
        public virtual SubstitutionType MeterReplacementType { get; set; }

        public virtual ICollection<CustomerPropertySettlement> CustomerPropertySettlements { get; set; }
    }
}
