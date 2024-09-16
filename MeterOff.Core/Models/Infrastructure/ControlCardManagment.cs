using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class ControlCardManagment : BaseEntity
    {
        
        public int ControlCarId { get; set; }

        [ForeignKey("ControlCarId")]
        public virtual ControlCard ControlCard { get; set; }


        public int PropertyId { get; set; }

        [ForeignKey("PropertyId")]
        public virtual CardFunction CardFunction { get; set; }

        
    }
}
