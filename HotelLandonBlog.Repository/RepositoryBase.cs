
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;
using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;

namespace HotelLandon.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity>
        where TEntity : EntityBase
    {
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

        public Task<TEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

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
