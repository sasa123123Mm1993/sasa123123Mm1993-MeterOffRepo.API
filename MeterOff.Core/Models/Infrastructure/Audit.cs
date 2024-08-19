using MeterOff.Models.Enum;
using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class Audit : BaseEntity
    {
        public new long Id { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public Int64 RecordId { get; set; }
        [MaxLength(50)]
        public string TableName { get; set; }
        public OperationTypeEnum OperationType { get; set; }
        public DateTime TransactionDate { get; set; }

    }
}
