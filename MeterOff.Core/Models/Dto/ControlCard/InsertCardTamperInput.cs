using MeterOff.Core.Models.Constant;

namespace MeterOff.Core.Models.Dto.ControlCard
{
    public class InsertCardTamperInput : BaseDto
    {
        public string Code { get; set; }
        public DateTime EventTime { get; set; } //وقت حدوث التلاعب 
        public DateTime? RemovalTime { get; set; }
        public string RemovalCardId { get; set; }
        public string EventName { get; set; }
        public DateTime? CreationTime { get; set; }
    }
}