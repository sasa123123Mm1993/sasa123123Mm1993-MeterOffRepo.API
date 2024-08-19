using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class CustomerPropertySettlement : BaseEntity
    {
        public int NoOfInstallment { get; set; }
        public decimal TotalAmount { get; set; }

        public int CustomerPropertyId { get; set; }


        public int SettlementTypeId { get; set; }

        [ForeignKey("CustomerPropertyId")]
        public virtual ConsumerProperity CustomerProperty { get; set; }
        [ForeignKey("SettlementTypeId")]
        public virtual SettlementType SettlementType { get; set; }

    }
}
