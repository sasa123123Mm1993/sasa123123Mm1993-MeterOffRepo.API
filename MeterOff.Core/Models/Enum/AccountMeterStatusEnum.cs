using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Enum
{
    public enum AccountMeterStatusEnum
    {
        AccountWithInitialMeter = 1, //بعد الضغط علي اضافة حساب جديد لعميل جديد
        AccountWithInitialMeterAndOpenCard = 2, //بعد انشاء كارت عميل
        AccountHasNewMeterAndOneRecharge = 3,//بعد قراءة كارت العميل وهو لديه شحنة ابتدائية فقط
        AccountAfterRemovingInitialBalance = 4,//بعد ازالة الشحنة الابتدائية
        AccountInFieldWithMoreThanOneRecharge = 5,//بعد كتابة الشحنة الثانية علي الكارت
        ResetMeter = 6 //عداد معاد تهيئتة من جديد
    }
}
