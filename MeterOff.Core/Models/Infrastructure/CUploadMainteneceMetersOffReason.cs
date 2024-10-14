using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public class CUploadMainteneceMetersOffReason : BaseEntity
    {
       
        public int Code { get; set; }
        [MaxLength(70)]
        public string Name { get; set; }
        public string? Note { get; set; }
    }
}
