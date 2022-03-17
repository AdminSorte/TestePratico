using AutoMapper;
using SO.Agenda.Application.AppServices.Interfaces;
using SO.Agenda.Application.AutoMapper;
using SO.Agenda.Application.ViewModels;
using SO.Agenda.Domain.Model.Entities;
using SO.Agenda.Domain.Model.Interfaces.Services;
using SO.Agenda.Domain.Model.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SO.Agenda.Application.AppServices.Implementations
{
    public class BaseAppService<TIService, TEntity, TEntityViewModel> : IBaseAppService<TEntityViewModel>
        where TEntity : BaseEntity
        where TEntityViewModel : BaseViewModel
        where TIService : IBaseService<TEntity>
    {
        private readonly TIService _baseService;
        protected readonly IMapper AutoMapper;
        protected readonly IUnitOfWork Uow;

        public BaseAppService(TIService baseService, IUnitOfWork uow) //, IMapper autoMapper)
        {
            _baseService = baseService;
            Uow = uow;
            AutoMapper = new Mapper(AutoMapperConfig.RegisterMappings()); // autoMapper;
        }

        public virtual Task<TEntityViewModel> AddAsync(TEntityViewModel obj)
        {
            Uow.BeginTransaction();
            var ret = _baseService.AddAsync(AutoMapper.Map<TEntity>(obj));
            Uow.CommitAsync();
            return AutoMapper.Map<Task<TEntityViewModel>>(ret);
        }

        public virtual Task<TEntityViewModel> FindAsync(Int32 id)
        {
            return AutoMapper.Map<Task<TEntityViewModel>>(_baseService.FindAsync(id));
        }

        public virtual async Task<IEnumerable<TEntityViewModel>> GetAllAsNoTrackingAsync()
        {
            return AutoMapper.Map<IEnumerable<TEntityViewModel>>(await _baseService.GetAllAsNoTrackingAsync());
        }
        public virtual async Task<IEnumerable<TEntityViewModel>> Get(Expression<Func<TEntityViewModel, bool>> predicate)
        {
            var newPredicate = PredicateExtensions.ConvertTypeExpression<TEntityViewModel, TEntity>(predicate.Body);
            return AutoMapper.Map<IEnumerable<TEntityViewModel>>(await _baseService.Get(newPredicate));
        }
        public virtual TEntityViewModel Update(TEntityViewModel obj)
        {
            Uow.BeginTransaction();
            var ret = _baseService.Update(AutoMapper.Map<TEntity>(obj));
            Uow.Commit();
            return AutoMapper.Map<TEntityViewModel>(ret);
        }

        public virtual Task RemoveAsync(Int32 id)
        {
            Uow.BeginTransaction();
            var ret = _baseService.RemoveAsync(id);
            Uow.CommitAsync();
            return ret;
        }

        public virtual void Remove(TEntityViewModel obj)
        {
            Uow.BeginTransaction();
            _baseService.Remove(AutoMapper.Map<TEntity>(obj));
            Uow.CommitAsync();
        }

        public void Dispose()
        {
            _baseService.Dispose();
        }

    }
}
