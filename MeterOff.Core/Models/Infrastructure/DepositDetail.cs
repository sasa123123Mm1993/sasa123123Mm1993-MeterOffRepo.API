using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MeterOff.Models.Enum;
using MeterOff.Core.Models.Enum;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class DepositDetail : BaseEntity
    {
        public string Name { get; set; }
        public bool IsClear { get; set; }
     
        public int AdvancePaymentId { get; set; }
        public int? AdvancePaymentTypeId { get; set; }

     
        public int? EPayPermissionId { get; set; }
        public string Description { get; set; }
        public string Notes { get; set; }
     
        [ForeignKey("AdvancePaymentTypeId")]
        public virtual DepositType AdvancePaymentType { get; set; }
        public AdvancePaymentTypeEnum AdvancePaymentTypeEnum { get; set; }
        public decimal Amount { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal PreviousRemainingAmount { get; set; }
        [MaxLength(50)]
        public string ChequeNo { get; set; }
        [MaxLength(100)]
        public string BankName { get; set; }
        [MaxLength(50)]
        public string EPaymentPermissionNo { get; set; }
        [MaxLength(50)]
        public string MFPCode { get; set; }
        public bool IsUsed { get; set; }
        public DateTime? LastUsedDate { get; set; }
     
        public int? OrderId { get; set; }
     
        public int? ReceiptNo { get; set; }
     
        public int? ExchangeMeterOperationLogId { get; set; }
     
        [ForeignKey("AdvancePaymentId")]
        public virtual Deposit AdvancePayment { get; set; }

     
        [ForeignKey("EPayPermissionId")]
        public virtual EPayPermission EPaymentPermission { get; set; }

        public string TranseferedFromCustomerCode { get; set; }
    }
}
