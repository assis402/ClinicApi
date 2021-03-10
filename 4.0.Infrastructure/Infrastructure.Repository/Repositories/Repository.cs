using Domain.Core.Interfaces.Repositories;
using Domain.Entities;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infrastructure.Repository.Repositories

{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ClinicContext context = null;
        DbSet<TEntity> dbSet; 

        public Repository(ClinicContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        //private Expression<Func<Base, bool>> Filter()
        //{
            //return x => x.DeletionDate == null;
        //}

        //Expression<Func<TEntity, bool>> DefaultExpression = (p) => p.DeletionDate == null;

        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
        }

        public async Task<TEntity> FindByExpressionAsync(Expression<Func<TEntity, bool>> match)
        {
            return await dbSet.SingleOrDefaultAsync(match);
        }

        public async Task<ICollection<TEntity>> FindAllByExpressionAsync(Expression<Func<TEntity, bool>> match)
        {
            return await dbSet.Where(match).ToListAsync();
        }

        public async Task DeleteById(int id)
        {
            TEntity entity = await GetByIdAsync(id);
            //entity.DeletionDate = DateTime.Now;
            //dbSet.Remove(entity);
        }

        public void Delete(TEntity entity)
        {
            //entity.DeletionDate = DateTime.Now;

            //dbSet.Remove(entity);
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity, object key)
        {
            if (entity == null)
                return null;
            TEntity exist = await dbSet.FindAsync(key);
            if (exist != null)
            {
               // dbSet.Entry(exist).CurrentValues.SetValues(entity);
                //await dbSet.SaveChangesAsync();
            }
            return exist;
        }

        public async Task<int> CountAsync()
        {
            //return await dbSet.Where(x => x.CreationDate != null).CountAsync();
            return await dbSet.CountAsync();

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