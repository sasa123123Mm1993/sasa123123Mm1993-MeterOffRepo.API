using MeterOff.Core.Models.Base;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public class MeterMaintenanceLog : BaseEntity
    {

        public int MeterId { get; set; }
        public int AccountId { get; set; }
        public DateTime? MeterOffDate { get; set; }
        public DateTime? UploadDate { get; set; }
        public DateTime? MaintenanceDate { get; set; }
        public DateTime? InstallationDate { get; set; }
        [MaxLength(100)]
        public string MeterOffReason { get; set; }
        public decimal ResetMeterBalance { get; set; }
        public bool IsMeterInstalled { get; set; }
        public bool IsMeterReset { get; set; }
        public bool IsMeterTransferToStock { get; set; }

        public int UploadMeterStatusEnum { get; set; }
        public int UploadReasonEnum { get; set; }
        public bool Status { get; set; }

        public int? RecivedEmployeeTechnId { get; set; }
        public int? OldConsumerStatus { get; set; }

        [MaxLength(20)]
        public string CustomerCode { get; set; }


        [ForeignKey("MeterId")]
        public virtual MeterData Meter { get; set; }

        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }
        public string SerialNumber { get; set; }
    }
}
