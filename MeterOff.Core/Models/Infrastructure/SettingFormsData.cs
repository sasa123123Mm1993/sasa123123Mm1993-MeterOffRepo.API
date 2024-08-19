using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class SettingFormsData : BaseEntity
    {
      
        public int MeterTemplateId { get; set; }
        public bool IsReadBalanceInChangeMeter { get; set; }

        public bool IsMeterDisablewhenchanging { get; set; }
        public int FriendlyStartHour { get; set; }
        public int FriendlyEndHour { get; set; }
        public int QuiteStartHour { get; set; }
        public int QuiteEndHour { get; set; }
        public double MaxLoad { get; set; }
        public int MaxNumberOfCutoffs { get; set; }
        public DateTime BillingDay { get; set; }
        public decimal FirstCutoffAlarmLimitBalance { get; set; }
        public decimal SecondCutoffAlarmLimitBalance { get; set; }
        public DateTime MeterTimeStapToSet { get; set; }
        [MaxLength(100)]
        public string HHFwVersion { get; set; }
        [MaxLength(100)]
        public string HHFwName { get; set; }
        public string CMSIP { get; set; }
        public bool IsCanRemoveInitialBalance { get; set; }
        public bool IsCysheildCard { get; set; }
        public bool IsCmsUpdated { get; set; }
        public bool IsEFUseCysheildCard { get; set; }
        public bool IsConsumptionTamperBlock { get; set; }
        public bool IsDailyPrecedesReferenceAddress { get; set; }

        public bool IsMeterDateInFuture { get; set; }
        public int MaxMonthDeferDate { get; set; }
        public bool IsDebitDueDateNextDate { get; set; }
        public bool IsSetDateTimeWithOpenAccount { get; set; }
        public bool IsDeductFeesexceptionWithZeroConsumption { get; set; }
        public bool IsUpdateInitalBalanceWithOpenAccount { get; set; }
        public bool IsTariffDifferanceDeductAtNextMonth { get; set; }
        public bool IsActivityTypeCodeAddedToConsumerRefference { get; set; }
        public bool IsCommercialSectorCodeAddedToConsumerRefference { get; set; }
        public string Notes { get; set; }
        public int GarceType { get; set; } //قيمة اعادة التهيئة بالشحنة الابتدائية
        [MaxLength(10)]
        public string GraceValue { get; set; } //فترة تجديد كروت الفنين بالايام
        public int StopChargePeriodInDays { get; set; } //فترة تجديد كروت الفنين بالايام
        [MaxLength(800)]
        public string UcsToken { get; set; }

        [MaxLength(800)]
        public string DirectToken { get; set; }

        [MaxLength(800)]
        public string InDirectToken { get; set; }


        [MaxLength(100)]
        public string DirectPw { get; set; }
        [MaxLength(100)]
        public string IndirectPw { get; set; }
        [MaxLength(100)]
        public string ServicePw { get; set; }
        [MaxLength(10)]
        public string GenericSpecificationType { get; set; }
        public int MeterSerialFrom { get; set; }
        public int MeterSerialTo { get; set; }
        public decimal DebtAmountLimit { get; set; }
        public decimal hoardMoneyLimit { get; set; }
        public int InstallingMode { get; set; }
        public int CancelOrPullChargePeriodInDays { get; set; } //عدد الايام المسموح بها لالغاء الشحنة صفر تعني انه لابد ان تكون في نفس اليوم

        public int MaxDaysforpaydebts { get; set; }
        public virtual SettingForm MeterTemplate { get; set; }
        public string ProfileUid { get; set; }
        public string DirectUsername { get; set; }
        public string IndirectUsername { get; set; }
        public string ServiceUsername { get; set; }

        public int DuringRescheduling { get; set; }
        public bool IsDelayDebitCharge { get; set; }
        public int NoOfMaxInvalidLogin { get; set; }

    }
}
