using MeterOff.Core.Models.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Base
{
    public class CollectionCardBaseEntity : BaseEntity
    {
        public int? MeterId { get; set; }
        public int AccountId { get; set; }
        public DateTime CollectDate { get; set; }
        public bool IsCollectCard { get; set; }

        [ForeignKey("AccountId")]
        public virtual Consumer Account { get; set; }

        [ForeignKey("MeterId")]
        public virtual MeterData Meter { get; set; }
    }
}
