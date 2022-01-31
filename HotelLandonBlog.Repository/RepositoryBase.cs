
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;
using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;
using HotelLandonBlog.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelLandon.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        private readonly IHotelLandonBlogContext _dbContext;

        public RepositoryBase(IHotelLandonBlogContext context) => this._dbContext = context;
        public async Task<TEntity> Get(int id) => await _dbContext.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> Create(TEntity entity)
        {

           _dbContext.Set<TEntity>().Add(entity);
           await _dbContext.SaveChangesAsync();

           bool v = entity.IsDeleted == false;
           entity.Creation = new DateTime();

           return entity;

        }

        public async Task<TEntity> Update(int id, TEntity entity)
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

        public async Task<TEntity> Delete(int id)
        {
            var entity = await Get(id);


               if (entity is not null)
            {
                _dbContext.Remove(entity);
                
                await _dbContext.SaveChangesAsync();

                return entity;

                bool v = entity.IsDeleted == true;
                
            }

            return entity;

        }

        public Task<List<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicat = null)
        {
            // On prépare la requête
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsQueryable();
            if (predicat != null)
            {
                query = query.Where(predicat);
            }
            // On exécute la requête
            return query.ToListAsync();
        }

   

        public Task<TEntity> Undelete(int id)
        {
            throw new NotImplementedException();
        }


    }
}
