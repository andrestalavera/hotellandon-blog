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

        public Task<TEntity> Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Delete(int id)
        {
            throw new NotImplementedException();
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