using MeterOff.Core.Models.Base;
using MeterOff.Models.Enum;
using System.ComponentModel.DataAnnotations;
using MeterOff.Core.Models.Enum;

namespace MeterOff.Core.Models.Infrastructure
{
    public class EPayPermission : BaseEntity
    {
        [MaxLength(50)]
        public string EPayPermissionNumber { get; set; }
        [MaxLength(50)]
        public string EnterpriseName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        [MaxLength(300)]
        public string Notes { get; set; }

        public EPaymentTypeEnum EPaymentTypeEnum { get; set; }
        [MaxLength(50)]
        public string ChequeNo { get; set; }
        [MaxLength(50)]
        public string BankName { get; set; }
        [MaxLength(50)]
        public string MFPCode { get; set; }
    }
}
