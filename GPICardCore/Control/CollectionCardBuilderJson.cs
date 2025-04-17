using Newtonsoft.Json.Linq;

namespace GPICardCore.Control
{

    public class CollectionCardBuilderJson
    {
        // Required fields
        private int meterType;
        private string meterVersion;
        private string manufacturerId;
        private string cardId;
        private int? companyCode;
        private int? companyLevel;

        // Optional fields with default values
        private string collectorCode = null;
        private int controlOperationType = 2;
        private string collectionCardExpiryDate = null;
        private string encryptionKey = null;

        private int? techCodeRegion  ;
        private int? sectorCode  ;
        private int? generalDivisionCode  ;
        private int? divisionCode  ;
        private int? rechargeCenterCode ;
        private int? indirectCompanyCode  ;

        private bool isEPayment = false;
        private int cardGenerationType = 2;

        // ====== Fluent Setters ======

        // Required
        public CollectionCardBuilderJson SetMeterType(int value) { meterType = value; return this; }
        public CollectionCardBuilderJson SetMeterVersion(string value) { meterVersion = value; return this; }
        public CollectionCardBuilderJson SetManufacturerId(string value) { manufacturerId = value; return this; }
        public CollectionCardBuilderJson SetCardId(string value) { cardId = value; return this; }
        public CollectionCardBuilderJson SetCompanyCode(int value) { companyCode = value; return this; }
        public CollectionCardBuilderJson SetCompanyLevel(int value) { companyLevel = value; return this; }

        // Optional
        public CollectionCardBuilderJson SetCollectorCode(string value) { collectorCode = value; return this; }
 
        public CollectionCardBuilderJson SetCollectionCardExpiryDate(string value) { collectionCardExpiryDate = value; return this; }
        public CollectionCardBuilderJson SetEncryptionKey(string value) { encryptionKey = value; return this; }

        public CollectionCardBuilderJson SetTechCodeRegion(int value) { techCodeRegion = value; return this; }
        public CollectionCardBuilderJson SetSectorCode(int value) { sectorCode = value; return this; }
        public CollectionCardBuilderJson SetGeneralDivisionCode(int value) { generalDivisionCode = value; return this; }
        public CollectionCardBuilderJson SetDivisionCode(int value) { divisionCode = value; return this; }
        public CollectionCardBuilderJson SetRechargeCenterCode(int value) { rechargeCenterCode = value; return this; }
        public CollectionCardBuilderJson SetIndirectCompanyCode(int value) { indirectCompanyCode = value; return this; }

      
        // ====== Final Build Method ======

        public string Create()
        {
            var json = new JObject
            {
                ["businessData"] = new JObject
                {
                    ["meterType"] = meterType,
                    ["meterVersion"] = meterVersion,
                    ["manufacturerId"] = manufacturerId,
                    ["cardId"] = cardId,
                    ["collectorCode"] = collectorCode,
                    ["controlOperationType"] = controlOperationType,
                    ["collectionCardExpiryDate"] = collectionCardExpiryDate,
                    ["encryptionKey"] = encryptionKey,
                    ["distributionCompany"] = new JObject
                    {
                        ["companyCode"] = companyCode,
                        ["techCodeRegion"] = techCodeRegion,
                        ["sectorCode"] = sectorCode,
                        ["generalDivisionCode"] = generalDivisionCode,
                        ["divisionCode"] = divisionCode,
                        ["rechargeCenterCode"] = rechargeCenterCode,
                        ["companyLevel"] = companyLevel,
                        ["indirectCompanyCode"] = indirectCompanyCode
                    }
                },
                ["isEPayment"] = isEPayment,
                ["cardGenerationType"] = cardGenerationType
            };

            return json.ToString();
        }
    }




}
