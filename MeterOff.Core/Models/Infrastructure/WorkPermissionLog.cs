using MeterOff.Core.Models.Base;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class WorkPermissionLog : BaseEntity
    {
        public DateTime PrintingDate { get; set; }
        public int AccountId { get; set; }
        public int MeterId { get; set; }


        [ForeignKey("MeterId")]
        public virtual MeterData Meter { get; set; }
        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }

    }
}
