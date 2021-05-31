using RS.SorteOnline.Agenda.Domain.Interfaces;
using RS.SorteOnline.Agenda.Infra.Data.Context;

namespace RS.SorteOnline.Agenda.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RSContext _context;

        public UnitOfWork(RSContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
