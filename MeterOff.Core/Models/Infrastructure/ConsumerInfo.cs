using MeterOff.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace MeterOff.Core.Models.Infrastructure
{
    public partial class ConsumerInfo : BaseEntity
    {
        public ConsumerInfo()
        {
            Accounts = new HashSet<Consumer>();
        }

        [MaxLength(150)]
        public string Name { get; set; }
      
        [MaxLength(16)]
        public string NationalId { get; set; }
        [MaxLength(30)]
        public string PassPort { get; set; }
        [MaxLength(200)]
        public string Address { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        public int? AccountUploadId { get; set; }

        public int? BasicDataForFaxtionId { get; set; }
        [MaxLength(15)]
        public string Notes { get; set; }
        public virtual ICollection<Consumer> Accounts { get; set; }

        public void Validate()
        {
            if (string.IsNullOrEmpty(Name))
            {
                //throw new UserFriendlyException("من فضلك أدخل الاسم !!");
            }
            if (string.IsNullOrEmpty(Address))
            {
                
            }
        }
    }
}
