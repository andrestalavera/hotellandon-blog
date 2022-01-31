using HotelLandonBlog.Data;
using HotelLandonBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelLandonBlog.Repository
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
        private HotelLandonBlogContext context;

        public Repository(HotelLandonBlogContext context) => this.context = context;

        public async Task<bool> Create(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            return await context.SaveChangesAsync() == 1;
        }

        public async Task<bool> Delete(int id)
        {
            TEntity entity = await GetAsync(id);

            if (entity is not null)
            {
                context.Remove(entity);
                return await context.SaveChangesAsync() == 1;
            }
            return false;
        }

        public Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> predicat = null)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> GetAsync(int id) => await context.Set<TEntity>().FindAsync(id);


        public Task<TEntity> Undelete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Update(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}