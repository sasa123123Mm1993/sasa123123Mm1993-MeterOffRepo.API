using GPICardCore;
using GPICardCore.Control;
using GPICardCore.Master;
using GPICardCore.Reader;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CardServConvert.Controllers
{
    [Route("api/GpiServ")]
    [ApiController]
    public class GpiServController : ControllerBase
    {


        [HttpPost]
        [Route("Write")]
        public async Task<IActionResult> ConvertGpiServ( string xmlCardData)
        {
            if (!IsValidXML(xmlCardData))
            {
                return BadRequest("Invalid XML format.");
            }

            CardXmlReader reader = new CardXmlReader(xmlCardData);

            string manufacturerId          = reader.GetValue("manufacturerId");
            string cardId                  = reader.GetValue("cardId");
            string distributionCompanyCode = reader.GetValue("distributionCompanyCode");
            string sectorCode              = reader.GetValue("sectorCode");
            string activationDate          = reader.GetChildValue("controlCardActivationPeriod", "controlCardActivationDate");
            string expiryDate              = reader.GetChildValue("controlCardActivationPeriod", "controlCardExpiryDate");

            ControlCardType cardType = reader.GetControlCardType();


            IControlCardBuilder contrlcard = new ControlCardBuilderJson();

            contrlcard.SetMeterType(0)
            .SetMeterVersion("6")
            .SetManufacturerId("6")
            .SetCardId(cardId)
            .SetSectorCode(sectorCode)
            .SetDistributionCompanyCode("9")

            .SetCardPeriod(new ControlCardActivationPeriod
            {
                ActivationDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(99)
            });


            string jsonCardData="";

            switch (cardType)
            {
                case ControlCardType.RelayTest:
                    jsonCardData = contrlcard.BuildRelayTestCard();
                    break;

                case ControlCardType.ResetMeter:
                    jsonCardData = contrlcard.BuildResetMeterCard();
                    break;

                case ControlCardType.LunchCurrent:
                    jsonCardData = contrlcard.BuildLunchCurrentCard();
                    break;

                case ControlCardType.SetDateTimeAuto:
                    jsonCardData = contrlcard.BuildSetDateTimeCard(DateTime.Now);
                    break;

                case ControlCardType.SetDateTimeManual:
                    jsonCardData = contrlcard.BuildSetDateTimeOnMeterManualCard();
                    break;

                case ControlCardType.ClearTamper:
                    jsonCardData = contrlcard.BuildClearTamperCard(new List<int> { 1, 2, 3 });
                    break;

                case ControlCardType.RelayToggle:
                    jsonCardData = contrlcard.BuildToggleRelayCard(1);
                    break;

                case ControlCardType.Lab:
                    jsonCardData = contrlcard.BuildLabCard(null, 11, 22);
                    break;

                default:
                    return BadRequest("Unsupported card type.");
            }

            return Ok(jsonCardData);


        }

        private bool IsValidXML(string xml)
        {
            if (string.IsNullOrWhiteSpace(xml))
                return false;

            try
            {
                XDocument.Parse(xml);  
                return true;
            }
            catch
            {
                return false;
            }
        }
    }


   


}
