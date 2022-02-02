
using HotelLandonBlog.Data;
using HotelLandonBlog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelLandonBlog.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        private readonly HotelLandonBlogDbContext _dbContext;
        
        public RepositoryBase(HotelLandonBlogDbContext context) => this._dbContext = context;

        public async Task<TEntity> GetAsync(int id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public virtual async Task<TEntity> CreateAsync(TEntity entity)
        {
            entity.Creation = new DateTime();
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<TEntity> UpdateAsync(int id, TEntity entity)
        {
            TEntity local = _dbContext.Set<TEntity>()
               .Local
               .FirstOrDefault(entry => entry.Id.Equals(id));

            // check if local is not null 
            if (local != null)
            {
                // detach
                _dbContext.Entry(local).State = EntityState.Detached;
            }
            // set Modified flag in your entry
            _dbContext.Entry(entity).State = EntityState.Modified;

            // save 
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public virtual async Task<TEntity> DeleteAsync(int id)
        {
            TEntity entity = await GetAsync(id);
            if (entity is not null)
            {
                entity.IsDisable = true;
                await _dbContext.SaveChangesAsync();
            }
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicat = null)
        {
            return await _dbContext.Set<TEntity>().ToListAsync();
        }

        public virtual async Task<TEntity> UndeleteAsync(int id)
        {
            TEntity entity = await GetAsync(id);
            if (entity is not null)
            {
                bool v = entity.IsDisable == false;

                await _dbContext.SaveChangesAsync();

            }
            return entity;
        }
    }
}