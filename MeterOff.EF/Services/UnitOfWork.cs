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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DBContext _context;
        public IGenericRepository<Author> Authors { get; private set; }
        public IBooksRepository Books { get; private set; }
        public IMeterOffReasonsRepository MeterOffReasonsRepository { get; private set; }
        public UnitOfWork(DBContext context)
        {
            _context = context;
            Authors = new GenericRepository<Author>(_context);
            Books = new BooksRepository(_context);
        }
        public int Save()
        {
            return _context.SaveChanges();
        }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
