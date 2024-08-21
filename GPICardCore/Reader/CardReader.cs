using GPICardCore.Master;
using System.Globalization;
using System.Xml;

namespace GPICardCore.Reader
{
    public class CardReader
    {
        private readonly XmlDocument doc;
        public string Xml { get; private set; }
        public string MeterId { get; private set; }
        public string MeterType { get; private set; }
        public string MeterVersion { get; private set; }
        public string ManufacturerId { get; private set; }
        public string CardId { get; private set; }
        public string CustomerId { get; private set; }
        public FriendlyTime FriendlyTime { get; private set; }
        public string ControlOperationType { get; private set; }
        public int InstallingMode { get; private set; }

        public List<string> Holidays { get; private set; }

        public MaxLoadSetting MaxLoadSettings { get; private set; }

        public TariffDetails TariffsDetails { get; private set; }

        public List<PreviousRechargeTransaction> RechargeHistory { get; private set; }

        public List<Consumption> ConsumptionsList { get; private set; }


        public int CompanyCode { get; private set; }
        public int SectorCode { get; private set; }
        public string TariffIdActivationDate { get; private set; }

        public int CustomerCardCanRemoveFaultsAndManipulations { get; private set; }

        public string OldCardId { get; private set; }


        public int CustomerOperationType { get; private set; }

 
        public string DateAndTimeMode { get; private set; }

        public List<int> Tampers;

        public List<string> ActivedMeters;

        public List<ElectricityCutoff> CutOFFHistory;

        public int PurchaseCount { get; private set; }

        public string ControlCardActivationDate { get; private set; }
        public string ControlCardExpiryDate { get; private set; }

        public List<double> feesAmountsList { get; private set; }
        public double feesAmountsListSum { get; private set; }

        public LastRechargeDetails LastRechargeDetails { get; private set; }

        public RechargeDetails RechargeDetails { get; private set; }

        public string BillingDay { get; private set; }

        public double ZeroConsumptionFeeAmount { get; private set; }

        public double OverloadCurrent1 { get; private set; }
        public double OverloadCurrent2 { get; private set; }
        public double OverloadCurrent3 { get; private set; }

        public int CustomerServiceMethodCalc { get; private set; }


        public double RemainingBalance { get; private set; }
        public double RemainingPower { get; private set; }
        public string MeterInstallationDate { get; private set; }
        public string MeterInstallerID { get; private set; }
        public double TotalPowerConsumption { get; private set; }
        public double TotalRechargeAmount { get; private set; }
        public int MeterStatusCode { get; private set; }
        public string MeterRealStatus { get; private set; }
        public int BatteryStatusCode { get; private set; }
        public int BatarryStatusCode { get; private set; }
        public double PowerFactor { get; private set; }
        public double AvgPFCurYear { get; private set; }
        public double AvgPFLastYear { get; private set; }
        public string EncryptionKey { get; private set; }
        public double ExtraFeesKwh { get; private set; }
        public double ExtraFeesPrice { get; private set; }
        public double ExtraFeeEveryKWH { get; private set; }
        public string NewDistributionCompanyCode { get; private set; }
        public string NewMeterId { get; private set; }
        public string HoardMoneyLimit { get; private set; }
        public string Hour48FriendlyTime { get; private set; }
        public string ReverseCardRecoveryTime { get; private set; }
        public string FirstRelayTamperDateTime { get; private set; }
        public string LatestRelayTamperDateTime { get; private set; }
        public string LabTestCardAvailableTime { get; private set; }
        public string LabTestCardAvailableKWh { get; private set; }
        public string LatestErrorCode { get; private set; }
        public string CardStatus { get; private set; }
        public string CustomerCardExpiryDate { get; private set; }
        public string CardDataStatus { get; private set; }
        public int ResetMeterMode { get; private set; }
        public string CurrentInbalanceConsumption { get; private set; }
        public string CurrentBypassConsumption { get; private set; }
        public string CurrentReverseConsumption { get; private set; }
        public double? CurrentConsumption { get; private set; }
        public DateTime? MeterTimestampToSet { get; private set; }
        public DateTime? CurrentMeterTimestamp { get; private set; }
        public List<PreviousMeterEvent> PreviousMeterEventList { get; private set; }
        public List<int> MeterEventStatusList { get; private set; }
        public MaxDemand MaxDemandDetails { get; private set; }
        public MaxDemand MaxDemandDetailsCurrrentYear { get; private set; }
        public MaxDemand MaxDemandDetailsHistory { get; private set; }
        public List<int> WeekOffDays { get; private set; }
        public List<int> BalanceAlarmCutoffLimits { get; private set; }
        public QuiteTime QuiteTime { get; private set; }
        public List<PreviousModifyDate> PreviousModifyDates { get; private set; }
        public List<ProcessedMeter> MetersProcessedByControlCard { get; private set; }
        public List<SlidingIntervalDeductionDetail> SlidingIntervalDeductionDetails { get; private set; }
        public List<SpecificDeductionDetail> SpecificDeductionDetails { get; private set; }


        public CardReader(string CardXml)
        {
            this.Xml = CardXml;

            doc = new XmlDocument();
            doc.LoadXml(Xml);

            MeterId = doc.SelectSingleNode("meterData/meterId")?.InnerText;
            MeterType = doc.SelectSingleNode("meterData/meterType")?.InnerText;
            MeterVersion = doc.SelectSingleNode("meterData/meterVersion")?.InnerText;
            ManufacturerId = doc.SelectSingleNode("meterData/manufacturerId")?.InnerText;
            CardId = doc.SelectSingleNode("meterData/cardId")?.InnerText;
            CustomerId = doc.SelectSingleNode("meterData/customerId")?.InnerText;
            ControlOperationType = doc.SelectSingleNode("meterData/controlOperationType")?.InnerText;

            CompanyCode = doc.SelectSingleNode("meterData/distributionCompanyCode").InnerText.ToInt();
            SectorCode = doc.SelectSingleNode("meterData/sectorCode").InnerText.ToInt();
            TariffIdActivationDate = doc.SelectSingleNode("meterData/tariffIdActivationDate")?.InnerText;
            OldCardId = doc.SelectSingleNode("meterData/oldCardId")?.InnerText;

            PurchaseCount = doc.SelectSingleNode("meterData/PurchaseCount").InnerText.ToInt();
            CustomerOperationType = doc.SelectSingleNode("meterData/customerOperationType").ToInt();
 
            DateAndTimeMode = doc.SelectSingleNode("meterData/setDateAndTimeMode")?.InnerText;

            ControlCardActivationDate = doc.SelectSingleNode("meterData/controlCardActivationPeriod/controlCardActivationDate")?.InnerText;
            ControlCardExpiryDate = doc.SelectSingleNode("meterData/controlCardActivationPeriod/controlCardExpiryDate")?.InnerText;

            BillingDay = doc.SelectSingleNode("meterData/billingDay")?.InnerText;

            ZeroConsumptionFeeAmount = doc.SelectSingleNode("meterData/zeroConsumptionFeeAmount").InnerText.ToDouble();

            OverloadCurrent1 = doc.SelectSingleNode("meterData/overload1stCurrent").InnerText.ToDouble();
            OverloadCurrent2 = doc.SelectSingleNode("meterData/overload2ndCurrent").InnerText.ToDouble();
            OverloadCurrent3 = doc.SelectSingleNode("meterData/overload3rdCurrent").InnerText.ToDouble();

            RemainingBalance = doc.SelectSingleNode("meterData/remainingBalance").InnerText.ToDouble();
            RemainingPower = doc.SelectSingleNode("meterData/remainingPower").InnerText.ToDouble();

            MeterInstallationDate = doc.SelectSingleNode("meterData/meterInstallationDate")?.InnerText;
            MeterInstallerID = doc.SelectSingleNode("meterData/meterInstallerID")?.InnerText;
            TotalPowerConsumption = doc.SelectSingleNode("meterData/totalPowerConsumption").InnerText.ToDouble();
            TotalRechargeAmount = doc.SelectSingleNode("meterData/totalRechargeAmount").InnerText.ToDouble();

            MeterStatusCode = doc.SelectSingleNode("meterData/meterStatusCode").InnerText.ToInt();

            MeterRealStatus = doc.SelectSingleNode("meterData/meterRealStatus").InnerText;


            BatteryStatusCode = doc.SelectSingleNode("meterData/batteryStatusCode").InnerText.ToInt();
            BatarryStatusCode = doc.SelectSingleNode("meterData/batarryStatusCode").InnerText.ToInt();

            PowerFactor = doc.SelectSingleNode("meterData/powerFactor").InnerText.ToDouble();
            AvgPFCurYear = doc.SelectSingleNode("meterData/averagePowerFactorCurYear").InnerText.ToDouble();
            AvgPFLastYear = doc.SelectSingleNode("meterData/averagePowerFactorLastYear").InnerText.ToDouble();
            EncryptionKey = doc.SelectSingleNode("meterData/encryptionKey")?.InnerText;

            ExtraFeesKwh = doc.SelectSingleNode("meterData/extrafeeskwh").InnerText.ToDouble();
            ExtraFeesPrice = doc.SelectSingleNode("meterData/extrafeesprice").InnerText.ToDouble();
            ExtraFeeEveryKWH = doc.SelectSingleNode("meterData/extraFeeEveryKWH").InnerText.ToDouble();
            NewDistributionCompanyCode = doc.SelectSingleNode("meterData/newDistributionCompanyCode")?.InnerText;
            NewMeterId = doc.SelectSingleNode("meterData/newMeterId")?.InnerText;
            HoardMoneyLimit = doc.SelectSingleNode("meterData/hoardMoneyLimit")?.InnerText;
            Hour48FriendlyTime = doc.SelectSingleNode("meterData/hour48FriendlyTime")?.InnerText;
            ReverseCardRecoveryTime = doc.SelectSingleNode("meterData/reverseCardRecoveryTime")?.InnerText;
            FirstRelayTamperDateTime = doc.SelectSingleNode("meterData/firstRelayTamperDateTime")?.InnerText;
            LatestRelayTamperDateTime = doc.SelectSingleNode("meterData/latestRelayTamperDateTime")?.InnerText;
            LabTestCardAvailableTime = doc.SelectSingleNode("meterData/labTestCardAvailableTime")?.InnerText;
            LabTestCardAvailableKWh = doc.SelectSingleNode("meterData/labTestCardAvailableKWh")?.InnerText;
            LatestErrorCode = doc.SelectSingleNode("meterData/latestErrorCode")?.InnerText;
            CardStatus = doc.SelectSingleNode("meterData/cardStatus")?.InnerText;
            CustomerCardExpiryDate = doc.SelectSingleNode("meterData/customerCardExpiryDate")?.InnerText;
            CardDataStatus = doc.SelectSingleNode("meterData/cardDataStatus")?.InnerText;
            ResetMeterMode = doc.SelectSingleNode("meterData/resetMeterMode").InnerText.ToInt();
            CurrentInbalanceConsumption = doc.SelectSingleNode("meterData/currentInbalanceConsumption")?.InnerText;
            CurrentBypassConsumption = doc.SelectSingleNode("meterData/currentBypassConsumption")?.InnerText;
            CurrentReverseConsumption = doc.SelectSingleNode("meterData/currentReverseConsumption")?.InnerText;
            CurrentConsumption = doc.SelectSingleNode("meterData/currentConsumption")?.InnerText.ToDouble();
            MeterTimestampToSet = ToDateTime(doc.SelectSingleNode("meterData/meterTimestampToSet")?.InnerText);


            ReadWeekOffDays();
            ReadHolidaysList();
            ReadMaxDemandDetailsCurrrentYear();
            ReadMaxDemandDetailsHistory();
            ReadMaxDemandDetails();
            MeterEventStatusHandler();
            ReadConsumptionsKw_LE();
            ReadCustomerServiceMethodCalc();
            ReadFeeAmount();
            ReadCutOffHistory();
            Recharge();
            LastChargeRead();
            ReadActivedMetersList();
            ManipulationsAndFaultsToBeCleared();
            CustomerRechargeCardCanRemoveFaultsAndManipulations();
            InstallModeRead();
            RechargeHistoryList();
            tariffsDetailsHandler();
            FriendlyTimeHadler();
            MaxLoadSettinghandler();
            balanceAlarmCutoffLimitsHandler();
            QuiteTimehandler();
            PreviousModifyDatesHandler();
            MetersProcessedByControlCardHandler();
            SlidingIntervalDeductionDetailsHandler();
            SpecificDeductionDetailsHandler();

        }
        public bool CheckElementExists(string xpath)
        {
            XmlNode node = doc.SelectSingleNode(xpath);
            return node != null;
        }
        private List<T> GetNodeList<T>(XmlNodeList nodeList)
        {
            List<T> valueList = new List<T>();

            foreach (XmlNode node in nodeList)
            {
                var innerText = node?.InnerText;

                if (!string.IsNullOrEmpty(innerText))
                {
                    T convertedValue = (T)Convert.ChangeType(innerText, typeof(T));
                    valueList.Add(convertedValue);
                }

            }

            return valueList;

        }
        private DateTime? ToDateTime(string dateString)
        {
            if (string.IsNullOrEmpty(dateString)) return null;



            try
            {
                return DateTime.ParseExact(dateString, "dd-MM-yyyy HH:mm", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                try
                {
                    return DateTime.ParseExact(dateString, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {

                    try
                    {
                        return DateTime.ParseExact(dateString, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                    }
                    catch (Exception)
                    {

                        return null;
                    }
                }

            }




        }


        private void SpecificDeductionDetailsHandler()
        {
            this.SpecificDeductionDetails = new List<SpecificDeductionDetail>();
            XmlNodeList specificDeductionNodes = this.doc.SelectNodes("meterData/specificDeductionDetails/specificDeductionDetail");

            foreach (XmlNode node in specificDeductionNodes)
            {
                int stepNumber = Convert.ToInt32( node["specificStepNumber"]?.InnerText);
                int limit      =  node["specificDeductionLimit"].InnerText.ToInt();
                decimal price  =  node["specificDeductionPrice"].InnerText.ToDecimal();

                SpecificDeductionDetail deductionDetail = new SpecificDeductionDetail(stepNumber, limit, price);
                this.SpecificDeductionDetails.Add(deductionDetail);
            }
        }
        private void SlidingIntervalDeductionDetailsHandler()
        {
            this.SlidingIntervalDeductionDetails = new List<SlidingIntervalDeductionDetail>();
            XmlNodeList slidingIntervalNodes = this.doc.SelectNodes("meterData/slidingIntervalDeductionDetails/slidingIntervalDeductionDetail");

            foreach (XmlNode node in slidingIntervalNodes)
            {

                int number    = string.IsNullOrWhiteSpace(node["slidingIntervaNumber"]?.InnerText) ? 0 : node["slidingIntervaNumber"].InnerText.ToInt();
                int limitFrom = node["slidingIntervalLimitFrom"].InnerText.ToInt();
                int limitTo   = node["slidingIntervalLimitTo"].InnerText.ToInt();
                decimal price = node["slidingIntervalPrice"].InnerText.ToDecimal();

                SlidingIntervalDeductionDetail deductionDetail = new SlidingIntervalDeductionDetail(number=0 , limitFrom, limitTo, price);
                this.SlidingIntervalDeductionDetails.Add(deductionDetail);
            }
        }
        private void MetersProcessedByControlCardHandler()
        {
            this.MetersProcessedByControlCard = new List<ProcessedMeter>();
            XmlNodeList processedMeterNodes = this.doc.SelectNodes("meterData/metersProcessedByControlCard/processedMeter");

            foreach (XmlNode node in processedMeterNodes)
            {
                ProcessedMeter processedMeter = new ProcessedMeter
                {
                    ProcessedMeterId = node["processedMeterId"].InnerText,
                    ProcessingTimestamp = node["processingTimestamp"].InnerText,
                    CurrentMeterStatus = node["currentMeterStatus"].InnerText,
                    OldMeterStatus = node["oldMeterStatus"].InnerText,
                    MeterInstallationDate = node["meterInstallationDate"].InnerText,
                    CustomerId = node["customerId"].InnerText
                };

                this.MetersProcessedByControlCard.Add(processedMeter);
            }
        }
        private void PreviousModifyDatesHandler()
        {
            this.PreviousModifyDates = new List<PreviousModifyDate>();
            XmlNodeList previousModifyDateNodes = this.doc.SelectNodes("meterData/previousModifyDates/previousModifyDate");

            foreach (XmlNode node in previousModifyDateNodes)
            {
                PreviousModifyDate modifyDate = new PreviousModifyDate
                {
                    PreviousModifyDateIndex = node["previousModifyDateIndex"].InnerText,
                    PreviousModifyDateId = node["previousModifyDateId"].InnerText,
                    PreviousModifyDateTime = node["previousModifyDateTime"].InnerText
                };

                this.PreviousModifyDates.Add(modifyDate);
            }
        }
        private void QuiteTimehandler()
        {
            this.QuiteTime = new QuiteTime();
            XmlNode quiteTimeNodes = this.doc.SelectSingleNode("meterData/quiteTime");

            this.QuiteTime.Start = quiteTimeNodes["quiteTimeStartHour"].InnerText.ToInt();
            this.QuiteTime.End   = quiteTimeNodes["quiteTimeEndHour"].InnerText.ToInt();

        }

        private void balanceAlarmCutoffLimitsHandler()
        {
            this.BalanceAlarmCutoffLimits = new List<int>();

            var BalanceAlarmCutoffLimitsNodes = this.doc.SelectNodes("meterData/balanceAlarmCutoffLimits/cutoffAlarmLimitBalance");

            foreach (XmlNode item in BalanceAlarmCutoffLimitsNodes)
            {
                BalanceAlarmCutoffLimits.Add( item.InnerText.ToInt() );
            }
        }
        private void MaxLoadSettinghandler() {

            this.MaxLoadSettings = new MaxLoadSetting() {
              MaxLoad           = this.doc.SelectSingleNode("meterData/maxLoadSettings/maxLoad").InnerText.ToDecimal() ,
              MaxNumberOfCutOFF = this.doc.SelectSingleNode("meterData/maxLoadSettings/maxNumberOfCutoffs").InnerText.ToInt()

            };

        }
        private void FriendlyTimeHadler()
        {
            XmlNode FriendlyTimeNode =  doc.SelectSingleNode("meterData/friendlyTime");

            this.FriendlyTime = new FriendlyTime 
            { StartHour = FriendlyTimeNode["friendlyStartHour"].InnerText.ToInt() ,
              EndHour   = FriendlyTimeNode["friendlyEndHour"].InnerText.ToInt()
            };

        }
        private void ReadWeekOffDays()
        {
            XmlNodeList nodes = doc.SelectNodes("meterData/weekOffDays/weekOffDay");
            List<int> daysId = GetNodeList<int>(nodes);
            WeekOffDays = daysId.ConvertAll(dayNumber => dayNumber);
        }
        private void ReadHolidaysList()
        {
            XmlNodeList holidayNodes = doc.SelectNodes("meterData/holidays/holidayDate");
            Holidays = new List<string>();

            foreach (XmlNode node in holidayNodes)
            {
                string day = node?.InnerText;
                Holidays.Add(day);
            }
        }

        private void ReadMaxDemandDetailsCurrrentYear()
        {
            XmlNode node = doc.SelectSingleNode("meterData/maxDemandDetailsCurrrentYear");
            MaxDemandDetailsCurrrentYear = new MaxDemand();
            MaxDemandDetailsCurrrentYear.KW = node["maxDemandInKw"].InnerText.ToDouble();
            MaxDemandDetailsCurrrentYear.KWTime = node["maxDemandInKwTimestamp"].InnerText.ToDateTime();
            MaxDemandDetailsCurrrentYear.Ampere = node["maxDemandInAmpere"].InnerText.ToDouble();
            MaxDemandDetailsCurrrentYear.AmpereTime = node["maxDemandInAmpereTimestamp"].InnerText.ToDateTime();
        }

        private void ReadMaxDemandDetailsHistory()
        {
            XmlNode node = doc.SelectSingleNode("meterData/maxDemandDetailsHistory");
            MaxDemandDetailsHistory = new MaxDemand();
            MaxDemandDetailsHistory.KW = node["maxDemandInKw"].InnerText.ToDouble();
            MaxDemandDetailsHistory.KWTime = node["maxDemandInKwTimestamp"].InnerText.ToDateTime();
            MaxDemandDetailsHistory.Ampere = node["maxDemandInAmpere"].InnerText.ToDouble();
            MaxDemandDetailsHistory.AmpereTime = node["maxDemandInAmpereTimestamp"].InnerText.ToDateTime();
        }

        private void ReadMaxDemandDetails()
        {
            XmlNode node = doc.SelectSingleNode("meterData/maxDemandDetails");
            MaxDemandDetails = new MaxDemand();
            MaxDemandDetails.KW = node["maxDemandInKw"].InnerText.ToDouble();
            MaxDemandDetails.KWTime = node["maxDemandInKwTimestamp"].InnerText.ToDateTime();
            MaxDemandDetails.Ampere = node["maxDemandInAmpere"].InnerText.ToDouble();
            MaxDemandDetails.AmpereTime = node["maxDemandInAmpereTimestamp"].InnerText.ToDateTime();
        }

        private void MeterEventStatusHandler()
        {
            string MeterEventStatusCodes = doc.SelectSingleNode("meterData/meterEventStatus").InnerText;
            string[] MeterEventStatusArr = MeterEventStatusCodes.Split(',');

            MeterEventStatusList = new List<int>();

            foreach (var item in MeterEventStatusArr)
            {
                if (!string.IsNullOrEmpty(item)) MeterEventStatusList.Add(item.ToInt());
            }
        }

         
      

        private void ReadConsumptionsKw_LE()
        {
            string dateString = doc.SelectSingleNode("meterData/currentMeterTimestamp").InnerText;


            CurrentMeterTimestamp = ToDateTime(dateString);

            if (CurrentMeterTimestamp != null)
            {
                DateTime MeterDateTime = (DateTime)ToDateTime(dateString);

                var kwNodeList = doc.SelectNodes("meterData/previousPowerConsumptions/previousPowerConsumption");
                var kwList = GetNodeList<int>(kwNodeList);


                var moneyNodeList = doc.SelectNodes("meterData/previousMoneyConsumptions/previousMoneyConsumption");
                var moneyList = GetNodeList<double>(moneyNodeList);

                ConsumptionsList = new List<Consumption>();

                for (int i = 0; i < kwList.Count; i++)
                {
                    MeterDateTime = MeterDateTime.AddMonths(-1);

                    ConsumptionsList.Add(new Consumption
                    {
                        KW = kwList[i],
                        LE = moneyList[i],
                        YY = MeterDateTime.Year,
                        MM = MeterDateTime.Month
                    });
                }

            }
            else
            {
                ConsumptionsList = new List<Consumption>();
            }




        }

        private void ReadCustomerServiceMethodCalc()
        {
            var custServId = doc.SelectSingleNode("meterData/customerServiceMethod")?.InnerText;
            CustomerServiceMethodCalc = custServId.ToInt();
        }

        private void ReadFeeAmount()
        {
            var feesAmounts = doc.SelectNodes("meterData/feesAmounts/feeAmount");
            feesAmountsList = GetNodeList<double>(feesAmounts);
            feesAmountsListSum = feesAmountsList.Sum();
        }

        private void ReadCutOffHistory()
        {
            var electricityCutoffHistory = doc.SelectSingleNode("meterData/electricityCutoffHistory").OuterXml;

            CutOFFHistory = new List<ElectricityCutoff>();

            XmlDocument docxml = new XmlDocument();
            docxml.LoadXml(electricityCutoffHistory);

            XmlNodeList electricityCutoffNodes = doc.SelectNodes("//electricityCutoff");

            foreach (XmlNode item in electricityCutoffNodes)
            {
                if (!string.IsNullOrWhiteSpace(item["electricityCutoffTime"].InnerText))
                {
                    CutOFFHistory.Add(
                       new ElectricityCutoff
                       {
                           ElectricityCutoffTime = item["electricityCutoffTime"].InnerText,
                           ElectricityCutoffReason = item["electricityCutoffReason"].InnerText

                       });

                }


            }
        }

        private void Recharge()
        {
            var RechargeSequence = doc.SelectSingleNode("meterData/rechargeDetails/rechargeSequence")?.InnerText;
            var RechargeAmount = doc.SelectSingleNode("meterData/rechargeDetails/rechargeAmount")?.InnerText;
            var RechargeTime = doc.SelectSingleNode("meterData/rechargeDetails/rechargeTime")?.InnerText;

            if (!string.IsNullOrEmpty(RechargeSequence))
            {
                RechargeDetails = new RechargeDetails
                {
                    Sequence = RechargeSequence.ToInt(),
                    Amount = RechargeAmount.ToDecimal(),
                    RechargeTime = (ToDateTime(RechargeTime) == null) ? null : Convert.ToDateTime(RechargeTime) 
                };
            }
            else
            {
                RechargeDetails = new RechargeDetails
                {
                    Sequence = 0,
                    Amount = 0,
                    RechargeTime = null
                };
            }

        }

        private void LastChargeRead()
        {
            ///lastRechargeDetails
            string Sequence = doc.SelectSingleNode("meterData/lastRechargeDetails/rechargeSequence").InnerXml;
            string Amount = doc.SelectSingleNode("meterData/lastRechargeDetails/rechargeAmount").InnerXml;
            string DateTime = doc.SelectSingleNode("meterData/lastRechargeDetails/rechargeTime").InnerXml;

            if (!string.IsNullOrEmpty(Sequence))
            {
                LastRechargeDetails = new LastRechargeDetails
                {
                    RechargeSequence = Sequence.ToInt(),
                    RechargeAmount = Amount.ToDecimal(),
                    RechargeTime = DateTime
                };
            }
            else
            {
                LastRechargeDetails = new LastRechargeDetails
                {
                    RechargeSequence = 0,
                    RechargeAmount = 0m,
                    RechargeTime = null
                };
            }

        }

        private void ReadActivedMetersList()
        {
            string xpath = "meterData/controlCardActiveMeters/controlCardActiveMeter";
            bool ElementExists = CheckElementExists(xpath);

            if (ElementExists)
            {
                var nodes = doc.SelectNodes(xpath);
                var metersList = GetNodeList<string>(nodes);

                ActivedMeters = new List<string>();

                foreach (var meterId in metersList)
                {
                    if (meterId.Length > 1) ActivedMeters.Add(meterId);

                }
            }
            else
            {
                ActivedMeters = new List<string>();
            }
        }

        private void ManipulationsAndFaultsToBeCleared()
        {
            string xpath = "meterData/manipulationsAndFaultsToBeCleared/manipulationOrFaultToBeCleared";
            bool ElementExists = CheckElementExists(xpath);

            if (ElementExists)
            {
                var nodes = doc.SelectNodes(xpath);
                var tamperIds = GetNodeList<int>(nodes);

                Tampers = new List<int>();

                foreach (var tamperId in tamperIds)
                {
                    Tampers.Add((int)tamperId);
                }
            }
            else
            {
                Tampers = new List<int>();
            }

        }

        public void CustomerRechargeCardCanRemoveFaultsAndManipulations()
        {
            var CanRemove = doc.SelectSingleNode("/meterData/customerRechargeCardCanRemoveFaultsAndManipulations").InnerText.Trim();
            CustomerCardCanRemoveFaultsAndManipulations = CanRemove.ToInt();
        }

        private void InstallModeRead()
        {
            var installingModeCode = doc.SelectSingleNode("meterData/installingMode")?.InnerText;
            InstallingMode =  installingModeCode.ToInt();
        }

        private void RechargeHistoryList()
        {
           

            XmlNodeList rechargeHistoryNodeList = doc.SelectNodes("meterData/rechargeHistory/previousRechargeTransaction");
            
            RechargeHistory = new List<PreviousRechargeTransaction>();

            foreach (XmlNode node in rechargeHistoryNodeList)
            {
                RechargeHistory.Add( new PreviousRechargeTransaction {                     
                    PreviousRechargeAmount = node["previousRechargeAmount"].InnerText ,
                    PreviousRechargeTime   = node["previousRechargeTime"].InnerText
                });
            }

        }

         
        private void tariffsDetailsHandler() {

            this.TariffsDetails = new TariffDetails();
            this.TariffsDetails.TariffSteps = new List<TariffStep>();

             XmlNode tariffsDetailsNode = doc.SelectSingleNode("meterData/tariffsDetails/tariffDetails");

            this.TariffsDetails.TariffId             =    tariffsDetailsNode["tariffId"].InnerText.ToInt();
            this.TariffsDetails.TariffGraceType      =  string.IsNullOrWhiteSpace( tariffsDetailsNode["tariffGraceType"].InnerText)      ? null : tariffsDetailsNode["tariffGraceType"].InnerText.ToInt();
            this.TariffsDetails.TariffGracevalue = string.IsNullOrWhiteSpace(tariffsDetailsNode["tariffGracevalue"].InnerText) ? null : tariffsDetailsNode["tariffGracevalue"].InnerText.ToInt();
            this.TariffsDetails.TariffAlarmGrace = string.IsNullOrWhiteSpace(tariffsDetailsNode["tariffAlarmGrace"].InnerText) ? null : tariffsDetailsNode["tariffAlarmGrace"].InnerText.ToInt();
            this.TariffsDetails.TariffLimitGrace = string.IsNullOrWhiteSpace(tariffsDetailsNode["tariffLimitGrace"].InnerText) ? null : tariffsDetailsNode["tariffLimitGrace"].InnerText.ToInt();
            this.TariffsDetails.TariffDeductionGrace = string.IsNullOrWhiteSpace(tariffsDetailsNode["tariffDeductionGrace"].InnerText) ? null : tariffsDetailsNode["tariffDeductionGrace"].InnerText.ToInt();

             
            XmlNodeList tariffStepsNodes = doc.SelectNodes("meterData/tariffsDetails/tariffDetails/tariffSteps/tariffStep");

            foreach (XmlNode item in tariffStepsNodes)
            {

                var tariffStepNumber = item["tariffStepNumber"].InnerText.ToInt();
                var tariffStepLimitFrom = item["tariffStepLimitFrom"].InnerText.ToInt();
                var tariffStepLimitTo = item["tariffStepLimitTo"].InnerText.ToInt();
                var tariffStepPrice = item["tariffStepPrice"].InnerText.ToDecimal();
                var tariffStepCustomerServiceFee = item["tariffStepCustomerServiceFee"].InnerText.ToDecimal();
                var tariffStepRecalculationEdge = item["tariffStepRecalculationEdge"].InnerText.ToInt();
                var tariffStepRecalculationEdgeAddedAmount = item["tariffStepRecalculationEdgeAddedAmount"].InnerText.ToDecimal();

                this.TariffsDetails.TariffSteps
                .Add( new TariffStep {

                    TariffStepCustomerServiceFee = tariffStepCustomerServiceFee,
                    TariffStepNumber = tariffStepNumber,
                    TariffStepLimitFrom=tariffStepLimitFrom,
                    TariffStepLimitTo=tariffStepLimitTo,
                    TariffStepPrice=tariffStepPrice,
                    TariffStepRecalculationEdge=tariffStepRecalculationEdge,
                    TariffStepRecalculationEdgeAddedAmount=tariffStepRecalculationEdgeAddedAmount,
                    


                });


            }


        }




    }
}
