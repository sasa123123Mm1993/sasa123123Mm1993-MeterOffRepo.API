using CardServConvert.Dto;
using CardServConvert.Validator;
using GPICardCore;
using GPICardCore.Control;
using GPICardCore.Master;
using GPICardCore.Reader;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CardServConvert.Controllers
{
    [Route("api/ControlCard")]
    [ApiController]
    public class ControlCardController : ControllerBase
    {
        private readonly ILogger _logger;

        public ControlCardController(ILogger<ControlCardController> logger)
        {
            _logger = logger;
        }



        /// <summary>
        ///  XMl => Unified-Json 
        /// </summary>
        [HttpPost]
        [Route("Write")]
        [Consumes("text/plain")]
        public async Task<IActionResult> Write([FromBody] string xmlCardData)
        {
            _logger.LogInformation("Received XML data: {xmlCardData}", xmlCardData);

            if (! Tools.IsValidXML(xmlCardData))
            {
                 return BadRequest(new
                {
                    Message = "Validation failed",
                    Errors = "Invalid XML format. "
                });

               
            }
            
            CardXmlReader reader = new CardXmlReader(xmlCardData);

            string manufacturerId          = reader.GetValue("manufacturerId");
            string meterType               = reader.GetValue("meterType");
            string meterVersion            = reader.GetValue("meterVersion");
            string cardId                  = reader.GetValue("cardId");
            string distributionCompanyCode = reader.GetValue("distributionCompanyCode");
            string sectorCode              = reader.GetValue("sectorCode");
            string activationDate          = reader.GetChildValue("controlCardActivationPeriod", "controlCardActivationDate");
            string expiryDate              = reader.GetChildValue("controlCardActivationPeriod", "controlCardExpiryDate");

            List<string> ActiveMeters      = reader.GetListValues("controlCardActiveMeters", "controlCardActiveMeter");
            



            ControlCardDto controlCardDto = new ControlCardDto
            {
                ManufacturerId          = manufacturerId,
                MeterType               = meterType,
                MeterVersion            = meterVersion,
                CardId                  = cardId,
                DistributionCompanyCode = distributionCompanyCode,
                SectorCode              = sectorCode,
                ActivationDate          = activationDate,
                ExpiryDate              = expiryDate
            };

            _logger.LogInformation("ControlCardDto: {@controlCardDto}", controlCardDto);

            var result = new ControlCardValidator().Validate(controlCardDto);
            

            if (!result.IsValid)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                _logger.LogError("Validation failed. Errors: {errorMessages}", errorMessages);
                return BadRequest (new
                {
                    Message = "Validation failed",
                    Errors = errorMessages
                });

            }



            ControlCardType cardType = reader.GetControlCardType();
            _logger.LogInformation("ControlCardType: {cardType}", cardType);

            ControlCardBuilderJson contrlcard = new ControlCardBuilderJson();

            contrlcard.SetMeterType(meterType)
            .SetMeterVersion(meterVersion)
            .SetManufacturerId(manufacturerId)
            .SetCardId(cardId)
            .SetSectorCode(sectorCode)  
            .SetGeneralDivisionCode(sectorCode)
            .SetDivisionCode(sectorCode)
            .SetDistributionCompanyCode(distributionCompanyCode)
            .SetCardPeriod(new ControlCardActivationPeriod
            {
                ActivationDate = activationDate,
                ExpiryDate =  expiryDate
            });

            if (ActiveMeters != null && ActiveMeters.Count > 0)
            {
                contrlcard.SetSelectedMeters(ActiveMeters);
            }
           


            string jsonCardData = string.Empty;

            switch (cardType)
            {
                case ControlCardType.RelayTest:
                    _logger.LogInformation("RelayTest card type detected.");
                    jsonCardData = contrlcard.BuildRelayTestCard();
                    break;

                case ControlCardType.ResetMeter:
                    _logger.LogInformation("ResetMeter card type detected.");
                    jsonCardData = contrlcard.BuildResetMeterCard();
                    break;

                case ControlCardType.LunchCurrent:
                    _logger.LogInformation("LunchCurrent card type detected.");
                    jsonCardData = contrlcard.BuildLunchCurrentCard();
                    break;

                case ControlCardType.SetDateTimeAuto:
                    _logger.LogInformation("SetDateTimeAuto card type detected.");
                    jsonCardData = contrlcard.BuildSetDateTimeCard(DateTime.Now);
                    break;

                case ControlCardType.SetDateTimeManual:
                    _logger.LogInformation("SetDateTimeManual card type detected.");
                    jsonCardData = contrlcard.BuildSetDateTimeOnMeterManualCard();
                    break;

                case ControlCardType.ClearTamper:
                    _logger.LogInformation("ClearTamper card type detected.");

                    List<string> tamperListString = reader.GetListValues("manipulationsAndFaultsToBeCleared", "manipulationOrFaultToBeCleared");
                    List<int> tamperList = tamperListString.Select(int.Parse).ToList();

                    jsonCardData = contrlcard.BuildClearTamperCard(tamperList);
                    break;

                case ControlCardType.RelayToggle:
                    _logger.LogInformation("RelayToggle card type detected.");
                    var RecoveryTime      = reader.GetValue("reverseCardRecoveryTime");
                    var RecoveryTimeInMin = int.Parse(RecoveryTime);
                    jsonCardData = contrlcard.BuildToggleRelayCard(RecoveryTimeInMin);
                    break;

                case ControlCardType.Lab:
                    _logger.LogInformation("Lab card type detected.");

                    var AvailableTime = reader.GetValue("labTestCardAvailableTime");
                    var AvailableKWh  = reader.GetValue("labTestCardAvailableKWh");
                    var AvailableTimeInMin = int.Parse(AvailableTime);
                    var AvailableKWhInt   = int.Parse(AvailableKWh);

                    jsonCardData = contrlcard.BuildLabCard(null , AvailableKWhInt , AvailableTimeInMin );
                    break;

                default:
                    _logger.LogError("Unsupported card type: {cardType}", cardType);    
                    return BadRequest($"Unsupported Card Type. [{cardType}]");
            }
            _logger.LogInformation("Generated JSON card data: {jsonCardData}", jsonCardData);
            return Ok(jsonCardData);


        }


        /// <summary>
        /// Unified-Json => XMl 
        /// </summary>
        [HttpPost]
        [Route("Read")]
       // [Consumes("text/plain")]
        public async Task<IActionResult> Read( [FromBody] string jsonCardData)
        {
            _logger.LogInformation("Received JSON data: {jsonCardData}", jsonCardData);

            if (!Tools.IsValidJson(jsonCardData.ToString()))
            {
                 return BadRequest(new
                {
                    Message = "Validation failed",
                    Errors = "Invalid Json format. "
                });


            }

            CardJsonReader reader = new CardJsonReader(jsonCardData);
            string xmlDataResult = string.Empty;

            if (reader.ParsedData.StatusCode == 200)
            {

                var cardId                    = reader.ParsedData.Data.Payload.CardId;
                var cardType                  = reader.ParsedData.Data.Payload.CardType;
                var technicianCode            = reader.ParsedData.Data.Payload.TechnicianCode;
                var controlCardType           = reader.ParsedData.Data.Payload.ControlCardType;
                var numberOfMeter             = reader.ParsedData.Data.Payload.NumberOfMeter;
                var controlMetersList         = reader.ParsedData.Data.Payload.ControlMetersList;
                var controlOperationType      = reader.ParsedData.Data.Payload.ControlOperationType;
                var controlCardActivationDate = reader.ParsedData.Data.Payload.ControlCardActivationDate;
                var controlCardExpiryDate     = reader.ParsedData.Data.Payload.ControlCardExpiryDate;

                var meterDataList =  reader.GetMeterData();



                ControlCardBuilderXml card2 = new ControlCardBuilderXml();

                card2
                .SetMeterType("0")
                .SetMeterVersion("GPM-PP01")
                .SetManufacturerId("07")
                .SetCardId(cardId)
                 // .SetSectorCode("02")
                 //.SetDistributionCompanyCode("9")

                 .SetCardPeriod(new ControlCardActivationPeriod
                 {
                     ActivationDate = controlCardActivationDate,
                     ExpiryDate     = controlCardExpiryDate
                 });

                var processedMeters = new List<ProcessedMeter>();

                foreach (var item in meterDataList)
                {
                    processedMeters.Add(new ProcessedMeter
                    {
                        ProcessedMeterId = item.MeterId,
                        ProcessingTimestamp = DateTime.Now.ToString("dd-MM-yyyy"),
                        CurrentMeterStatus = item.MeterStatusCode.ToString(),
                        OldMeterStatus = item.BeforeMeterStatusCode.ToString(),
                        MeterInstallationDate = item.MeterEvents.MeterInstallationLog?.MeterInstallationDate,
                        MeterInstallerID = item.MeterEvents.MeterInstallationLog?.MeterInstallationTechCode.ToString(),
                        CustomerId = item.CustomerId
                    });
                }
                // Set once, after the loop
                card2.SetMetersProcessedByControlCard(processedMeters);


                var previousMeterEvents = new List<GPICardCore.Master.PreviousMeterEvent>();

                foreach (var item in meterDataList)
                {
                    if (item.MeterEvents?.PreviousMeterEvents != null)
                    {
                        foreach (var evt in item.MeterEvents.PreviousMeterEvents)
                        {
                            previousMeterEvents.Add(new GPICardCore.Master.PreviousMeterEvent
                            {
                                MeterNo = item.MeterId,
                                PreviousMeterEventCode = evt.PreviousMeterEventCode.ToString(),
                                PreviousMeterEventTime = evt.PreviousMeterEventTime,
                                PreviousMeterEventRemovalTime = evt.PreviousMeterEventRemovalTime,
                                PreviousMeterEventRemovalCardId = evt.PreviousMeterEventRemovalTechnicianCode.ToString()
                            });
                        }
                    }

                    if (item.MeterEvents.MeterDateTimeAdjustments != null)
                    {
                        foreach (var evt in item.MeterEvents.MeterDateTimeAdjustments)
                        {
                            previousMeterEvents.Add(new GPICardCore.Master.PreviousMeterEvent
                            {
                                MeterNo = item.MeterId,
                                PreviousMeterEventCode = "9",
                                PreviousMeterEventTime = evt.EventDateTime,
                                PreviousMeterEventRemovalTime = evt.EventDateTime,
                                PreviousMeterEventRemovalCardId = evt.CardNumber
                            });
                        }
                    }




                }

                card2.SetPreviousMeterEvents(previousMeterEvents);



                 xmlDataResult  = card2.BuildRetunCard();









            }

            return Ok(xmlDataResult);

           
        }



    }


   


}
