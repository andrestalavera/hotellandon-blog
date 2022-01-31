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
        Task<TEntity> CreateAsync(TEntity entity);
        Task<TEntity> UpdateAsync(int id, TEntity entity);
        Task<TEntity> DeleteAsync(int id);
        Task<TEntity> UndeleteAsync(int id);
    }
}