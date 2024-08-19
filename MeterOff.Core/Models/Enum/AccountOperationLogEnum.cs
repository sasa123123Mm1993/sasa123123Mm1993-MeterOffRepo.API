namespace MeterOff.Core.Models.Enum
{
    public enum AccountOperationLogEnum
    {
        OpenAccount = 1,//فتح حساب
        WriteCustomerCard = 2,//كتابة كارت المشترك
        InitialBalanceReturn = 3,//استرجع الشحنة الإبتدائية
        CheckCustomerCard = 4,//فحص كارت المشترك بعد التهيئة
        ReadCardCustmerOrControlLanchOrInstallationDateReturn = 5,//قراءة الكارت المشترك كارت اطلاق التيار رجوع تاريخ التركيب
        SaveRecharge = 6,//الشحن
        ReplaceCardWithOutRecharge = 7,//بدل فاقد بدون شحن
        ReplaceCardWithRecharge = 8,// بدل فاقد بشحن
        CancelRechargeFromCustomerCard = 9,//الغاء سحب الشحنة
        PullRechargerFromCustomerCard = 10,// سحب الشحنة من كارت المشترك
        CancelRechargeFromReplaceCard = 11,//الغاء الشحنة من كارت المشترك    
        PullRechargerFromReplaceCard = 12, //سحب الشحنة من الكارت البديل
        EndAccount = 19,// انهاء اشتراك

        CancelEndAccount = 20,//الغاء انهاء اشتراك
        UpdateAccountData = 22, //تعديل بيانات مشترك
        RemoveInitialBalance = 23, //إزالة الشحنة الإبتدائية
        RemoveInitialBalanceWithoutCard = 24, //إزالة الشحنة الإبتدائية بدون كارت
        WriteCardFromRecharge = 25,//الشحن

        ChangeMeter = 13, // تغير عداد
        CancelChangeMeter = 14,//الغاء تغير عداد

        ReplaceMeter = 15, //استبدال عداد
        CancelReplaceMeter = 16, //إلغاء استبدال عداد

        ResetDisabledMeter = 17,  //إعادة تهيئة عداد معطل
        CancelResetDisabledMeter = 18, //الغاء إعادة تهيئة عداد معطل

        CopyMeterDataByCard = 26,
        CancelCopyMeterDataByCard = 27,

        CopyMeterDataByOptical = 28,
        CancelCopyMeterDataByOptical = 29,

        CopyMeterDataBySpecialDevice = 30,
        CancelCopyMeterDataBySpecialDevice = 31,

        InceaseAccountMeterPower = 32,
        CancelInceaseAccountMeterPower = 33,


        GiveUpMeter = 21,  //تنازل عن عداد
        MeterSteal = 34, //سرقة عداد
        MeterMaintenance = 35  //تعطيل عداد
    }
}
