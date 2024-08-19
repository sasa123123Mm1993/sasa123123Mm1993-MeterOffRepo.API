using MeterOff.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.MeterOffReasons
{
    public class UploadMeterOffReasonDetails : BaseEntity
    {
        public int Code { get; set; }
        public string Name { get; set; }
    }
}
