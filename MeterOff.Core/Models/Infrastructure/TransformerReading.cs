using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.Xml;

namespace MeterOff.Core.Models.Infrastructure
{
    public class TransformerReading : BaseEntity
    {
        public int RegionId { get; set; }
        public int TransformerId { get; set; }
        public double ReadingValue { get; set; }
        public DateTime ReadingDate { get; set; }

        //[ForeignKey("RegionId")]
        //public virtual CompanyHierarchical OrganizationStructure { get; set; }

        [ForeignKey("TransformerId")]
        public virtual Transformer TransformerMeter { get; set; }
    }
}
