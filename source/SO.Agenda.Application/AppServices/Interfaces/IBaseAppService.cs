using SO.Agenda.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SO.Agenda.Application.AppServices.Interfaces
{
    public interface IBaseAppService<TEntityViewModel>
        where TEntityViewModel : BaseViewModel
    {
        Task<TEntityViewModel> AddAsync(TEntityViewModel obj);
        Task<TEntityViewModel> FindAsync(Int32 id);
        Task<IEnumerable<TEntityViewModel>> GetAllAsNoTrackingAsync();
        Task<IEnumerable<TEntityViewModel>> Get(Expression<Func<TEntityViewModel, bool>> predicate);
        TEntityViewModel Update(TEntityViewModel obj);
        Task RemoveAsync(Int32 id);
        void Remove(TEntityViewModel obj);
        void Dispose();
    }
}
