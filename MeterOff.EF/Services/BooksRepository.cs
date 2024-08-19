using MeterOff.Core.Interfaces;
using MeterOff.Core.Models.Test;
using MeterOff.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.EF.Services
{
    public class BooksRepository : GenericRepository<Book>, IBooksRepository
    {
        private readonly DBContext _context;

        public BooksRepository(DBContext context) : base(context)
        {
        }
        public IEnumerable<Book> SpecialMethod()
        {
            throw new NotImplementedException();
        }
    }
}
