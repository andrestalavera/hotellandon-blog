using HotelLandonBlog.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HotelLandonBlog.Repository
{
    public interface IRepository<TEntity>
        where TEntity : EntityBase
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? predicat = null);
        Task<TEntity> GetAsync(int id);
        Task<bool> Create(TEntity entity);
        Task<TEntity> Update(int id, TEntity entity);
        Task<bool> Delete(int id);
        Task<TEntity> Undelete(int id);
    }
}