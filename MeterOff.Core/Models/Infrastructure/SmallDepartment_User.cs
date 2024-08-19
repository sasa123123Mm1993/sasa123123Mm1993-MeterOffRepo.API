using MeterOff.Core.Models.Base;
using MeterOff.Core.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models
{
    
    public class SmallDepartment_User : BaseEntity
    {
        public int SmallDepartmentId { get; set; }
        public virtual SmallDepartment SmallDepartment { get; set; }

        [ForeignKey(nameof(AppUserId))]
        [MaxLength(450)]
        public string AppUserId { get; set; }

        public virtual ApplicationUser AppUser { get; set; }
    }
}
