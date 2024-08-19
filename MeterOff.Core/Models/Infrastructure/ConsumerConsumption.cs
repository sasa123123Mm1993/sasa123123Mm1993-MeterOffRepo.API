using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class ConsumerConsumption : BaseEntity
    {
        public ConsumerConsumption()
        {
            ConsumptionCalculationFees = new HashSet<ConsumerConsumptionFeesCalc>();
        }
        public string Value { get; set; }  //consumption
        public double? Amount { get; set; }
        [MaxLength(10)]
        public string Month { get; set; }
        public int Year { get; set; }
        public string TotalPowerConsumption { get; set; }
        public int InstantaneousReadingId { get; set; }
        public int? TariffId { get; set; }
        public int? AccountId { get; set; }
        public int? MeterId { get; set; }

        public decimal CurrentMonthCharges { get; set; }
        public decimal CustomerServiceFee { get; set; }
        public decimal FirstStepValue { get; set; }
        public decimal FirstStepAmount { get; set; }
        public decimal SecondStepValue { get; set; }
        public decimal SecondStepAmount { get; set; }
        public decimal ThirdStepValue { get; set; }
        public decimal ThirdStepAmount { get; set; }
        public decimal FourthStepValue { get; set; }
        public decimal FourthStepAmount { get; set; }
        public decimal FifthStepValue { get; set; }
        public decimal FifthStepAmount { get; set; }
        public decimal SixthStepValue { get; set; }
        public decimal SixthStepAmount { get; set; }
        public decimal SeventhStepValue { get; set; }
        public decimal SeventhStepAmount { get; set; }
        public double LocalFee { get; set; }
        public double BroadCastMonthlyFee { get; set; }
        public double ConsumptionStamp { get; set; }
        public double QualityStamp { get; set; }
        public double BroadCastBigCustomer { get; set; }
        public double BroadCastInSpecificKw { get; set; }
        public double BroadCastFromKwToKW { get; set; }
        public string MaxDemandInKW { get; set; }

        public double CleanFee { get; set; }
        public double TotalAmount { get; set; }
        public double TotalAmountConsumption { get; set; }
        [ForeignKey("InstantaneousReadingId")]
        public virtual CurrentReading InstantaneousReading { get; set; }
        public virtual ICollection<ConsumerConsumptionFeesCalc> ConsumptionCalculationFees { get; set; }



    }
}
