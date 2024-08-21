﻿using System.Xml.Linq;
using GPICardCore.Master;

namespace GPICardCore
{

    public delegate void CardCreatedHandler(ControlCardBuilder controlCard);
    public class ControlCardBuilder
    {
        private int   MeterType { get; set; }
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

        public event CardCreatedHandler OnCardCreated;

       // private const int MaximumMeterNumberLength = 8;


        private XDocument defaultXml = new XDocument(
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
     
   
    
        public void SetMeterType (int  meterType)
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

        public void SetMeterVersion(string meterVersion)
        {
            if (!string.IsNullOrWhiteSpace(meterVersion))
            {
                this.MeterVersion = meterVersion;
                defaultXml.Root.Element("meterVersion").Value = meterVersion;
            }
            else
            {
                throw new Exception("The meterVersion value is invalid.");
            }

        }


        public void SetManufacturerId(string manufacturerId)
        {
            if (!string.IsNullOrWhiteSpace(manufacturerId))
            {
                this.ManufacturerId = manufacturerId;
                defaultXml.Root.Element("manufacturerId").Value = manufacturerId;
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
                defaultXml.Root.Element("cardId").Value = cardId;
            }
            else
            {
                throw new Exception("The cardId value is invalid.");
            }
        }



        public void SetDistributionCompanyCode(string distributionCompanyCode)
        {
            if (!string.IsNullOrWhiteSpace(distributionCompanyCode))
            {
                this.DistributionCompanyCode = distributionCompanyCode;
                defaultXml.Root
                .Element("distributionCompanyCode")
                .Value = distributionCompanyCode;
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
                defaultXml.Root
               .Element("sectorCode")
               .Value = sectorCode;
            }
            else
            {
                throw new Exception("The sectorCode value is invalid.");
            }

        }

        public void SetSelectedMeters(List<string> meters)
        {
            if (meters == null || meters.Count == 0) return;
            
            var ActiveMeters = new XElement("controlCardActiveMeters");

            foreach (var item in meters)
            {
                if (! Validate.ValidMeterNo(item))
                {
                    throw new Exception($"Meter length invalid : [{item}] .");
                }

                if (item.Length < 1) throw new Exception($"Meter length Invalid : [{item}] .");

                ActiveMeters.Add(new XElement("controlCardActiveMeter", item));
            }

            defaultXml.Element("meterData")
            .Add(ActiveMeters);
        }

        public void SetCardPeriod(ControlCardActivationPeriod cardDate)
        {
            if (!(cardDate.ExpiryDate >= cardDate.ActivationDate) )
            {
                throw new Exception(" ExpiryDate less than ActivationDate");
            }

            this.CardDate = cardDate;
            defaultXml.Root
            .Element("controlCardActivationPeriod")
            .Element("controlCardActivationDate")
            .Value = this.CardDate.ActivationDate.ToString("dd-MM-yyyy");
           

            defaultXml.Root
            .Element("controlCardActivationPeriod")
            .Element("controlCardExpiryDate")
            .Value = this.CardDate.ExpiryDate.ToString("dd-MM-yyyy");
           
        }
           
    
        


        public string BuildToggleRelayCard()
        {
            
            XDocument local = new XDocument(this.defaultXml);

            local.Element("meterData")
            .Add(new XElement("controlOperationType", "5"));

            

            this.CardXML = local.ToString();
            this.CardName = ControlCardType.RelayToggle.ToString();
            OnCardCreated?.Invoke(this);
            return local.ToString();

        }


        public string BuildCollectCard()
        {

            XDocument local = new XDocument(this.defaultXml);

            local.Element("meterData")
            .Add(new XElement("controlOperationType", "2"));



            this.CardXML = local.ToString();
            this.CardName = ControlCardType.Collect.ToString();
            OnCardCreated?.Invoke(this);
            return local.ToString();

        }



        public string BuildChangeDistributionCompanyCodeCard(string NewNumber)
        {
              

            if (string.IsNullOrWhiteSpace(NewNumber))
            {
                throw new Exception($"New CompanyCode [{NewNumber}] is Invalid  .");
            }

          
            
            XDocument local = new XDocument(this.defaultXml);

            local.Element("meterData")
             .Add(new XElement("controlOperationType", "50"));

         
            local.Element("meterData")
            .Add(new XElement("newDistributionCompanyCode", NewNumber));
                        

            this.CardXML = local.ToString();
            this.CardName = ControlCardType.ChangeCompany.ToString();
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }
        public string BuildChangeMeterNumberCard(string currentNumber , string NewNumber)
        {
            
            
            if (!Validate.ValidMeterNo( currentNumber) )
            {
                throw new Exception($"Current Meter Number [{currentNumber}] is Invalid  .");
            }

            if (!Validate.ValidMeterNo(NewNumber))
            {
                throw new Exception($"New Meter Number [{NewNumber}] is Invalid  .");
            }

            

           
            XDocument local = new XDocument(this.defaultXml);

            local.Element("meterData")
                 .Add(new XElement("controlOperationType", "51"));

            local.Element("meterData")
                .Add(new XElement("meterId", currentNumber ));

            local.Element("meterData")
            .Add(new XElement("newMeterId", NewNumber));

            

            this.CardXML = local.ToString();
            this.CardName = ControlCardType.ChangeMeterNumber.ToString();
            OnCardCreated?.Invoke(this);
            return local.ToString();

        }
        public string BuildLunchCurrentCard()
        {
            
            XDocument local = new XDocument(this.defaultXml);

            local.Element("meterData")
             .Add(new XElement("controlOperationType", "52"));

             
            this.CardXML = local.ToString();
            this.CardName = ControlCardType.LunchCurrent.ToString();
            OnCardCreated?.Invoke(this);
            return local.ToString();

        }
        public string BuildRelayTestCard()
        {
            
            XDocument local = new XDocument(this.defaultXml);

            local.Element("meterData")
           .Add(new XElement("controlOperationType", "6"));

            

            this.CardXML = local.ToString();
            this.CardName = ControlCardType.RelayTest.ToString();
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }
        public string BuildResetCard()
        {
            

            XDocument local = new XDocument(this.defaultXml);

            local.Element("meterData")
             .Add(new XElement("resetMeterMode", 0));

            local.Element("meterData")
           .Add(new XElement("customerOperationType", 2));

            local.Root.Element("cardType").Value = "0";

            

            this.CardXML = local.ToString();
            this.CardName = ControlCardType.Reset.ToString();
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }
        public string BuildSetDateTimeCard(DateTime DateTimeValue)
        {
            

            XDocument local = new XDocument(this.defaultXml);

            local.Element("meterData")
             .Add(new XElement("setDateAndTimeMode", "0"));
                        
            local.Element("meterData")
           .Add(new XElement("meterTimestampToSet", DateTimeValue.ToString("dd-MM-yyyy HH:mm") ));

            local.Element("meterData")
           .Add(new XElement("controlOperationType", "0"));

            local.Root.Element("cardType").Value = "1";

            

            this.CardXML = local.ToString();
            this.CardName = ControlCardType.SetDateTime.ToString();
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }
        public string BuildSetDateTimeOnMeterManualCard()
        {
            

            XDocument local = new XDocument(this.defaultXml);

            local.Element("meterData")
            .Add(new XElement("setDateAndTimeMode", "1"));

          
            local.Element("meterData")
           .Add(new XElement("controlOperationType", "0"));

            local.Root.Element("cardType").Value = "1";

            

            this.CardXML = local.ToString();
            this.CardName = ControlCardType.SetDateTimeOnMeter.ToString();
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }
        public string BuildClearTamperCard(List<int> tamperCodelist )
        {
            

            if (tamperCodelist.Count == 0)
            {
                throw new Exception("tamper Code list is Empty .");
            }
            

            XDocument local = new XDocument(this.defaultXml);

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

             

            this.CardXML = local.ToString();
            this.CardName = ControlCardType.ClearTamper.ToString();
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }


        public string BuildAlterTariffCard(List<TariffStep> tariffSteps,  TariffHeader header , decimal zeroConsumptionFeeAmount)
        {
            
            ValidateTariffSteps(tariffSteps);

            XDocument local = new XDocument(this.defaultXml);

            local.Element("meterData")
          .Add(new XElement("editMeterDataOperations",
          new XElement("editMeterDataOperation", 1)));

            local.Element("meterData")
           .Add(new XElement("controlOperationType", 4 ));


            local.Element("meterData")
           .Add(new XElement("zeroConsumptionFeeAmount", zeroConsumptionFeeAmount ));

           
         




         var tariffsDetails = new XElement("tariffsDetails",
         new XElement("tariffDetails",
         new XElement("tariffId", header.tariffId ),
         new XElement("tariffVersion"        , header.tariffVersion ),
         new XElement("tariffGraceType"      , header.tariffGraceType ),
         new XElement("tariffGracevalue"     , header.tariffGracevalue ),
         new XElement("tariffAlarmGrace"     , header.tariffAlarmGrace ),
         new XElement("tariffLimitGrace"     , header.tariffLimitGrace ),
         new XElement("tariffDeductionGrace" , header.tariffDeductionGrace),
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

                if (step.TariffStepRecalculationEdge is > 0)
                {                     
                   stepElement.Add(new XElement("tariffStepRecalculationEdge", step.TariffStepRecalculationEdge.Value));
                    
                }

                if (step.TariffStepRecalculationEdgeAddedAmount is > 0)
                {
                    stepElement.Add(new XElement("tariffStepRecalculationEdgeAddedAmount", step.TariffStepRecalculationEdgeAddedAmount.Value));
                }

                tariffStepsElement.Add(stepElement);
            }

            local.Element("meterData").Add(tariffsDetails);



            


            this.CardXML = local.ToString();
            this.CardName = ControlCardType.TarrifUpdate.ToString();
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
            

            XDocument local = new XDocument(this.defaultXml);

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



             

            this.CardXML = local.ToString();
            this.CardName = ControlCardType.AlarmCutoffLimits.ToString();
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }


        public string BuildLabCard(List<int> ControlWord , int AvailableKWh , int AvailableTime    )
        {
            

            XDocument local = new XDocument(this.defaultXml);

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

             

            this.CardXML = local.ToString();
            this.CardName = ControlCardType.Lab.ToString();
            OnCardCreated?.Invoke(this);
            return local.ToString();
        }





    }
}
