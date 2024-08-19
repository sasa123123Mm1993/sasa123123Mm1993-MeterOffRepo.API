namespace MeterOff.Models.Enum
{
    public enum PaymentTypeEnum
    {
        Monthly = 1,//شهري
        EveryThreeMonth = 2,
        EverySixMonth = 3,
        Annual = 4,//سنوي
        EveryCharge = 5,//كل شحنة
        Other = 6,
        Consumption = 7,//
        ConsumptionOnMeter = 8,//مع كل كيلو بدون حد اقصي
        InSpecificKw = 9,//عند كيلو معين
        FromKwToKw = 10,//مع كل كيلو من ك.و الي ك.و رسوم  
        OneTime = 11,//مرة واحدة
    }
}
