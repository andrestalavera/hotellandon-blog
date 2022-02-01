
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;
using HotelLandonBlog.Entities;
using Microsoft.EntityFrameworkCore;
using HotelLandonBlog.Data;

namespace HotelLandonBlog.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        private readonly HotelLandonBlogDbContext _dbContext;

        public RepositoryBase(HotelLandonBlogDbContext context) => this._dbContext = context;

        public async Task<TEntity> GetAsync(int id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> CreateAsync(TEntity entity)
        {

            //entity.Creation = new DateTime();

            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;

        }

        public async Task<TEntity> UpdateAsync(int id, TEntity entity)
        {
            var local = _dbContext.Set<TEntity>()
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

        public async Task<TEntity> DeleteAsync(int id)
        {
            var entity = await GetAsync(id);


            if (entity is not null)
            {
                _dbContext.Remove(entity);

                await _dbContext.SaveChangesAsync();


            }

            return entity;

        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicat = null)
        {

            return await _dbContext.Set<TEntity>().ToListAsync();
        }



        public async Task<TEntity> UndeleteAsync(int id)
        {
            var entity = await GetAsync(id);


            if (entity is not null)
            {
                bool v = entity.IsDeleted == true;

                await _dbContext.SaveChangesAsync();


            }

            return entity;
        }


    }
}
