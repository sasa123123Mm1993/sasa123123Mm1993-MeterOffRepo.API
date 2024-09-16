using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Enum
{
     public enum MeterOffMaintenanceEnum
    {
        Installed = 1, // العداد مركب  
        DeliveredToTechinical = 2,// العداد مسلم للفني
        Finished = 3, // منتهى  
        Disabled = 4 // معطل  
    }
}
