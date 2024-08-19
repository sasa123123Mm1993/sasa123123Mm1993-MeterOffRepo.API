using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Constant
{
    public class BaseDto
    {
        public BaseDto()
        {
        }
        public BaseDto(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

    }
}
