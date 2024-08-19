using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MeterOff.Core.Models.Base;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class Transformer : BaseEntity
    {
        public Transformer()
        {
            Accounts = new HashSet<Consumer>();
            TransformerReadings = new HashSet<TransformerReading>();
        }
        [MaxLength(100)]
        public string Code { get; set; }
        [MaxLength(100)]
        public string Address { get; set; }

        public int RegionId { get; set; }

        //[ForeignKey("RegionId")]
        //public virtual CompanyHierarchical OrganizationStructure { get; set; }

        public virtual ICollection<Consumer> Accounts { get; set; }
        public virtual ICollection<TransformerReading> TransformerReadings { get; set; }
    }
}
