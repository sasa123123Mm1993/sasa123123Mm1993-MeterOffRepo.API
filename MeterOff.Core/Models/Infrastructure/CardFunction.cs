using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class CardFunction : BaseEntity
    {
        public CardFunction()
        {
            ControlCardProperties = new HashSet<ControlCardManagment>();
        }
        [MaxLength(50)]
        public string Name { get; set; }
        public int Code { get; set; }
        public virtual ICollection<ControlCardManagment> ControlCardProperties { get; set; }
    }
}
