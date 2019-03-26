using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Doitsu.Service.Core
{ 
   
    public interface IBaseService<TEntity, TViewModel>
        where TEntity : class, new() 
        where TViewModel : BaseViewModel<TEntity>
    {
        TViewModel FindById(int id);
        TEntity FindEById(int id);
        Task<TViewModel> FindByIdAsync(int id);
        TViewModel FindById<TKey>(TKey id);
        Task<TViewModel> FindByIdAsync<TKey>(TKey id);

        IQueryable<TViewModel> GetAll();
        IQueryable<TViewModel> GetAllActive();
        IQueryable<TViewModel> Get(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetE(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TViewModel> GetActive(Expression<Func<TEntity, bool>> predicate);
       
        TViewModel FirstOrDefault();
        TEntity FirstOrDefaultE();
        TEntity FirstOrDefaultE(Expression<Func<TEntity, bool>> predicate);
        TViewModel FirstOrDefaultActive();
        TViewModel FirstOrDefault(Expression<Func<TEntity, bool>> predicate);
        TViewModel FirstOrDefaultActive(Expression<Func<TEntity, bool>> predicate);
        Task<TViewModel> FirstOrDefaultAsync();
        Task<TViewModel> FirstOrDefaultActiveAsync();
        Task<TViewModel> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TViewModel> FirstOrDefaultActiveAsync(Expression<Func<TEntity, bool>> predicate);

        TViewModel Create(TViewModel viewModel);
        TEntity Create(TEntity entity);
        Task<TViewModel> CreateAsync(TViewModel viewModel);
        TViewModel Update( TViewModel viewModel);
        TEntity Update( TEntity entity);
        Task<TViewModel> UpdateAsync(TViewModel viewModel);
        TViewModel Update<TKey>(TKey id, TViewModel viewModel);
        Task<TViewModel> UpdateAsync<TKey>(TKey id, TViewModel viewModel);
        Task<TViewModel> DeactiveAsync<TKey>(TKey id);
        void Delete<TKey>(TKey id);
        Task DeleteAsync<TKey>(TKey id);
    }
}