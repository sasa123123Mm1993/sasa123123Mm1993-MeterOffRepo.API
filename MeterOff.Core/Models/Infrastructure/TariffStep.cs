using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class TariffStep : BaseEntity
    {
        public int? TariffId { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public decimal Price { get; set; }
        public decimal ServicePrice { get; set; }
        public bool IsRecalculated { get; set; }
        public decimal? SangenRecalculatedEdge { get; set; }
        public decimal? SangenRecalculatedAmount { get; set; }
        public decimal? InitialAmount { get; set; }
        public decimal? InitialValue { get; set; }
        public bool IsSystemcalculation { get; set; }
        [ForeignKey("TariffId")]
        public virtual Tariff Tariff { get; set; }
    }
}
