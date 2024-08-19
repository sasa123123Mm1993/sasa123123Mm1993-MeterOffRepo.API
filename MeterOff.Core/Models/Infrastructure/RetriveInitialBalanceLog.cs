
using MeterOff.Core.Models.Base;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class RetriveInitialBalanceLog : BaseEntity
    {
        public int AccountId { get; set; }
        public int? MeterId { get; set; }
        public decimal? InitialBalanceValue { get; set; }
        public int? RemovedBy { get; set; }

        public DateTime RemoveDate { get; set; }

    }
}
