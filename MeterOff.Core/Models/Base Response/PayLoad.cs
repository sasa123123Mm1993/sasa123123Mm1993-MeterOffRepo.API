using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Base
{
    public class PayLoad<TModel> where TModel : class
    {
        public bool Success { get; set; }
        public List<string> Errors { get; set; }
        public int Code { get; set; } // For custom business errors
        public string Message { get; set; }
        public TModel? Model { get; set; }

    }



  
   

}
