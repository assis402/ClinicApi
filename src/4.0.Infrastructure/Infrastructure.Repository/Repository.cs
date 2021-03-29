using Domain.Core.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Data;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Infrastructure.Repository

{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Base
    {
        private ClinicAppContext db = null;
        DbSet<TEntity> dbSet; 

        public Repository(ClinicAppContext db)
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
            return await dbSet.AsNoTracking().ToListAsync();
        }
 
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await dbSet.AsNoTracking()
                              .Where(x=>x.Id == id)
                              .SingleOrDefaultAsync();
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            return entity;
        }

        public async Task<TEntity> FindByExpressionAsync(Expression<Func<TEntity, bool>> match)
        {
            return await dbSet.AsNoTracking()
                              .Where(match)
                              .SingleOrDefaultAsync();
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