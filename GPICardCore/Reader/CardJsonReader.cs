using System.Text.Json;
using System.Text.Json.Serialization;

namespace GPICardCore.Reader
{
    public class CardJsonReader
    {
        public RootObject? ParsedData { get; private set; }

        public CardJsonReader(string json)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false
            };

            ParsedData = JsonSerializer.Deserialize<RootObject>(json, options);
        }

        public List<MeterData> GetMeterData()
        {
            return this.ParsedData.Data.Payload.MeterData;
        }

        public MeterEvents GetMeterEvents()
        {
            return null;
        }
    }

    // MODEL CLASSES BELOW:

    public class RootObject
    {
        [JsonPropertyName("statusCode")]
        public int? StatusCode { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("data")]
        public Data? Data { get; set; }
    }

    public class Data
    {
        [JsonPropertyName("payload")]
        public Payload? Payload { get; set; }

        [JsonPropertyName("epaymentPayload")]
        public string? EpaymentPayload { get; set; }
    }

    public class Payload
    {
        [JsonPropertyName("cardId")]
        public string? CardId { get; set; }

        [JsonPropertyName("cardType")]
        public int? CardType { get; set; }

        [JsonPropertyName("technicianCode")]
        public string? TechnicianCode { get; set; }

        [JsonPropertyName("controlCardType")]
        public int? ControlCardType { get; set; }

        [JsonPropertyName("numberOfMeter")]
        public string? NumberOfMeter { get; set; }

        [JsonPropertyName("controlMetersList")]
        public List<string>? ControlMetersList { get; set; }

        [JsonPropertyName("controlOperationType")]
        public int? ControlOperationType { get; set; }

        [JsonPropertyName("controlCardActivationDate")]
        public string? ControlCardActivationDate { get; set; }

        [JsonPropertyName("controlCardExpiryDate")]
        public string? ControlCardExpiryDate { get; set; }

        [JsonPropertyName("meterData")]
        public List<MeterData>? MeterData { get; set; }
    }

    public class MeterData
    {
        [JsonPropertyName("meterId")]
        public string? MeterId { get; set; }

        [JsonPropertyName("meterType")]
        public int? MeterType { get; set; }

        [JsonPropertyName("meterVersion")]
        public string? MeterVersion { get; set; }

        [JsonPropertyName("manufacturerId")]
        public string? ManufacturerId { get; set; }

        [JsonPropertyName("customerId")]
        public string? CustomerId { get; set; }

        [JsonPropertyName("currentMeterTimestamp")]
        public string? CurrentMeterTimestamp { get; set; }

        [JsonPropertyName("RelayTime")]
        public int? RelayTime { get; set; }

        [JsonPropertyName("RelayKW")]
        public int? RelayKW { get; set; }

        [JsonPropertyName("meterStatusCode")]
        public int? MeterStatusCode { get; set; }

        [JsonPropertyName("batarryStatusCode")]
        public int? BatarryStatusCode { get; set; }

        [JsonPropertyName("relayStatus")]
        public int? RelayStatus { get; set; }

        [JsonPropertyName("relayCondition")]
        public int? RelayCondition { get; set; }

        [JsonPropertyName("openCoverStatus")]
        public int? OpenCoverStatus { get; set; }

        [JsonPropertyName("openTerminalCoverStatus")]
        public int? OpenTerminalCoverStatus { get; set; }

        [JsonPropertyName("unbalanceStatus")]
        public int? UnbalanceStatus { get; set; }

        [JsonPropertyName("reverseCurrentStatus")]
        public int? ReverseCurrentStatus { get; set; }

        [JsonPropertyName("overloadStatus")]
        public int? OverloadStatus { get; set; }

        [JsonPropertyName("beforeMeterStatusCode")]
        public int? BeforeMeterStatusCode { get; set; }

        [JsonPropertyName("beforeBatarryStatusCode")]
        public int? BeforeBatarryStatusCode { get; set; }

        [JsonPropertyName("beforeRelayStatus")]
        public int? BeforeRelayStatus { get; set; }

        [JsonPropertyName("beforeRelayCondition")]
        public int? BeforeRelayCondition { get; set; }

        [JsonPropertyName("beforeOpenCoverStatus")]
        public int? BeforeOpenCoverStatus { get; set; }

        [JsonPropertyName("beforeOpenTerminalCoverStatus")]
        public int? BeforeOpenTerminalCoverStatus { get; set; }

        [JsonPropertyName("beforeUnbalanceStatus")]
        public int? BeforeUnbalanceStatus { get; set; }

        [JsonPropertyName("beforeReverseCurrentStatus")]
        public int? BeforeReverseCurrentStatus { get; set; }

        [JsonPropertyName("beforeOverloadStatus")]
        public int? BeforeOverloadStatus { get; set; }

        [JsonPropertyName("meterEvents")]
        public MeterEvents? MeterEvents { get; set; }
    }

    public class MeterEvents
    {
        [JsonPropertyName("previousMeterEvents")]
        public List<PreviousMeterEvent>? PreviousMeterEvents { get; set; }

        [JsonPropertyName("previousMeterRemovalEvents")]
        public List<PreviousMeterRemovalEvent>? PreviousMeterRemovalEvents { get; set; }

        [JsonPropertyName("meterDateTimeAdjustments")]
        public List<MeterDateTimeAdjustment>? MeterDateTimeAdjustments { get; set; }

        [JsonPropertyName("meterInstallationLog")]
        public MeterInstallationLog? MeterInstallationLog { get; set; }
    }

    public class PreviousMeterEvent
    {
        [JsonPropertyName("previousMeterEventCode")]
        public int? PreviousMeterEventCode { get; set; }

        [JsonPropertyName("previousMeterEventTime")]
        public string? PreviousMeterEventTime { get; set; }

        [JsonPropertyName("previousMeterEventRemovalTime")]
        public string? PreviousMeterEventRemovalTime { get; set; }

        
        [JsonPropertyName("previousMeterEventRemovalTechnicianCode")]
        public long? PreviousMeterEventRemovalTechnicianCode { get; set; }
    }

    public class PreviousMeterRemovalEvent
    {
        [JsonPropertyName("eventSequence")]
        public int? EventSequence { get; set; }

        [JsonPropertyName("eventCode")]
        public int? EventCode { get; set; }

        [JsonPropertyName("eventDateTime")]
        public string? EventDateTime { get; set; }

        [JsonPropertyName("cardNumber")]
        public string? CardNumber { get; set; }
    }

    public class MeterInstallationLog
    {
        [JsonPropertyName("meterInstallationDate")]
        public string? MeterInstallationDate { get; set; }

        [JsonPropertyName("meterInstallationTechCode")]
        public long? MeterInstallationTechCode { get; set; }
    }

    public class MeterDateTimeAdjustment
    {
        [JsonPropertyName("eventSequence")]
        public int EventSequence { get; set; }

        [JsonPropertyName("eventDateTime")]
        public string EventDateTime { get; set; }

        [JsonPropertyName("cardNumber")]
        public string CardNumber { get; set; }
    }


}
