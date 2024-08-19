using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class SettlementType : BaseEntity
    {
        public SettlementType()
        {
            Debits = new HashSet<Settlement>();
            AccountDebits = new HashSet<ConsumerSettlement>();
            CustomerPropertySettlements = new HashSet<CustomerPropertySettlement>();
        }
        [MaxLength(100)]
        public string Name { get; set; }
        public int DebitTypeEnum { get; set; }//percentage
        public int BenefitPercentage { get; set; }
        public int MaxMonths { get; set; }//
        public bool IsMustMaxMonths { get; set; }//
        public decimal DiminishingInterestValue { get; set; }
        public bool IsCheckInstallmentRules { get; set; }
        public int? ReplaceMeterCode { get; set; }
        public virtual ICollection<Settlement> Debits { get; set; }

        public virtual ICollection<ConsumerSettlement> AccountDebits { get; set; }
        public virtual ICollection<CustomerPropertySettlement> CustomerPropertySettlements { get; set; }

    }
}
