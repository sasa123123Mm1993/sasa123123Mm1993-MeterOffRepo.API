using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace GPICardCore
{

    public delegate void CardCreatedHandler(ControlCardBuilder controlCard);
    public class ControlCardBuilder
    {
        private string MeterType { get; set; }
        private string MeterVersion { get; set; }
        private string ManufacturerId { get; set; }
        private string CardId { get; set; }
        private string DistributionCompanyCode { get; set; }
        private string SectorCode { get; set; }
        private CardPeriod CardDate { get; set; }

        public string CardXML { get; private set; }
        public ControlCardType CardType { get; private set; }

        public List<string> SelectedMeters { get; private set; }

        public event CardCreatedHandler OnCardCreated;

        private const int MaximumMeterNumberLength = 8;


        private XDocument defultXml = new XDocument(
        new XElement("meterData",
        new XElement("meterType"),
        new XElement("meterVersion"),
        new XElement("manufacturerId"),
        new XElement("cardId"),
        new XElement("cardType", "1"),

        new XElement("distributionCompanyCode"),
        new XElement("sectorCode"),
        new XElement("controlCardActivationPeriod",
            new XElement("controlCardActivationDate"),
            new XElement("controlCardExpiryDate")
        )));
     
   
    
        public void SetMeterType (string meterType)
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


        public void SetDistributionCompanyCode(string distributionCompanyCode)
        {
            this.DistributionCompanyCode = distributionCompanyCode;
        }

        public void SetSectorCode(string sectorCode)
        {
            this.SectorCode = sectorCode;
        }

        public void SetSelectedMeters(List<string> meters)
        {
            if (meters == null || meters.Count == 0) return;
            
            var ActiveMeters = new XElement("controlCardActiveMeters");

            foreach (var item in meters)
            {
                if (item.Length > MaximumMeterNumberLength)
                {
                    throw new Exception($"Meter length Exceeds [{MaximumMeterNumberLength}] : [{item}] .");
                }

                if (item.Length < 1) throw new Exception($"Meter length Invalid : [{item}] .");

                ActiveMeters.Add(new XElement("controlCardActiveMeter", item));
            }

            defultXml.Element("meterData")
            .Add(ActiveMeters);
        }

        public void SetCardPeriod(CardPeriod cardDate)
        {
            this.CardDate = cardDate;
            defultXml.Root
            .Element("controlCardActivationPeriod")
            .Element("controlCardActivationDate")
            .Value = this.CardDate.ActivationDate.ToString("dd-MM-yyyy");
           

            defultXml.Root
            .Element("controlCardActivationPeriod")
            .Element("controlCardExpiryDate")
            .Value = this.CardDate.ExpiryDate.ToString("dd-MM-yyyy");
           
        }
           
        private void SetDefaultValues(XDocument local)
        {
            local.Root.Element("meterType").Value = this.MeterType;
            local.Root.Element("meterVersion").Value = this.MeterVersion;
            local.Root.Element("manufacturerId").Value = this.ManufacturerId;
            local.Root.Element("cardId").Value = this.CardId;
            local.Root.Element("sectorCode").Value = this.SectorCode;
            local.Root.Element("distributionCompanyCode").Value = this.DistributionCompanyCode;
        }
        private void ValidateSettersData()
        {
            if (string.IsNullOrWhiteSpace(this.MeterType)) throw new Exception("Please Set MeterType .");
            if (string.IsNullOrWhiteSpace(this.MeterVersion)) throw new Exception("Please Set MeterVersion .");
            if (string.IsNullOrWhiteSpace(this.ManufacturerId)) throw new Exception("Please Set ManufacturerId .");
            if (string.IsNullOrWhiteSpace(this.CardId)) throw new Exception("Please Set CardId For Technician .");
            if (string.IsNullOrWhiteSpace(this.DistributionCompanyCode)) throw new Exception("Please Set DistributionCompanyCode .");
            if (string.IsNullOrWhiteSpace(this.SectorCode)) throw new Exception("Please Set SectorCode .");

            if (this.CardDate == null)
            {
                throw new Exception("Please Set controlCardActivationPeriod [ActivationDate] [ExpiryDate] ");
            }
            else if (this.CardDate.ActivationDate == null)
            {
                throw new Exception("Please Set ActivationDate ");
            }
            else if (this.CardDate.ExpiryDate == null)
            {
                throw new Exception("Please Set ExpiryDate ");
            }
            if (!(this.CardDate.ExpiryDate >= this.CardDate.ActivationDate))
            {
                throw new Exception("ExpiryDate Expiry date is not valid .");
            }



        }


        public string BuildToggleRelayCard()
        {
            ValidateSettersData();
            XDocument local = new XDocument(this.defultXml);

            local.Element("meterData")
             .Add(new XElement("controlOperationType", "5"));

            SetDefaultValues(local);

            this.CardXML = local.ToString();
            this.CardType = ControlCardType.RelayToggle;
            OnCardCreated?.Invoke(this);
            return local.ToString();

        }
        public string BuildChangeCompanyCodeCard(string NewNumber)
        {
            ValidateSettersData();

            if (string.IsNullOrWhiteSpace(NewNumber))
            {
                throw new Exception($"New CompanyCode [{NewNumber}] is Invalid  .");
            }

            if (NewNumber.Trim() == this.DistributionCompanyCode.Trim())
            {
                throw new Exception($"New CompanyCode [{NewNumber}] is same old Number   .");
            }

            
            XDocument local = new XDocument(this.defultXml);

            local.Element("meterData")
             .Add(new XElement("controlOperationType", "50"));

         
            local.Element("meterData")
            .Add(new XElement("newDistributionCompanyCode", NewNumber));

            SetDefaultValues(local);

            this.CardXML = local.ToString();
            this.CardType = ControlCardType.ChangeCompany;
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }
        public string BuildChangeMeterNumberCard(string currentNumber , string NewNumber)
        {
            ValidateSettersData();
            
            if (string.IsNullOrWhiteSpace(currentNumber))
            {
                throw new Exception($"Current Meter Number [{currentNumber}] is Invalid  .");
            }

            if (string.IsNullOrWhiteSpace(NewNumber))
            {
                throw new Exception($"New Meter Number [{NewNumber}] is Invalid  .");
            }

            if (NewNumber.Length > MaximumMeterNumberLength )
            {
                throw new Exception($"New Meter Number Length exceed [{MaximumMeterNumberLength}] digits [{NewNumber}] .");
            }

           
            XDocument local = new XDocument(this.defultXml);

            local.Element("meterData")
             .Add(new XElement("controlOperationType", "51"));

            local.Element("meterData")
            .Add(new XElement("meterId", currentNumber ));

            local.Element("meterData")
            .Add(new XElement("newMeterId", NewNumber));

            SetDefaultValues(local);

            this.CardXML = local.ToString();
            this.CardType = ControlCardType.ChangeMeterNumber;
            OnCardCreated?.Invoke(this);
            return local.ToString();

        }
        public string BuildLunchCurrentCard()
        {
            ValidateSettersData();
            XDocument local = new XDocument(this.defultXml);

            local.Element("meterData")
             .Add(new XElement("controlOperationType", "52"));

            SetDefaultValues(local);

            this.CardXML = local.ToString();
            this.CardType = ControlCardType.LunchCurrent;
            OnCardCreated?.Invoke(this);
            return local.ToString();

        }
        public string BuildRelayTestCard()
        {
            ValidateSettersData();
            XDocument local = new XDocument(this.defultXml);

            local.Element("meterData")
           .Add(new XElement("controlOperationType", "6"));

            SetDefaultValues(local);

            this.CardXML = local.ToString();
            this.CardType = ControlCardType.RelayTest;
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }
        public string BuildResetCard()
        {
            ValidateSettersData();

            XDocument local = new XDocument(this.defultXml);

            local.Element("meterData")
             .Add(new XElement("resetMeterMode", "0"));

            local.Element("meterData")
           .Add(new XElement("customerOperationType", "2"));

            local.Root.Element("cardType").Value = "0";

            SetDefaultValues(local);

            this.CardXML = local.ToString();
            this.CardType = ControlCardType.Reset;
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }
        public string BuildSetDateTimeCard(DateTime DateTimeValue)
        {
            ValidateSettersData();

            XDocument local = new XDocument(this.defultXml);

            local.Element("meterData")
             .Add(new XElement("setDateAndTimeMode", "0"));
                        
            local.Element("meterData")
           .Add(new XElement("meterTimestampToSet", DateTimeValue.ToString("dd-MM-yyyy HH:mm") ));

            local.Element("meterData")
           .Add(new XElement("controlOperationType", "0"));

            local.Root.Element("cardType").Value = "1";

            SetDefaultValues(local);

            this.CardXML = local.ToString();
            this.CardType = ControlCardType.SetDateTime;
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }
        public string BuildSetDateTimeOnMeterManualCard()
        {
            ValidateSettersData();

            XDocument local = new XDocument(this.defultXml);

            local.Element("meterData")
            .Add(new XElement("setDateAndTimeMode", "1"));

          
            local.Element("meterData")
           .Add(new XElement("controlOperationType", "0"));

            local.Root.Element("cardType").Value = "1";

            SetDefaultValues(local);

            this.CardXML = local.ToString();
            this.CardType = ControlCardType.SetDateTimeOnMeter;
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }
        public string BuildClearTamperCard(List<int> tamperCodelist )
        {
            ValidateSettersData();

            if (tamperCodelist.Count == 0)
            {
                throw new Exception("tamper Code list is Empty .");
            }
            

            XDocument local = new XDocument(this.defultXml);

            var manipulationsAndFaultsToBeCleared = new XElement("manipulationsAndFaultsToBeCleared");
         
            foreach (int code in tamperCodelist)
            {
                manipulationsAndFaultsToBeCleared.Add(new XElement("manipulationOrFaultToBeCleared", code));
            }

            local.Element("meterData")
            .Add(manipulationsAndFaultsToBeCleared);

            local.Element("meterData")
           .Add(new XElement("controlOperationType", 3 ));

            local.Root.Element("cardType").Value = "1";

            SetDefaultValues(local);

            this.CardXML = local.ToString();
            this.CardType = ControlCardType.ClearTamper;
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }


        public string BuildAlterTariffCard(List<TariffStep> tariffSteps,  int tariffId , decimal zeroConsumptionFeeAmount)
        {
            ValidateSettersData();
            ValidateTariffSteps(tariffSteps);

            XDocument local = new XDocument(this.defultXml);

            local.Element("meterData")
           .Add(new XElement("controlOperationType", 4 ));


            local.Element("meterData")
           .Add(new XElement("zeroConsumptionFeeAmount", zeroConsumptionFeeAmount ));

            local.Element("meterData")
           .Add(new XElement("editMeterDataOperations",
           new XElement("editMeterDataOperation", 1 )));
         




            var tariffsDetails = new XElement("tariffsDetails",
         new XElement("tariffDetails",
         new XElement("tariffId", tariffId ),
         new XElement("tariffVersion"),
         new XElement("tariffGraceType"),
         new XElement("tariffGracevalue"),
         new XElement("tariffAlarmGrace"),
         new XElement("tariffLimitGrace"),
         new XElement("tariffDeductionGrace"),
         new XElement("tariffSteps")
            )
            );

            var tariffStepsElement = tariffsDetails.Element("tariffDetails").Element("tariffSteps");

            foreach (var step in tariffSteps)
            {
                var stepElement = new XElement("tariffStep",
                    new XElement("tariffStepCustomerServiceFee", step.TariffStepCustomerServiceFee),
                    new XElement("tariffStepLimitFrom", step.TariffStepLimitFrom),
                    new XElement("tariffStepLimitTo", step.TariffStepLimitTo),
                    new XElement("tariffStepNumber", step.TariffStepNumber),
                    new XElement("tariffStepPrice", step.TariffStepPrice)
                );

                if (step.TariffStepRecalculationEdge.HasValue)
                {
                    stepElement.Add(new XElement("tariffStepRecalculationEdge", step.TariffStepRecalculationEdge.Value));
                }

                if (step.TariffStepRecalculationEdgeAddedAmount.HasValue)
                {
                    stepElement.Add(new XElement("tariffStepRecalculationEdgeAddedAmount", step.TariffStepRecalculationEdgeAddedAmount.Value));
                }

                tariffStepsElement.Add(stepElement);
            }

            local.Element("meterData").Add(tariffsDetails);



            SetDefaultValues(local);


            this.CardXML = local.ToString();
            this.CardType = ControlCardType.TarrifUpdate;
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }

        private void ValidateTariffSteps(List<TariffStep> tariffSteps)
        {
            if (tariffSteps == null) throw new Exception("TariffStep list is NULL .");

            if (tariffSteps.Count ==0 ) throw new Exception("TariffStep list is Empty .");


            foreach (var item in tariffSteps)
            {
                if (!(item.TariffStepLimitFrom > 0 && item.TariffStepLimitFrom <= 999999))
                {
                    throw new Exception("TariffStepLimitFrom Invalid Value .");
                }

                if (!(item.TariffStepLimitTo > 0 && item.TariffStepLimitTo <= 999999))
                {
                    throw new Exception("TariffStepLimitTo Invalid Value .");
                }

                if (!(item.TariffStepCustomerServiceFee >= 0))
                {
                    throw new Exception("TariffStepCustomerServiceFee Invalid Value .");
                }

                if (!(item.TariffStepPrice >= 0))
                {
                    throw new Exception("TariffStepPrice Invalid Value .");
                }
            }
        }



        public string BuildAlarmCutoffLimitsCard( List<int> limits)
        {
            ValidateSettersData();

            XDocument local = new XDocument(this.defultXml);

            local.Element("meterData")
           .Add(new XElement("editMeterDataOperations",
            new XElement("editMeterDataOperation", "0")));

            local.Element("meterData")
           .Add(new XElement("controlOperationType", 4));

            var CutoffLimits = new XElement("balanceAlarmCutoffLimits");

            foreach (var item in limits)
            {
                CutoffLimits.Add(new XElement("cutoffAlarmLimitBalance", item));
            }

            local.Element("meterData")
            .Add(CutoffLimits);



            SetDefaultValues(local);

            this.CardXML = local.ToString();
            this.CardType = ControlCardType.AlarmCutoffLimits;
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }


        public string BuildLabCard(List<int> ControlWord , int AvailableKWh , int AvailableTime    )
        {
            ValidateSettersData();

            XDocument local = new XDocument(this.defultXml);

            local.Element("meterData")
           .Add(new XElement("labTestCardAvailableTime", AvailableTime));

            local.Element("meterData")
           .Add(new XElement("labTestCardAvailableKWh" , AvailableKWh));



            local.Element("meterData")
           .Add(new XElement("controlOperationType", 53 ));

            var ControlWords = new XElement("labTestCardControlWords");

            foreach (var item in ControlWord)
            {
                ControlWords.Add(new XElement("labTestCardControlWord", item));
            }

            local.Element("meterData")
            .Add(ControlWords);

            SetDefaultValues(local);

            this.CardXML = local.ToString();
            this.CardType = ControlCardType.Lab;
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }





    }
}
