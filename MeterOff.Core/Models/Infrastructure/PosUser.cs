
using MeterOff.Core.Models.Base;

namespace MeterOff.Core.Models.Infrastructure
{
    public class PosUser : BaseEntity
    {
        public int PointOfSaleId { get; set; }
        public int UserId { get; set; }
    }
}
