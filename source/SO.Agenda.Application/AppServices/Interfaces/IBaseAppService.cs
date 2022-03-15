using SO.Agenda.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SO.Agenda.Application.AppServices.Interfaces
{
    public interface IBaseAppService<TEntityViewModel>
        where TEntityViewModel : BaseViewModel
    {
        Task<TEntityViewModel> AddAsync(TEntityViewModel obj);
        Task<TEntityViewModel> FindAsync(Guid id);
        Task<IEnumerable<TEntityViewModel>> GetAllAsNoTrackingAsync();
        TEntityViewModel Update(TEntityViewModel obj);
        Task RemoveAsync(Guid id);
        void Remove(TEntityViewModel obj);
        void Dispose();
    }
}
