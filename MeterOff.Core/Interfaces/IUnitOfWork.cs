using MeterOff.Core.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Author> Authors { get; }
        IBooksRepository Books { get; }
        IMeterOffReasonsRepository MeterOffReasonsRepository { get; }
        int Complete();
        int Save();
    }
}
