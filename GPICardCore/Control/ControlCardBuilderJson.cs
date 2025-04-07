using GPICardCore.Master;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GPICardCore.Control
{
    public class ControlCardBuilderJson : IControlCardBuilder
    {
        private int MeterType { get; set; }
        private string MeterVersion { get; set; }
        private string ManufacturerId { get; set; }
        private string CardId { get; set; }
        private string DistributionCompanyCode { get; set; }
        private string SectorCode { get; set; }
        private ControlCardActivationPeriod CardDate { get; set; }

        public string CardXML { get; private set; }
        public int CardType { get; private set; }
        public string CardName { get; private set; }
        public List<string> SelectedMeters { get; private set; }


        // Create JSON dynamically like XML
         private JObject json = new JObject
         {
             ["businessData"] = new JObject
             {
                 ["meterType"] = null,
                 ["meterVersion"] = null,
                 ["manufacturerId"] = null,
                 ["cardType"] = null,
                 ["cardId"] = null,
                 ["technicianCode"] = null,
                 ["ControlCardType"] = 2,
                 ["numberOfMeter"] = null,
                 ["controlMetersList"] = new JArray(),  
                 ["controlOperationType"] = null,
                 ["controlCardActivationDate"] = null,
                 ["controlCardExpiryDate"] = null,
                 ["setDateAndTimeMode"] = null,
                 ["manipulationsAndFaultsToBeCleared"] = new JArray(),  
                 ["maxLoadSettings"] = new JObject
                 {
                     ["maxLoad"] = null,
                     ["maxNumberOfCutoffs"] = null,
                     ["timeOfCloseRelay"] = null,
                     ["timeOfOpenRelay"] = null,
                     ["wayOfCutOffs"] = null
                 },
                 ["meterVoltSettings"] = new JObject
                 {
                     ["maxVolt"] = null,
                     ["minVolt"] = null,
                     ["maxVoltDetectionTime"] = null,
                     ["minVoltDetectionTime"] = null
                 },
                 ["meterTamperSettings"] = new JObject
                 {
                     ["reverseCurrentDetectionTimeInSecond"] = null,
                     ["faultEnergyDetectionTimeInSecond"] = null,
                     ["differenceRatioInCurrentInFaultEnergy"] = null,
                     ["batteryLowLevel"] = null
                 },
                 ["feesOnTariffSteps"] = null,
                 ["zeroConsumptionFeeAmount"] = null,
                 ["consumptionFeesInKwh"] = null,
                 ["broadcastingConsumptionFeesInKwh"] = null,
                 ["dailyFeesPrice"] = null,
                 ["monthlyFeesPrice"] = null,
                 ["customerServiceDeductionMethod"] = null,
                 ["activityCode"] = null,
                 ["tariffsDetails"] = null,
                 ["balanceAlarmCutoffLimits"] = new JArray(),  
                 ["meterTimestampToSet"] = null,
                 ["meterTampersAlarmAction"] = new JObject
                 {
                     ["batteryLow"] = null,
                     ["firstBalanceAlarmCutoff"] = null,
                     ["secondBalanceAlarmCutoff"] = null,
                     ["underVoltAlarm"] = null,
                     ["overVoltAlarm"] = null,
                     ["meterCover"] = null,
                     ["terminalCover"] = null,
                     ["reverseCurrentAlarm"] = null,
                     ["faultEnergyAlarm"] = null,
                     ["communicationOrBateryCover"] = null
                 },
                 ["quiteTime"] = new JObject
                 {
                     ["quiteTimeStartHour"] = null,
                     ["quiteTimeEndHour"] = null
                 },
                 ["encryptionKey"] = null,
                 ["maxDemandPeriod"] = null,
                 ["distributionCompany"] = new JObject
                 {
                     ["companyCode"] = null,
                     ["techCodeRegion"] = null,
                     ["sectorCode"] = null,
                     ["generalDivisionCode"] = null,
                     ["divisionCode"] = null,
                     ["rechargeCenterCode"] = null,
                     ["companyLevel"] = null,
                     ["indirectCompanyCode"] = null
                 },
                 ["noInstallationWithoutBattery"] = null,
                 ["RelayTime"] = null
             },
             ["isEPayment"] = false,
             ["cardGenerationType"] = 2
         };





        public event CardCreatedHandler OnCardCreated;

        public string BuildAlarmCutoffLimitsCard(List<int> limits)
        {
            throw new NotImplementedException();
        }

        public string BuildAlterTariffCard(List<TariffStep> tariffSteps, TariffHeader header, decimal zeroConsumptionFeeAmount)
        {
            throw new NotImplementedException();
        }

        public string BuildChangeDistributionCompanyCodeCard(string NewNumber)
        {
            throw new NotImplementedException();
        }

        public string BuildChangeMeterNumberCard(string currentNumber, string NewNumber)
        {
            throw new NotImplementedException();
        }

        public string BuildClearTamperCard(List<int> tamperCodelist)
        {
            throw new NotImplementedException();
        }

        public string BuildCollectCard()
        {
            throw new NotImplementedException();
        }

        public string BuildCopyMeterCard(string SourceMeterSerial)
        {
            throw new NotImplementedException();
        }

        public string BuildLabCard(List<int> ControlWord, int AvailableKWh, int AvailableTime)
        {
            throw new NotImplementedException();
        }

        public string BuildLunchCurrentCard()
        {
            throw new NotImplementedException();
        }

        public string BuildRelayTestCard()
        {
             json["businessData"]["controlOperationType"] = 6;

            return json.ToString();
        }

        public string BuildResetCard()
        {
            throw new NotImplementedException();
        }

        public string BuildSetDateTimeCard(DateTime DateTimeValue)
        {
            throw new NotImplementedException();
        }

        public string BuildSetDateTimeOnMeterManualCard()
        {
            throw new NotImplementedException();
        }

        public string BuildToggleRelayCard(int reverseCardRecoveryTime)
        {
            throw new NotImplementedException();
        }

        public IControlCardBuilder SetCardId(string cardId)
        {
            if (!string.IsNullOrWhiteSpace(cardId))
            {
                this.CardId = cardId;
                json["businessData"]["cardId"] = cardId;
               
            }
            else
            {
                throw new Exception("The cardId value is Invalid.");
            }
            return this;
        }

        public IControlCardBuilder SetCardPeriod(ControlCardActivationPeriod cardDate)
        {
            if (cardDate.ActivationDate.Year < 2000 ||
               cardDate.ActivationDate.Year < 2000)
            {
                throw new Exception("Control Card Activation Period Invalid .");
            }

            if (!(cardDate.ExpiryDate >= cardDate.ActivationDate))
            {
                throw new Exception(" ExpiryDate less than ActivationDate");
            }

            this.CardDate = cardDate;
             
            json["businessData"]["controlCardActivationDate"] = cardDate.ActivationDate.ToString("dd-MM-yyyy");

            json["businessData"]["controlCardExpiryDate"] = cardDate.ExpiryDate.ToString("dd-MM-yyyy");
            

            
            return this;
        }

        public IControlCardBuilder SetDistributionCompanyCode(string distributionCompanyCode)
        {
            if (!string.IsNullOrWhiteSpace(distributionCompanyCode))
            {
                this.DistributionCompanyCode = distributionCompanyCode;
                json["businessData"]["distributionCompany"]["companyCode"] = Convert.ToInt32( distributionCompanyCode );
               
            }
            else
            {
                throw new Exception("The distributionCompanyCode value is invalid.");
            }

            return this;
        }

        public IControlCardBuilder SetManufacturerId(string manufacturerId)
        {
            if (!string.IsNullOrWhiteSpace(manufacturerId))
            {
                this.ManufacturerId = manufacturerId;
                json["businessData"]["manufacturerId"] = manufacturerId;
             }
            else
            {
                throw new Exception("The manufacturerId value is invalid.");
            }
            return this;
        }

        public IControlCardBuilder SetMeterType(int meterType)
        {
           

            if (Validate.IsNotNullAndNonNegative<int>(meterType))
            {
                this.MeterType = meterType;
                json["businessData"]["meterType"] = meterType ;
            }
            else
            {
                throw new Exception("The meterType value is invalid.");
            }

            return this;


        }

        public IControlCardBuilder SetMeterVersion(string meterVersion)
        {
            if (!string.IsNullOrWhiteSpace(meterVersion))
            {
                this.MeterVersion = meterVersion;
                json["businessData"]["meterVersion"] =  meterVersion;
             }
            else
            {
                throw new Exception("The meterVersion value is invalid.");
            }

            return this;
        }

        public IControlCardBuilder SetSectorCode(string sectorCode)
        {
            if (!string.IsNullOrWhiteSpace(sectorCode))
            {
                this.SectorCode = sectorCode;
                json["businessData"]["distributionCompany"]["sectorCode"] = sectorCode;
              
            }
            else
            {
                throw new Exception("The sectorCode value is invalid.");
            }
            return this;
        }

        public IControlCardBuilder SetSelectedMeters(List<string> meters)
        {
            throw new NotImplementedException();
        }
    }
}
