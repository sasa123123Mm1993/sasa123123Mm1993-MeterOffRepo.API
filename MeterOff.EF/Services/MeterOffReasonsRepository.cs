using MeterOff.Core.Models.Infrastructure;
using MeterOff.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.EF.Services
{
    public class MeterOffReasonsRepository : GenericRepository<CUploadMainteneceMetersOffReason>
    {
        private readonly DBContext _context;

        public MeterOffReasonsRepository(DBContext context) : base(context)
        {
        }
    }
}
