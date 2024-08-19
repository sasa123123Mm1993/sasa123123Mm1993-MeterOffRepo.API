using MeterOff.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models.Base
{
    public abstract class BaseEntity : ISoftDelete
    {

        public int Id { get; set; }
        public virtual bool IsDeleted { get; set; }


        public virtual int CreatorById { get; set; }


        public int? ModifiedById { get; set; }


        public virtual DateTime CreationTime { get; set; }


        public DateTime? ModificationTime { get; set; }

    }
}
