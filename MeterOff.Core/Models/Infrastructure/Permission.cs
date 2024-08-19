using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using MeterOff.Core.Models.Base;

namespace MeterOff.Core.Models.Infrastructure
{
    public class Permission : BaseEntity
    {
        [MaxLength(100)]
        public string Name { get; set; }
        public bool IsGranted { get; set; }
        public int? UserId { get; set; }
        public int? RoleId { get; set; }

        //[ForeignKey("UserId")]
        //public virtual AppUser User { get; set; }

        //[ForeignKey("RoleId")]
        //public virtual AppRole Role { get; set; }

    }
}
