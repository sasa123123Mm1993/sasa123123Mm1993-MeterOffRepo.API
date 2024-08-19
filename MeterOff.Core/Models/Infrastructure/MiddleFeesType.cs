using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using MeterOff.Core.Models.Base;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class MiddleFeesType : BaseEntity
    {
        public MiddleFeesType()
        {
            ContractFees = new HashSet<MiddleFee>();
        }
        [MaxLength(50)]
        public string Name { get; set; }

        public decimal Amount { get; set; }

        public int MeterTypeId { get; set; }

        [ForeignKey("MeterTypeId")]

        public virtual MeterType MeterType { get; set; }

        public virtual ICollection<MiddleFee> ContractFees { get; set; }
    }
}
