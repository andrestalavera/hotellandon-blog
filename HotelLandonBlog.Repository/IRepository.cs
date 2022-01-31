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
        Task<List<TEntity>> SearchAsync(Expression<Func<TEntity, bool>>? predicat = null);
        Task<TEntity> Get(int id);
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(int id, TEntity entity);
        Task<TEntity> Delete(int id);
        Task<TEntity> Undelete(int id);
    }
}