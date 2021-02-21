using ClinicApi.Domain.Core.Interfaces.Repositories;
using ClinicApi.Domain.Entities;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace ClinicApi.Infrastructure.Repository.Repositories

{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Base
    {
        protected dbContext _dbContext;

        public BaseRepository(dbContext context)
        {
            _dbContext = context;
        }

        private Expression<Func<Base, bool>> Filter()
        {
            return x => x.DeletionDate == null;
        }

        //Expression<Func<TEntity, bool>> DefaultExpression = (p) => p.DeletionDate == null;

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            return entity;
        }

        public async Task<TEntity> FindByExpressionAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _dbContext.Set<TEntity>().SingleOrDefaultAsync(match);
        }

        public async Task<ICollection<TEntity>> FindAllByExpressionAsync(Expression<Func<TEntity, bool>> match)
        {
            return await _dbContext.Set<TEntity>().Where(match).ToListAsync();
        }

        public async Task DeleteById(int id)
        {
            TEntity entity = await GetByIdAsync(id);
            entity.DeletionDate = DateTime.Now;
            //_dbContext.Set<TEntity>().Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            entity.DeletionDate = DateTime.Now;

            //_dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, object key)
        {
            if (entity == null)
                return null;
            TEntity exist = await _dbContext.Set<TEntity>().FindAsync(key);
            if (exist != null)
            {
                _dbContext.Entry(exist).CurrentValues.SetValues(entity);
                await _dbContext.SaveChangesAsync();
            }
            return exist;
        }

        public async Task<int> CountAsync()
        {
            return await _dbContext.Set<TEntity>().Where(x => x.CreationDate != null).CountAsync();
        }

        /*
        public IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> queryable = GetAll();
            foreach (Expression<Func<T, object>> includeProperty in includeProperties)
            {
                queryable = queryable.Include<T, object>(includeProperty);
            }

            return queryable;
        }
        */
    }
}