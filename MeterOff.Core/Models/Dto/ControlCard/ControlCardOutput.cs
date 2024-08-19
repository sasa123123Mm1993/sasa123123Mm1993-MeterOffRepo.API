using MeterOff.Core.Models.Constant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class ControlCardOutput : BaseDto
    {
        public string Name { get; set; }
        public int Code { get; set; }
    }
}
