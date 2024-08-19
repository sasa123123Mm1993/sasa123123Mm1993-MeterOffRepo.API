namespace MeterOff.Core.Models.Infrastructure
{
    public partial class ServiceLog
    {
        public int Id { get; set; }
        public string MessageType { get; set; }
        public string Message { get; set; }
        public DateTime SaveDate { get; set; }
    }
}
