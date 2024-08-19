using MeterOff.Core.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Interfaces
{
    public interface IBooksRepository : IGenericRepository<Book>
    {
        IEnumerable<Book> SpecialMethod();
    }
}
