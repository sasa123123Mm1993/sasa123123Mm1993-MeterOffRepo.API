using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GPICardCore.Customer
{
    public delegate void CardCreatedHandler (CustomerCardBuilder customerCard);
    
    public class CustomerCardBuilder
    {
        private string MeterType { get; set; }
        private string MeterVersion { get; set; }
        private string ManufacturerId { get; set; }
        private string CardId { get; set; }
        private string CustomerId { get; set; }
        private CustomerCardType CardType { get; set; }
        private string CustomerOperationType { get; set; }
        private string InstallingMode { get; set; }
        private string CustomerRechargeCardCanRemoveFaultsAndManipulations { get; set; }
        private List<string> Holidays { get; set; }
        private FriendlyTime FriendlyTime { get;  set; }
        private MaxLoadSetting MaxLoadSettings { get; set; }
        private ReChargeDetail RechargeDetails { get; set; }
        private string BillingDay { get; set; }
        private List<int> FeesAmounts { get; set; }
        private decimal ZeroConsumptionFeeAmount { get; set; }
        private TotalDebt TotalDebt { get; set; }
        private List<TariffStep> TariffsDetails { get; set; }
        private int Extrafeeskwh { get; set; }
        private decimal Extrafeesprice { get; set; }
        private string SlidingIntervalDeductionDetails { get; set; }
        private List<SpecificDeductionDetail> SpecificDeductionDetails { get; set; }
        private decimal ExtraFeeEveryKWH { get; set; }
        private List<int> BalanceAlarmCutoffLimits { get; set; }
        private QuiteTime QuiteTime { get; set; }
        private GracePeriod GracePeriod { get; set; }
        private int CardDataStatus { get; set; }
        private int ResetMeterMode { get; set; }
        private List<int> WeekOffDays { get; set; }
        private string DistributionCompanyCode { get; set; }
        private string SectorCode { get; set; }
        private int CustomerServiceMethod { get; set; }


        public event CardCreatedHandler OnCardCreated;

        public string CardXML { get; set; }


        public void SetMeterType(string meterType)
        {
            this.MeterType = meterType;
        }

        public void SetMeterVersion(string meterVersion)
        {
            this.MeterVersion = meterVersion;
        }

        public void SetManufacturerId(string manufacturerId)
        {
            this.ManufacturerId = manufacturerId;
        }

        public void SetCardId(string cardId)
        {
            this.CardId = cardId;
        }

        public void SetCustomerId(string customerId)
        {
            this.CustomerId = customerId;
        }

     

        public void SetCustomerOperationType(string customerOperationType)
        {
            this.CustomerOperationType = customerOperationType;
        }

        public void SetInstallingMode(string installingMode)
        {
            this.InstallingMode = installingMode;
        }

        public void SetCustomerRechargeCardCanRemoveFaultsAndManipulations(string value)
        {
            this.CustomerRechargeCardCanRemoveFaultsAndManipulations = value;
        }

        public void SetHolidays(List<string> holidays)
        {
            this.Holidays = holidays;

           var holidaysTag =  this.defaultXml.Root.Element("holidays");

            foreach (var item in holidays)
            {
                holidaysTag.Add(new XElement("holidayDate", item));
            }

            

        }

        public void SetFriendlyTime( FriendlyTime friendlyTime)
        {
            this.FriendlyTime = friendlyTime;

            var friendlyTimeTag = this.defaultXml.Root.Element("friendlyTime");

            friendlyTimeTag.Add(new XElement("friendlyStartHour", friendlyTime.StartHour));
            friendlyTimeTag.Add(new XElement("friendlyEndHour", friendlyTime.EndHour));

        }

        public void SetMaxLoadSettings(MaxLoadSetting maxLoadSettings)
        {
            this.MaxLoadSettings = maxLoadSettings;

            var maxLoadSettingsTag = this.defaultXml.Root.Element("maxLoadSettings");

            maxLoadSettingsTag.Add(new XElement("maxLoad", maxLoadSettings.MaxLoad));
            maxLoadSettingsTag.Add(new XElement("maxNumberOfCutoffs", maxLoadSettings.MaxNumberOfCutOFF));

        }

        public void SetRechargeDetails(ReChargeDetail rechargeDetails)
        {
            this.RechargeDetails = rechargeDetails;

         
            var rechargeDetailsTag = this.defaultXml.Root.Element("rechargeDetails");

            rechargeDetailsTag.Add(new XElement("rechargeSequence", rechargeDetails.Sequence ));
            rechargeDetailsTag.Add(new XElement("rechargeAmount", rechargeDetails.Amount));
            rechargeDetailsTag.Add(new XElement("rechargeTime", rechargeDetails.RechargeTime.ToString("dd-MM-yyyy HH:mm")));


        }

        public void SetBillingDay(string billingDay)
        {
            this.BillingDay = billingDay;
        }

        public void SetFeesAmounts(List<int> feesAmounts)
        {
            this.FeesAmounts = feesAmounts;

            var feesAmountsTag = this.defaultXml.Root.Element("feesAmounts");

            foreach (var item in feesAmounts)
            {
                feesAmountsTag.Add(new XElement("feeAmount", item));
            }

        }

        public void SetZeroConsumptionFeeAmount(decimal zeroConsumptionFeeAmount)
        {
            this.ZeroConsumptionFeeAmount = zeroConsumptionFeeAmount;
        }

        public void SetTotalDebt(TotalDebt totalDebt)
        {
            this.TotalDebt = totalDebt;
            var totalDebtTag = this.defaultXml.Root.Element("totalDebt");

            if (IsNotNullAndNonNegative<int>(totalDebt.Amount) )
            {
                totalDebtTag.Add(new XElement("totalDebtAmount", totalDebt.Amount) );
            }

            if (IsNotNullAndNonNegative<int>(totalDebt.KW))
            {
                totalDebtTag.Add(new XElement("totalDebtInKW", totalDebt.KW));
            }

            if (IsNotNullAndNonNegative<int>(totalDebt.Limit))
            {
                totalDebtTag.Add(new XElement("debtAmountLimit" , totalDebt.Limit));
            }

        }

        private bool IsNotNullAndNonNegative<T>(T? number) where T : struct, IComparable
        {
            if (number.HasValue)
            {
                return number.Value.CompareTo(default(T)) >= 0;
            }
            return false;
        }



        public void SetTariffsDetails(List<TariffStep> tariffSteps)
        {

            var tariffsDetailsTag = this.defaultXml.Root.Element("tariffsDetails");

            tariffsDetailsTag.Add(
                new XElement("tariffDetails",
                    new XElement("tariffId", 22),
                    new XElement("tariffVersion"),
                    new XElement("tariffGraceType", 1),
                    new XElement("tariffGracevalue", 10),
                    new XElement("tariffAlarmGrace", 200),
                    new XElement("tariffLimitGrace", 300),
                    new XElement("tariffDeductionGrace", 55),
                    new XElement("tariffSteps",
                        new List<XElement>()
                    )
                )
            );

            foreach (var step in tariffSteps)
            {
                tariffsDetailsTag.Element("tariffDetails").Element("tariffSteps").Add(
                    new XElement("tariffStep",
                        new XElement("tariffStepNumber", step.TariffStepNumber),
                        new XElement("tariffStepLimitFrom", step.TariffStepLimitFrom),
                        new XElement("tariffStepLimitTo", step.TariffStepLimitTo),
                        new XElement("tariffStepPrice", step.TariffStepPrice),
                        new XElement("tariffStepCustomerServiceFee", step.TariffStepCustomerServiceFee == 0 ? null : (decimal?)step.TariffStepCustomerServiceFee),
                        new XElement("tariffStepRecalculationEdge", step.TariffStepRecalculationEdge),
                        new XElement("tariffStepRecalculationEdgeAddedAmount", step.TariffStepRecalculationEdgeAddedAmount)
                    )
                );
            }

           
        }


        public void SetExtrafeeskwh(int extrafeeskwh)
        {
            this.Extrafeeskwh = extrafeeskwh;

            this.defaultXml.Root.Element("extrafeeskwh").Value = extrafeeskwh.ToString();

        }

        public void SetExtraFeesPrice(decimal extrafeesprice)
        {
            this.Extrafeesprice = extrafeesprice;
            this.defaultXml.Root.Element("extrafeesprice").Value =
            extrafeesprice.ToString();
        }


        public void SetSlidingIntervalDeductionDetails(List<SlidingIntervalDeductionDetail> details)
        {
            var slidingIntervalDeductionDetailsTag = this.defaultXml.Root.Element("slidingIntervalDeductionDetails");

           

            foreach (var detail in details)
            {
                var slidingIntervalDeductionDetail = 
                    new XElement("slidingIntervalDeductionDetail",
                    new XElement("slidingIntervaNumber", detail.IntervaNumber),
                    new XElement("slidingIntervalLimitFrom", detail.LimitFrom),
                    new XElement("slidingIntervalLimitTo", detail.LimitTo),
                    new XElement("slidingIntervalPrice", detail.Price)
                );

                slidingIntervalDeductionDetailsTag.Add(slidingIntervalDeductionDetail);
            }

        }

      


        public void SetSpecificDeductionDetails(List<SpecificDeductionDetail> deductionDetails)
        {
            this.SpecificDeductionDetails = deductionDetails;

            var specificDeductionDetailsTag = this.defaultXml.Root.Element("specificDeductionDetails");
                       
            foreach (var detail in deductionDetails)
            {
                var specificDeductionDetail = new XElement("specificDeductionDetail",
                    new XElement("specificStepNumber", detail.StepNumber),
                    new XElement("specificDeductionLimit", detail.Limit),
                    new XElement("specificDeductionPrice", detail.Price)
                );

                specificDeductionDetailsTag.Add(specificDeductionDetail);
            }
        }


        public void SetExtraFeeEveryKWH(decimal extraFeeEveryKWH)
        {
            if (IsNotNullAndNonNegative<decimal>(extraFeeEveryKWH))
            {
                this.ExtraFeeEveryKWH = extraFeeEveryKWH;
                
            }
            else {
                throw new Exception($"Extra Fee Every KWH [{extraFeeEveryKWH}] Invalid Value .");
            }
           
        }

        public void SetBalanceAlarmCutoffLimits(List<int> CutoffLimits)
        {
            this.BalanceAlarmCutoffLimits = CutoffLimits;

            var BalanceAlarmCutoffLimitsTag = this.defaultXml.Root.Element("balanceAlarmCutoffLimits");

            foreach (var item in CutoffLimits)
            {
                BalanceAlarmCutoffLimitsTag.Add(new XElement("cutoffAlarmLimitBalance", item));
            }



        }

        public void SetQuiteTime(QuiteTime quiteTime)
        {
            this.QuiteTime = quiteTime;

            var quiteTimeTag = this.defaultXml.Root.Element("quiteTime");
            quiteTimeTag.Add(new XElement("quiteTimeStartHour", quiteTime.Start));
            quiteTimeTag.Add(new XElement("quiteTimeEndHour", quiteTime.End));
       
        }

        public void SetGracePeriod(GracePeriod gracePeriod)
        {
            this.GracePeriod = gracePeriod;

            var gracePeriodTag = this.defaultXml.Root.Element("gracePeriod");
            gracePeriodTag.Add(new XElement("graceType", gracePeriod.Type));
            gracePeriodTag.Add(new XElement("graceValue", gracePeriod.Value));
        }

        public void SetCardDataStatus(int cardDataStatus)
        {
            this.CardDataStatus = cardDataStatus;
        }

        public void SetResetMeterMode(int resetMeterMode)
        {
            this.ResetMeterMode = resetMeterMode;
        }

        public void SetWeekOffDays(List<int> weekOffDays)
        {
            this.WeekOffDays = weekOffDays;

            var weekOffDaysTag = this.defaultXml.Root.Element("weekOffDays");

            foreach (var item in weekOffDays)
            {
                weekOffDaysTag.Add(new XElement("weekOffDay", item));
            }
        }

        public void SetDistributionCompanyCode(string distributionCompanyCode)
        {
            this.DistributionCompanyCode = distributionCompanyCode;
        }

        public void SetSectorCode(string sectorCode)
        {
            this.SectorCode = sectorCode;
        }

        public void SetCustomerServiceMethod(int customerServiceMethod)
        {
            this.CustomerServiceMethod = customerServiceMethod;
        }



        private void SetDefaultValues(XDocument local)
        {
            local.Root.Element("meterType").Value = this.MeterType ;
            local.Root.Element("meterVersion").Value = this.MeterVersion ;
            local.Root.Element("manufacturerId").Value = this.ManufacturerId ;
            local.Root.Element("cardId").Value = this.CardId ;
            local.Root.Element("customerId").Value = this.CustomerId ;
            local.Root.Element("cardType").Value = this.CardType.ToString() ;
            local.Root.Element("customerOperationType").Value = this.CustomerOperationType ;
            local.Root.Element("installingMode").Value = this.InstallingMode ;
            local.Root.Element("customerRechargeCardCanRemoveFaultsAndManipulations").Value = this.CustomerRechargeCardCanRemoveFaultsAndManipulations ;
            local.Root.Element("billingDay").Value = this.BillingDay ;
            local.Root.Element("zeroConsumptionFeeAmount").Value = this.ZeroConsumptionFeeAmount.ToString();
            local.Root.Element("extraFeeEveryKWH").Value = this.ExtraFeeEveryKWH.ToString() ;
            local.Root.Element("cardDataStatus").Value = this.CardDataStatus.ToString() ;
            local.Root.Element("resetMeterMode").Value = this.ResetMeterMode.ToString() ;
            local.Root.Element("distributionCompanyCode").Value = this.DistributionCompanyCode ;
            local.Root.Element("sectorCode").Value = this.SectorCode ;
            local.Root.Element("customerServiceMethod").Value = this.CustomerServiceMethod.ToString() ;
        }



        private XDocument defaultXml = new XDocument(
           new XElement("meterData",
           new XElement("meterType"),
           new XElement("meterVersion"),
           new XElement("manufacturerId"),
           new XElement("cardId"),
           new XElement("customerId"),
           new XElement("cardType",0),
           new XElement("customerOperationType"),
           new XElement("installingMode"),
           new XElement("customerRechargeCardCanRemoveFaultsAndManipulations"),
           new XElement("holidays"),
           new XElement("friendlyTime"),
           new XElement("maxLoadSettings"),
           new XElement("rechargeDetails"),
           new XElement("billingDay"),
           new XElement("feesAmounts"),
           new XElement("zeroConsumptionFeeAmount"),
           new XElement("totalDebt"),
           new XElement("tariffsDetails"),
           new XElement("extrafeeskwh"),
           new XElement("extrafeesprice"),
           new XElement("slidingIntervalDeductionDetails"),
           new XElement("specificDeductionDetails"),
           new XElement("extraFeeEveryKWH"),
           new XElement("balanceAlarmCutoffLimits"),
           new XElement("quiteTime"),
           new XElement("gracePeriod"),
           new XElement("cardDataStatus"),
           new XElement("resetMeterMode"),
           new XElement("weekOffDays"),
           new XElement("distributionCompanyCode"),
           new XElement("sectorCode"),
           new XElement("customerServiceMethod")
       )
     );





        public string BuildOpenAccountCard()
        {
            

            XDocument local = new XDocument(this.defaultXml);

            SetDefaultValues(local);

            this.CardXML = local.ToString();
            this.CardType = CustomerCardType.OpenAccount;
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }

















    }
}
