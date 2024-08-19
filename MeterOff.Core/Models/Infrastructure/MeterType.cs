using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MeterOff.Core.Models.Base;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class MeterType : BaseEntity
    {
        
        [MaxLength(100)]
        public string Name { get; set; }
        public int Code { get; set; }
        [MaxLength(100)]
        public string MeterTypeClass { get; set; }
        [MaxLength(100)]
        public string MeterTypeModel { get; set; }
      
        [MaxLength(10)]
        public string ManufacturerId { get; set; }
        [MaxLength(10)]
        public string Company { get; set; }
        public decimal MeterPrice { get; set; }
        public decimal CardPrice { get; set; }
        public decimal MeterTypeMaxLoad { get; set; }
        public decimal PowerInVolt { get; set; }
        public decimal PowerInAmpere { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
      
        public Guid Guid { get; set; }

        public virtual ICollection<MeterSettingForm> MeterTypeConfigurationTemplates { get; set; }
    }
}
