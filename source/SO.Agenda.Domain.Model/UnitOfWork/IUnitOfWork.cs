using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.Agenda.Domain.Model.UnitOfWork
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task CommitAsync();
        void Commit();
    }
}
