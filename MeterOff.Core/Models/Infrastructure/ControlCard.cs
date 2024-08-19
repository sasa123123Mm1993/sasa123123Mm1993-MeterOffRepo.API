using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class ControlCard : BaseEntity
    {
        public ControlCard()
        {
            ControlCardProperties = new HashSet<ControlCardManagment>();
        }
        public int EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Limitation { get; set; }//0 one meter   1 many meters  2 unlimited
        [MaxLength(20)]
        public string MeterSerial { get; set; }
        [MaxLength(20)]
        public string CardId { get; set; }
        public Guid CysheildCardUid { get; set; }
        public bool IsBlocked { get; set; }

        public int NoOfCollectedMeters { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual Technician Employee { get; set; }
        public virtual ICollection<ControlCardManagment> ControlCardProperties { get; set; }
    }
}
