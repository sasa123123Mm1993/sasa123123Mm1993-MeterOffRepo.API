using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public class CompanyHierarchicalDetail : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public int LevelOrder { get; set; }
        //public virtual ICollection<CompanyHierarchical> OrganizationStructures { get; set; }
    }
}
