using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Enum
{
    public enum BusinessErrorEnum
    {
        FieldNotExist = 1000,       //رقم الكارت غير موجود بالنظام
        AleardyDeleted = 1001,     //الكارت ممسوح بالفعل
        DeletedSuccessfully = 1002,
        DeletedFailed = 1003,
    }



}
