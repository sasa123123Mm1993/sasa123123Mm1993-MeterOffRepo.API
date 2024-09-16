using MeterOff.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Infrastructure
{
    public class InstallCardReading : BaseEntity
    {
        public DateTime ReadingDate { get; set; }
        public int? ControlCardOperationTypeEnum { get; set; }


        public int MeterId { get; set; }
        [ForeignKey("MeterId")]
        public MeterData Meter { get; set; }




        public int ControlCardId { get; set; }
        [ForeignKey("ControlCardId")]
        public ControlCard ControlCard { get; set; }
    }
}
