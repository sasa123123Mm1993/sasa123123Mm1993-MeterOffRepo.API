using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class CurrentReading : CollectionCardBaseEntity //الاستهلاك اللحظي
    {
        public CurrentReading()
        {
            PreviousMeterEvents = new HashSet<MeterEvent>();
            RechargeHistories = new HashSet<MeterChargeHistory>();
            PreviousConsumptions = new HashSet<ConsumerConsumption>();
            CutOffHistories = new HashSet<CutoffHistory>();
            ConsumerConsumptionDetails = new HashSet<ConsumerConsumptionDetail>();

        }
        [MaxLength(50)]
        public string CardNumber { get; set; }
        [MaxLength(10)]
        public string CurrentConsumption { get; set; }
        [MaxLength(10)]
        public string TotalPowerConsumption { get; set; }
        public DateTime? MeterDate { get; set; }
        public decimal RemainingBalance { get; set; }
        public decimal RemainingPower { get; set; }
        [MaxLength(10)]
        public string MeterStatusCode { get; set; }
        public int? BattaryStatusCode { get; set; }
        public decimal TotalRechargeAmount { get; set; }
        public decimal SystemTotalRecharges { get; set; }
        public string CurrentMonth { get; set; }
        public decimal CurrentMonthCharges { get; set; }
        public double TotalDebtAmount { get; set; }
        [MaxLength(20)]
        public string TotalDebtInKW { get; set; }
        [MaxLength(20)]
        public string MaxDemandInKW { get; set; }
        [MaxLength(20)]
        public string MaxDemandInKWTimestamp { get; set; }
        [MaxLength(20)]
        public string MaxDemandInInAmpere { get; set; }
        [MaxLength(20)]
        public string MaxDemandInInAmpereTimestamp { get; set; }
        public decimal PowerFactor { get; set; }
        public int OrderSequence { get; set; }
        public int? TariffId { get; set; }
        public int NoOfCollectedMeters { get; set; }
        public string MeterStatus { get; set; }
        public string SerialNumber { get; set; }
        public virtual ICollection<MeterEvent> PreviousMeterEvents { get; set; }
        public virtual ICollection<MeterChargeHistory> RechargeHistories { get; set; }
        public virtual ICollection<ConsumerConsumption> PreviousConsumptions { get; set; }
        public virtual ICollection<ConsumerConsumptionDetail> ConsumerConsumptionDetails { get; set; }
        public virtual ICollection<CutoffHistory> CutOffHistories { get; set; }
    }
}
