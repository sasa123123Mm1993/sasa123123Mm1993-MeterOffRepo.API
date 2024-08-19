namespace MeterOff.Core.Models.Enum
{
    public enum AdvancePaymentTypeEnum
    {
        Cash = 1,
        Cheque = 2,
        Settlement = 3, //تسوية خطأ لصالح العميل
        PullCharge = 4,
        ElectronicPayment = 5,
        MFPCode = 6  /// مدفوعات وزارة الماليه
    }
}
