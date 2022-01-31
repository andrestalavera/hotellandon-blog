using HotelLandonBlog.Entities;
using HotelLandonBlog.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HotelLandonBlog.UI.Controllers
{
    public partial class HLController<TRepository, TEntity> : Controller
        where TRepository : IRepository<TEntity>
        where TEntity : EntityBase
    {
        protected readonly IRepository<TEntity> repository;
        protected readonly ILogger<HLController<TRepository, TEntity>> logger;

        public HLController(IRepository<TEntity> repository,
            ILogger<HLController<TRepository,TEntity>> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        
        // Get

        // Get All (search)
    }
}
