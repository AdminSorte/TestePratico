using System;

namespace RS.SorteOnline.Agenda.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
