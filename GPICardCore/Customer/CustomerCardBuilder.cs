using GPICardCore.Master;
using System.Xml.Linq;

namespace GPICardCore.Customer
{
    public delegate void CardCreatedHandler (CustomerCardBuilder customerCard);
    
    public class CustomerCardBuilder
    {
        private int MeterType { get; set; }
        private string MeterId { get; set; }
        private string MeterVersion { get; set; }
        private string ManufacturerId { get; set; }
        private string CardId { get; set; }
        private string CustomerId { get; set; }
        private int  CardType { get; set; }
        private int CustomerOperationType { get; set; }
        private int InstallingMode { get; set; }
        private int DateAndTimeMode { get; set; }
        private string OldCardId { get; set; }
        private int CustomerRechargeCardCanRemoveFaultsAndManipulations { get; set; }
        private List<string> Holidays { get; set; }
        private FriendlyTime FriendlyTime { get;  set; }
        private MaxLoadSetting MaxLoadSettings { get; set; }
        private RechargeDetails RechargeDetails { get; set; }
        private string BillingDay { get; set; }
        private List<decimal> FeesAmounts { get; set; }
        private decimal ZeroConsumptionFeeAmount { get; set; }
        private TotalDebt TotalDebt { get; set; }
        private List<TariffStep> TariffsDetails { get; set; }
        private decimal Extrafeeskwh { get; set; }
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
        public string ControlOperationType { get; private set; }
        public string MeterWillDeductInstallments { get; private set; }
        public decimal HoardMoneyLimit { get; private set; }
        public decimal CurrentInBalanceConsumption { get; private set; }
        public decimal CurrentReverseConsumption { get; private set; }

        public void SetMeterType(int meterType)
        {
            if (Validate.IsNotNullAndNonNegative<int>(meterType))
            {
                this.MeterType = meterType;
                defaultXml.Root.Element("meterType").Value = meterType.ToString();
            }
            else
            {
                throw new Exception("The meterType value is invalid.");
            }

        }

        public void SetMeterId(string meterId)
        {
            if (!string.IsNullOrWhiteSpace(meterId))
            {
                this.MeterId = meterId;
                this.defaultXml.Root.Element("meterId").Value = meterId;

            }
            else
            {
                throw new Exception("MeterId value is invalid .");
            }

        }

        public void SetMeterVersion(string meterVersion)
        {
           if (!string.IsNullOrWhiteSpace(meterVersion))
           {
                this.MeterVersion = meterVersion;
                this.defaultXml.Root.Element("meterVersion").Value = meterVersion;
            }
           else
           {
                throw new Exception("meterVersion value is invalid .");
           }
        }

        public void SetManufacturerId(string manufacturerId)
        {
            if (!string.IsNullOrWhiteSpace(manufacturerId))
            {
                this.ManufacturerId = manufacturerId;
                this.defaultXml.Root.Element("manufacturerId").Value = manufacturerId;

            }
            else
            {
                throw new Exception("The manufacturerId value is invalid.");
            }
        }

        public void SetCardId(string cardId)
        {
            if (!string.IsNullOrWhiteSpace(cardId))
            {
                this.CardId = cardId;
                this.defaultXml.Root.Element("cardId").Value = cardId;

            }
            else
            {
                throw new Exception("The cardId value is invalid.");
            }
        }

        public void SetCustomerId(string customerId)
        {
            if (!string.IsNullOrWhiteSpace(customerId))
            {
                this.CustomerId = customerId;
                this.defaultXml.Root.Element("customerId").Value = customerId;
            }
            else
            {
                throw new Exception("The customerId value is invalid.");
            }
        }

     

        public void SetCustomerOperationType(int customerOperationType)
        {
            if (Validate.IsNotNullAndNonNegative<int>(customerOperationType))
            {
                this.CustomerOperationType = customerOperationType;
                this.defaultXml.Root
                .Element("customerOperationType").Value = customerOperationType.ToString();

            }
            else {
                throw new Exception("The CustomerOperationType value is invalid.");
            }
            
        }

        public void SetInstallingMode(int installingMode)
        {
            if (Validate.IsNotNullAndNonNegative<int>(installingMode))
            {
                this.InstallingMode = installingMode;
                this.defaultXml.Root
                .Element("installingMode").Value = installingMode.ToString();
            }
            else 
            {
                throw new Exception("The installingMode value is invalid.");
            }

            
        }

        public void SetCustomerRechargeCardCanRemoveFaultsAndManipulations(int value)
        {
            if (Validate.IsNotNullAndNonNegative<int>(value))
            {
                this.CustomerRechargeCardCanRemoveFaultsAndManipulations = value;

                this.defaultXml.Root
               .Element("customerRechargeCardCanRemoveFaultsAndManipulations").Value = value.ToString();
            }
            else {

                throw new Exception("The CustomerRechargeCardCanRemoveFaultsAndManipulations value is invalid.");

            }

        }

        public void SetHolidays(List<string> holidays)
        {
            if (!Validate.IsValidDateList(holidays))
            throw new Exception("holidays formatting errors");

            this.Holidays = holidays;

           var holidaysTag = defaultXml.Root.Element("holidays");

            foreach (var item in holidays)
            {
                holidaysTag.Add(new XElement("holiday", item));
            }

            

        }

        public void SetFriendlyTime( FriendlyTime friendlyTime)
        {
            this.FriendlyTime = friendlyTime;

            var friendlyTimeTag = 
            this.defaultXml.Root.Element("friendlyTime");
                       

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

        public void SetRechargeDetails(RechargeDetails rechargeDetails)
        {
            this.RechargeDetails = rechargeDetails;

         
            var rechargeDetailsTag = this.defaultXml.Root.Element("rechargeDetails");

            rechargeDetailsTag.Add(new XElement("rechargeSequence", rechargeDetails.Sequence ));
            rechargeDetailsTag.Add(new XElement("rechargeAmount", rechargeDetails.Amount));
            rechargeDetailsTag.Add(new XElement("rechargeTime", rechargeDetails.RechargeTime?.ToString("dd-MM-yyyy HH:mm")));


        }

        public void SetBillingDay(string billingDay)
        {
            if (Validate.ValidateBillingDay(billingDay))
            {
                this.BillingDay = billingDay;
                this.defaultXml.Root
                .Element("billingDay").Value = billingDay;
            }
            else {
                throw new Exception("billingDay format is Invalid. format [dd HH:mm] .");
            }

            
        }

        public void SetFeesAmounts(List<decimal> feesAmounts)
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
            if (Validate.IsNotNullAndNonNegative<decimal>(zeroConsumptionFeeAmount) )
            {
                this.ZeroConsumptionFeeAmount = zeroConsumptionFeeAmount;
                this.defaultXml.Root
                .Element("zeroConsumptionFeeAmount").Value = zeroConsumptionFeeAmount.ToString();
            }
            else 
            {
                throw new Exception("zeroConsumptionFeeAmount is invalid value .");
            }
        }

        public void SetTotalDebt(TotalDebt totalDebt)
        {
            this.TotalDebt = totalDebt;
            var totalDebtTag = this.defaultXml.Root.Element("totalDebt");

            if (Validate.IsNotNullAndNonNegative<int>(totalDebt.Amount) )
            {
                totalDebtTag.Add(new XElement("totalDebtAmount", totalDebt.Amount) );
            }

            if (Validate.IsNotNullAndNonNegative<int>(totalDebt.KW))
            {
                totalDebtTag.Add(new XElement("totalDebtInKW", totalDebt.KW));
            }

            if (Validate.IsNotNullAndNonNegative<int>(totalDebt.Limit))
            {
                totalDebtTag.Add(new XElement("debtAmountLimit" , totalDebt.Limit));
            }

        }

      



        public void SetTariffsDetails(List<TariffStep> tariffSteps , TariffHeader header)
        {

            var tariffsDetailsTag = this.defaultXml.Root.Element("tariffsDetails");

            tariffsDetailsTag.Add(
                new XElement("tariffDetails",
                    new XElement("tariffId", header.tariffId ),
                    new XElement("tariffVersion" , header.tariffVersion),
                    new XElement("tariffGraceType" , header.tariffGraceType),
                    new XElement("tariffGracevalue",header.tariffGracevalue),
                    new XElement("tariffAlarmGrace",header.tariffAlarmGrace),
                    new XElement("tariffLimitGrace",header.tariffLimitGrace),
                    new XElement("tariffDeductionGrace",header.tariffDeductionGrace),
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
                        new XElement("tariffStepRecalculationEdge", step.TariffStepRecalculationEdge==0 ? null : step.TariffStepRecalculationEdge),
                        new XElement("tariffStepRecalculationEdgeAddedAmount", step.TariffStepRecalculationEdgeAddedAmount==0 ? null : step.TariffStepRecalculationEdgeAddedAmount)
                    )
                );
            }

           
        }

        
        public void SetControlOperationType(int controlOperationType)
        {
            this.ControlOperationType = $"{controlOperationType}";

            this.defaultXml.Root
            .Element("controlOperationType").Value = $"{controlOperationType}";
             

        }

        public void SetCurrentInBalanceConsumption(decimal Consumption)
        {
            this.CurrentInBalanceConsumption = Consumption;

            this.defaultXml.Root
            .Element("currentInbalanceConsumption").Value = $"{Consumption}";
        }

        public void SetCurrentReverseConsumption(decimal Consumption)
        {
            this.CurrentReverseConsumption = Consumption;

            this.defaultXml.Root
            .Element("currentReverseConsumption").Value = $"{Consumption}";
        }


        public void SetMeterWillDeductInstallments(int code)
        {
            this.MeterWillDeductInstallments = $"{code}";

            this.defaultXml.Root
            .Element("meterWillDeductInstallments").Value = $"{code}";


        }


        public void SetHoardMoneyLimit(decimal Limit)
        {
            this.HoardMoneyLimit = Limit ;

            this.defaultXml.Root
            .Element("hoardMoneyLimit").Value = $"{Limit}";


        }

        public void SetDateAndTimeMode(int DateAndTimeMode)
        {
            this.DateAndTimeMode = DateAndTimeMode;

            this.defaultXml.Root
            .Element("setDateAndTimeMode").Value = $"{DateAndTimeMode}";


        }

        public void SetOldCardId(string OldCardId)
        { 
            
            this.OldCardId = OldCardId;

            this.defaultXml.Root
            .Element("oldCardId").Value = OldCardId ;


        }

        public void SetExtrafeeskwh(decimal extrafeeskwh)
        {
            this.Extrafeeskwh = extrafeeskwh;

            this.defaultXml.Root
            .Element("extrafeeskwh").Value = extrafeeskwh.ToString();

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
            if (Validate.IsNotNullAndNonNegative<decimal>(extraFeeEveryKWH))
            {
                this.ExtraFeeEveryKWH = extraFeeEveryKWH;
                this.defaultXml.Root
                .Element("extraFeeEveryKWH").Value = extraFeeEveryKWH.ToString();


            }
            else {
                throw new Exception($"Extra Fee Every KWH [{extraFeeEveryKWH}] Invalid Value .");
            }
           
        }

        public void SetBalanceAlarmCutoffLimits(List<int> CutoffLimits)
        {
            this.BalanceAlarmCutoffLimits = CutoffLimits;

            var BalanceAlarmCutoffLimitsTag = 
            this.defaultXml.Root.Element("balanceAlarmCutoffLimits");

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
            if (Validate.IsNotNullAndNonNegative<int>(cardDataStatus))
            {
                this.CardDataStatus = cardDataStatus;
                this.defaultXml.Root
               .Element("cardDataStatus").Value = cardDataStatus.ToString();

            }
            else {
                throw new Exception("cardDataStatus Invalid Value .");
            }
            
        }

        public void SetResetMeterMode(int resetMeterMode)
        {
            

            if (Validate.IsNotNullAndNonNegative<int>(resetMeterMode))
            {
                this.ResetMeterMode = resetMeterMode;
                this.defaultXml.Root
               .Element("resetMeterMode").Value = resetMeterMode.ToString();

            }
            else
            {
                throw new Exception("resetMeterMode Invalid Value .");
            }

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
            if (!string.IsNullOrWhiteSpace(distributionCompanyCode))
            {
                this.DistributionCompanyCode = distributionCompanyCode;
                this.defaultXml.Root
                .Element("distributionCompanyCode").Value = distributionCompanyCode.ToString();
            }
            else
            {
                throw new Exception("The distributionCompanyCode value is invalid.");
            }

        }

        public void SetSectorCode(string sectorCode)
        {
            if (!string.IsNullOrWhiteSpace(sectorCode))
            {
                this.SectorCode = sectorCode;
                this.defaultXml.Root
               .Element("sectorCode").Value = sectorCode.ToString();
            }
            else
            {
                throw new Exception("The sectorCode value is invalid.");
            }

        }

        public void SetCustomerServiceMethod(int customerServiceMethod)
        {
            if (Validate.IsNotNullAndNonNegative<int>(customerServiceMethod))
            {
                this.CustomerServiceMethod = customerServiceMethod;
                this.defaultXml.Root
                .Element("customerServiceMethod").Value = customerServiceMethod.ToString();
            }
            else
            {
                throw new Exception("The customerServiceMethod value is invalid.");
            }

        }



  



        private XDocument defaultXml = new XDocument(
           new XElement("meterData",
           new XElement("meterId"),
           new XElement("meterType"),
           new XElement("meterVersion"),
           new XElement("manufacturerId"),
           new XElement("cardId"),
           new XElement("customerId"),
           new XElement("cardType",0),
           new XElement("customerOperationType"),
           new XElement("installingMode"),
           new XElement("oldCardId"),
           new XElement("customerRechargeCardCanRemoveFaultsAndManipulations"),
           new XElement("setDateAndTimeMode"),
           new XElement("editMeterDataOperations", 
                        new XElement("editMeterDataOperation")), 
           new XElement("holidays"),
           new XElement("friendlyTime"),
           new XElement("maxLoadSettings"),
           new XElement("rechargeDetails"),
           new XElement("lastRechargeDetails"),
           new XElement("rechargeHistory"),
           new XElement("encryptionKey"),
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
           new XElement("cardDataStatus",2),
           new XElement("resetMeterMode"),
           new XElement("weekOffDays"),
           new XElement("distributionCompanyCode"),
           new XElement("sectorCode"),
           new XElement("customerServiceMethod"),
           new XElement("editMeterDataOperations")
 

       ));
    





        public string BuildOpenAccountCard()
        {
             SetCustomerOperationType(2);
             XDocument local = new XDocument(this.defaultXml);


            if (this.RechargeDetails.Sequence.ToInt() != 1)
            {
                throw new Exception("RechargeDetails.Sequence Must be [1]");
            }

            this.CardXML = local.ToString();
            
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }

        public string BuildChargeCard()
        {
             SetCustomerOperationType(0);
             XDocument local = new XDocument(this.defaultXml);
                       

            this.CardXML = local.ToString();

            OnCardCreated?.Invoke(this);
            return local.ToString();
        }


        public string BuildReplacementCard( string CurrentCardId  , string NewCardId)
        {

            SetCardId(NewCardId);
            SetOldCardId(CurrentCardId);
            SetCustomerOperationType(1);
            XDocument local = new XDocument(this.defaultXml);


            this.CardXML = local.ToString();

            OnCardCreated?.Invoke(this);
            return local.ToString();
        }
















    }
}
