using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MeterOff.Core.Models.Infrastructure
{
    public class ConsumerSettlement_Log : BaseEntity
    {
        public int AccountId { get; set; }
        public int ConsumerSettlement_Id { get; set; }
        public DateTime NextInstallmentDate { get; set; }
        public DateTime? LastPaidDate { get; set; }
        public decimal InstallmentValue { get; set; }
        public decimal CurrentBalance { get; set; }
        public string PaymentWay { get; set; }
        public int NumberOfInstallments { get; set; }
        public decimal CurrentReservedValue { get; set; }
        public int PayCashORDeposit { get; set; }
        public decimal RemainingAmount { get; set; }
        public int NumberOfInstallmentsAfter { get; set; }
        public decimal InstallmentValueAfter { get; set; }
        public bool IsSystemAddedAutomically { get; set; }
        public int? ReceiptNo { get; set; }
        public int PosCode { get; set; }
        public int AccountDepartmentCode { get; set; }
        public int AdvancePaymentTypeEnum { get; set; }
        public int? Charges_Id { get; set; }
        [DefaultValue(0)]
        public int NumberOfInstallmentsPaid { get; set; } = 0;

        [MaxLength(30), MinLength(3)]
        public string VisaReceiptNo { get; set; }


        [ForeignKey("ConsumerSettlement_Id")]
        public virtual ConsumerSettlement ConsumerSettlement { get; set; }



    }
}
