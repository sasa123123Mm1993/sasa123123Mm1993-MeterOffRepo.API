using MeterOff.Core.Models.Base;

namespace MeterOff.Core.Models.Infrastructure
{
    public class UploadConsumerLog : BaseEntity
    {
        public int LastUploadCounter { get; set; }
        public int NumberOfRefusedBeforeUpload { get; set; }
    }
}
