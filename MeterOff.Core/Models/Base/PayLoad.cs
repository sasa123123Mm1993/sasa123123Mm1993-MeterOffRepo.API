using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Base
{
    public class PayLoad<TModel> where TModel : class
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public TModel? Model { get; set; }
    }

    
}
