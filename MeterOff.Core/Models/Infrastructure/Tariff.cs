using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MeterOff.Core.Models.Base;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class Tariff : BaseEntity
    {
        public Tariff()
        {
            TariffSteps = new HashSet<TariffStep>();
            Accounts = new HashSet<Consumer>();
            ConsumptionCalculationFees = new HashSet<ConsumerConsumptionFeesCalc>();
            TariffFees = new HashSet<TariffFee>();
            TariffTampers = new HashSet<TariffTamper>();
        }
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime ActivationDate { get; set; }
        public int TariffTypeId { get; set; }
        public decimal ZeroReading { get; set; }
        public bool CustomerServiceMethod { get; set; }
        public int? OrganizationStructureId { get; set; }
        public int TariffCode { get; set; }

        //[ForeignKey("OrganizationStructureId")]
        //public virtual CompanyHierarchical OrganizationStructure { get; set; }

        [ForeignKey("TariffTypeId")]
        public virtual ActivityType ActivityType { get; set; }
        public virtual ICollection<TariffStep> TariffSteps { get; set; }
        public virtual ICollection<Consumer> Accounts { get; set; }
        public virtual ICollection<ConsumerConsumptionFeesCalc> ConsumptionCalculationFees { get; set; }
        public virtual ICollection<TariffFee> TariffFees { get; set; }
        public virtual ICollection<TariffTamper> TariffTampers { get; set; }


    }
}
