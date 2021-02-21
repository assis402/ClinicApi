using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq.Expressions;
using ClinicApi.Domain.Entities;


namespace ClinicApi.Domain.Core.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : Base
    {
        Task<ICollection<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> FindByExpressionAsync(Expression<Func<TEntity, bool>> match);

        Task<ICollection<TEntity>> FindAllByExpressionAsync(Expression<Func<TEntity, bool>> match);

        Task DeleteById(int id);

        void Delete(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity, object key);

        Task<int> CountAsync();
    }
}