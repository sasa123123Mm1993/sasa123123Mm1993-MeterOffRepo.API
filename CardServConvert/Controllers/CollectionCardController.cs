using CardServConvert.Validator;
using GPICardCore.Control;
using GPICardCore.Master;
using GPICardCore.Reader;
using GPICardCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CardServConvert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionCardController : ControllerBase
    {
        private readonly ILogger _logger;

        public CollectionCardController(ILogger<CollectionCardController> logger)
        {
            _logger = logger;
        }



        [HttpPost]
        [Route("Write")]
        [Consumes("text/plain")]
        public async Task<IActionResult> Write ([FromBody] string xmlCardData)
        {
            if (!Tools.IsValidXML(xmlCardData))
            {
                _logger.LogError("Invalid XML format. {xmlCardData}", xmlCardData);
                return BadRequest(new
                {
                    Message = "Validation failed",
                    Errors = "Invalid XML format. "
                });


            }
            _logger.LogInformation("Received XML data: {xmlCardData}", xmlCardData);

            
            CardXmlReader reader = new CardXmlReader(xmlCardData);

            string manufacturerId = reader.GetValue("manufacturerId");
            string meterType = reader.GetValue("meterType");
            string meterVersion = reader.GetValue("meterVersion");
            string cardId = reader.GetValue("cardId");
            string distributionCompanyCode = reader.GetValue("distributionCompanyCode");
           
            string expiryDate = reader.GetChildValue("controlCardActivationPeriod", "controlCardExpiryDate");
           
            string controlOperationType = reader.GetValue("controlOperationType"); 
            string cardType             = reader.GetValue("cardType");

            bool IsCollectionXML = (cardType=="1" && controlOperationType=="2")? true : false;

            if (IsCollectionXML)
            {
                CollectionCardBuilderJson builderJson = new CollectionCardBuilderJson();


                var result = builderJson
                     .SetMeterType(Convert.ToInt32(meterType))
                     .SetMeterVersion(meterVersion)
                     .SetManufacturerId(manufacturerId)
                     .SetCardId(cardId)
                     .SetCollectionCardExpiryDate(expiryDate)
                     .SetCompanyCode(Convert.ToInt32(distributionCompanyCode))
                     .SetCompanyLevel(1)
                     .Create();

                return Ok(result.ToString());
            }
            else
            {
                return BadRequest(new
                {
                    Message = "Validation failed",
                    Errors = "Invalid Collection Card. "
                });

            }

        }






    }
}
