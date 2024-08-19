using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class EditChargeLog : BaseEntity
    {
        public int MainOrderId { get; set; }
        public int SubOrderId { get; set; }
        
       
    }
}
