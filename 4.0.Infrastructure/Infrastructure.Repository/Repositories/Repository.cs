using Domain.Core.Interfaces.Repositories;
using Infrastructure.Data;
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
        private ClinicContext db = null;
        DbSet<TEntity> dbSet; 

        public Repository(ClinicContext db)
        {
            this.db = db;
            dbSet = db.Set<TEntity>();
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

        public void Update(TEntity entity)
        {
            db.Entry(entity).State = EntityState.Modified;
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