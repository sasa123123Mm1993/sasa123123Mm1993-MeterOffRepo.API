using GPICardCore.Master;
using Newtonsoft.Json.Linq;

namespace GPICardCore.Control
{
    public class ControlCardBuilderJson : IControlCardBuilder
    {
        private string MeterType { get; set; }
        private string MeterVersion { get; set; }
        private string ManufacturerId { get; set; }
        private string CardId { get; set; }
        private string DistributionCompanyCode { get; set; }
        private string SectorCode { get; set; }
        private string GeneralDivisionCode { get; set; }
        private string DivisionCode { get; set; }
        private ControlCardActivationPeriod CardDate { get; set; }

        public string CardXML { get; private set; }
        public int CardType { get; private set; }
        public string CardName { get; private set; }
        public List<string> SelectedMeters { get; private set; }


        // Create JSON dynamically like XML
         private JObject jsonControl = new JObject
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
                 ["RelayTime"] = null,
                 ["Relaykw"] = null
             },
             ["isEPayment"] = false,
             ["cardGenerationType"] = 2
         };


  






        public event CardCreatedHandler OnCardCreated;

        

        public string BuildClearTamperCard(List<int> tamperCodelist)
        {
            var _json = this.jsonControl.DeepClone();

            _json["businessData"]["cardType"] = 1;
            _json["businessData"]["ControlCardType"] = 2;
            _json["businessData"]["controlOperationType"] = 2;

            var manipulationsArray = new JArray();

            foreach (var tamperCode in tamperCodelist)
            {
                manipulationsArray.Add(
                    new JObject
                    {
                        ["manipulationOrFaultToBeCleared"] = tamperCode
                    }
                );
            }

            _json["businessData"]["manipulationsAndFaultsToBeCleared"] = manipulationsArray;

            return _json.ToString();
        }


        public string BuildCollectCard()
        {
            return null;             
        }

        

        public string BuildLabCard(List<int> ControlWord  , int AvailableKWh, int AvailableTime)
        {
            var _json = this.jsonControl.DeepClone();

            _json["businessData"]["cardType"] = 1;
            _json["businessData"]["ControlCardType"] = 2;
            _json["businessData"]["controlOperationType"] = 9;

            _json["businessData"]["Relaykw"] = AvailableKWh;
            _json["businessData"]["RelayTime"] = AvailableTime;

            return _json.ToString();
        }

        public string BuildLunchCurrentCard()
        {
            var _json = this.jsonControl.DeepClone();

            _json["businessData"]["cardType"] = 1;
            _json["businessData"]["ControlCardType"] = 2;
            _json["businessData"]["controlOperationType"] = 3;
           
            
            return _json.ToString();
        }

        public string BuildRelayTestCard()
        {
            var _json = this.jsonControl.DeepClone();

            _json["businessData"]["controlOperationType"] = 5;

            return _json.ToString();
        }

        public string BuildResetMeterCard()
        {
            var _json = this.jsonControl.DeepClone();
            _json["businessData"]["controlOperationType"] = 7;
          
            return _json.ToString();
        }

        public string BuildSetDateTimeCard(DateTime DateTimeValue   )
        {
            var _json = this.jsonControl.DeepClone();

            _json["businessData"]["controlOperationType"] = 0;
            _json["businessData"]["setDateAndTimeMode"] = 0;
            _json["businessData"]["meterTimestampToSet"] = DateTimeValue.ToString("dd-MM-yyyy HH:mm");

            return _json.ToString();
        }

        public string BuildSetDateTimeOnMeterManualCard()
        {
            var _json = this.jsonControl.DeepClone();

            _json["businessData"]["controlOperationType"] = 0;
            _json["businessData"]["setDateAndTimeMode"] = 1;
            return _json.ToString();
            
        }

        public string BuildToggleRelayCard(int reverseCardRecoveryTime)
        {
            var _json =  this.jsonControl.DeepClone();
            _json["businessData"]["controlOperationType"] = 5;
            _json["businessData"]["RelayTime"] = reverseCardRecoveryTime;

            return _json.ToString();
        }

        public IControlCardBuilder SetCardId(string cardId)
        {
            if (!string.IsNullOrWhiteSpace(cardId))
            {
                this.CardId = cardId;
                jsonControl["businessData"]["cardId"] = cardId;
               
            }
            else
            {
                throw new Exception("The cardId value is Invalid.");
            }
            return this;
        }

        public IControlCardBuilder SetCardPeriod(ControlCardActivationPeriod cardDate)
        {
            

            this.CardDate = cardDate;
             
            jsonControl["businessData"]["controlCardActivationDate"] = cardDate.ActivationDate;

            jsonControl["businessData"]["controlCardExpiryDate"] = cardDate.ExpiryDate;
            

            
            return this;
        }

        public IControlCardBuilder SetDistributionCompanyCode(string distributionCompanyCode)
        {
            if (!string.IsNullOrWhiteSpace(distributionCompanyCode))
            {
                this.DistributionCompanyCode = distributionCompanyCode;
                jsonControl["businessData"]["distributionCompany"]["companyCode"] = Convert.ToInt32( distributionCompanyCode );
               
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
                jsonControl["businessData"]["manufacturerId"] = manufacturerId;
             }
            else
            {
                throw new Exception("The manufacturerId value is invalid.");
            }
            return this;
        }

        public IControlCardBuilder SetMeterType(string meterType)
        {
           

            if (!string.IsNullOrWhiteSpace(meterType))
            {
                this.MeterType = meterType;
                jsonControl["businessData"]["meterType"] = Convert.ToInt32( meterType) ;
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
                jsonControl["businessData"]["meterVersion"] =  meterVersion;
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
                jsonControl["businessData"]["distributionCompany"]["sectorCode"] = sectorCode;
              
            }
            else
            {
                throw new Exception("The sectorCode value is invalid.");
            }
            return this;
        }

        public IControlCardBuilder SetGeneralDivisionCode(string generalDivisionCode)
        {
            if (!string.IsNullOrWhiteSpace(generalDivisionCode))
            {
                this.GeneralDivisionCode = generalDivisionCode;
                jsonControl["businessData"]["distributionCompany"]["generalDivisionCode"] = generalDivisionCode;

            }
            else
            {
                throw new Exception("The GeneralDivisionCode value is invalid.");
            }
            return this;
        }

        public IControlCardBuilder SetSelectedMeters(List<string> meters)
        {
            if (meters != null && meters.Count > 0)
            {
                this.SelectedMeters = meters;
                jsonControl["businessData"]["numberOfMeter"] = meters.Count;

                // Add the meters list as an array to the "controlMetersList" field
                jsonControl["businessData"]["controlMetersList"] = new JArray(meters);

            }
            else
            {
                throw new Exception("The selected meters list is invalid.");
            }

            return this;
        }


        private void SetAllNull(JObject json)
        {
            foreach (var property in json.Properties().ToList())
            {
                if (property.Value.Type == JTokenType.Object)
                {
                    // Recursively call for nested JObject
                    SetAllNull((JObject)property.Value);
                }
                else if (property.Value.Type == JTokenType.Array)
                {
                    // If it's an array, we can set elements to null or keep them empty
                    JArray array = (JArray)property.Value;
                    foreach (var item in array)
                    {
                        if (item.Type == JTokenType.Object)
                        {
                            SetAllNull((JObject)item);
                        }
                    }
                }
                else
                {
                    // Set to null if the current value is not already null
                    if (property.Value != null)
                    {
                        property.Value = null;
                    }
                }
            }
        }

        public IControlCardBuilder SetDivisionCode(string DivisionCode)
        {
            if (!string.IsNullOrWhiteSpace(DivisionCode))
            {
                this.DivisionCode = DivisionCode;
                jsonControl["businessData"]["distributionCompany"]["divisionCode"] = DivisionCode;

            }
            else
            {
                throw new Exception("The DivisionCode value is invalid.");
            }
            return this;
        }

        public string BuildAlarmCutoffLimitsCard(List<int> limits)
        {
            return null;
        }

        public string BuildAlterTariffCard(List<TariffStep> tariffSteps, TariffHeader header, decimal zeroConsumptionFeeAmount)
        {
            return null;
        }

        public string BuildChangeDistributionCompanyCodeCard(string NewNumber)
        {
            return null;
        }

        public string BuildChangeMeterNumberCard(string currentNumber, string NewNumber)
        {
            return null;
        }

        public string BuildCopyMeterCard(string SourceMeterSerial)
        {
            return null;
        }

        public IControlCardBuilder SetMetersProcessedByControlCard(List<ProcessedMeter> processedMeters)
        {
           return null;
        }

        public IControlCardBuilder SetPreviousMeterEvents(List<PreviousMeterEvent> previousMeterEvents)
        {
            throw new NotImplementedException();
        }
    }
}
