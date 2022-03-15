using SO.Agenda.Domain.Model.UnitOfWork;
using SO.Agenda.Infrastructure.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.Agenda.Infrastructure.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AgendaContext _context;
        private bool _disposed;

        public UnitOfWork(AgendaContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _disposed = false;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
