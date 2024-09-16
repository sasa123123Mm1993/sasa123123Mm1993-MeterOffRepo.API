using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MeterOff.Core.Models.Enum;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class MeterData : BaseEntity
    {
        public string? SerialNumber { get; set; }
        public int MeterTypeId { get; set; }
        public int OrderSequence { get; set; }
        [MaxLength(100)]
        public string? VersionNumber { get; set; }
        [MaxLength(100)]
        public string? ManufactureCompany { get; set; }
        [MaxLength(100)]
        public string? CardNumber { get; set; }
        [MaxLength(100)]
        public string? PaymentReceiptNumber { get; set; }
        public MeterStatusEnum Status { get; set; }
        public DateTime? MeterOffDate { get; set; }
        public DateTime? UploadDate { get; set; }
        public DateTime? MaintenanceDate { get; set; }
        public DateTime? InstallationDate { get; set; }
        [MaxLength(100)]
        public string? MeterOffReason { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
      
        public Guid Guid { get; set; }
        public Guid CysheildCardUid { get; set; }

        [ForeignKey("MeterTypeId")]
        public virtual MeterType MeterType { get; set; }

    }
}
