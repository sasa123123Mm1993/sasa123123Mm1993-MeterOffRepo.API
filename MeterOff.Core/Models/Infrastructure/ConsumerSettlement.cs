using MeterOff.Core.Models.Base;
using MeterOff.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public class ConsumerSettlement : BaseEntity
    {
      
        public int AccountId { get; set; }
      
        public int DebitTypeId { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAmountWithInterest { get; set; }
        public decimal RemainingAmount { get; set; }
        public DateTime DebitDate { get; set; }
        public PaymentStatusEnum Status { get; set; }
        public int NumberOfInstallments { get; set; }
        public decimal InstallmentValue { get; set; }
        public DateTime NextInstallmentDate { get; set; }
        public DateTime? LastPaidDate { get; set; }

        public bool IsSystemAddedAutomically { get; set; }
        public string Notes { get; set; }
      
        public int? ExchangeMeterOperationLogId { get; set; }

        public int RemainingNumberOfInstallment { get; set; }

        public decimal TotalAllPaidValue { get; set; }
        public int? PosChargeId { get; set; }
        public int? CustomerPropertySettlementId { get; set; }

        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }

        [ForeignKey("DebitTypeId")]
        public virtual SettlementType DebitType { get; set; }
        public virtual ICollection<ConsumerSettlement_Log> ConsumerSettlement_Logs { get; set; }

    }
}
