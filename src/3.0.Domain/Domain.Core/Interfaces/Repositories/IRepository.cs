using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using Domain.Entities;

namespace Domain.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<ICollection<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task AddAsync(TEntity entity);

        Task<TEntity> FindByExpressionAsync(Expression<Func<TEntity, bool>> match);

        Task<ICollection<TEntity>> FindAllByExpressionAsync(Expression<Func<TEntity, bool>> match);

        void Update(TEntity entity);

        Task<int> CountAsync();
    }
}