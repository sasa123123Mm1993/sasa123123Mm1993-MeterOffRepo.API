using MeterOff.Core.Models.Base;
using MeterOff.Models.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class DebitPayment : BaseEntity
    {
        public DebitPayment()
        {
            DebitPaymentDetails = new HashSet<DebitPaymentDetail>();
        }
      
        public int DebitId { get; set; }
        public decimal TotalAmount { get; set; }
        public int InstallmentsCount { get; set; }//عدد الاقساط
        public bool IsHasDiminishingInterest { get; set; } //فائدة تناقصية
        public decimal DiminishingInterestValue { get; set; }
        public decimal DiminishingInterestNet { get; set; }
        //public PaymentTypeEnum PaymentType { get; set; }
        public PaymentStatusEnum Status { get; set; }
        public DateTime FirstDueDate { get; set; }
        public DateTime SettlementDate { get; set; }//تاريخ اصل التسوية
        public bool IsMeterDeduction { get; set; }
        [ForeignKey("DebitId")]
        public virtual Settlement Debit { get; set; }

        public virtual ICollection<DebitPaymentDetail> DebitPaymentDetails { get; set; }
    }
}
