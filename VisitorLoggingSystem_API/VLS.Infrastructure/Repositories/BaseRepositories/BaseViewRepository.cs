using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using VLS.Infrastructure.Interfaces.IRepositories.IBaseRepositories.ReadRepositories;

namespace VLS.Infrastructure.Repositories.BaseRepositories
{
    public class BaseViewRepository<TModel> : IReadRepository<TModel> where TModel : BaseEntity
    {
        private readonly VLSDbContext _context;
        internal DbSet<TModel> _entity;
        //protected readonly ILogger<TModel> _logger;
        //private readonly IMapper _mapper;

        public BaseViewRepository(
            VLSDbContext context 
            //, ILogger<TModel> logger 
            //, IMapper mapper
        )
        {
            _context = context;
            _entity = _context.Set<TModel>();
            //_logger = logger;
            //_mapper = mapper;
        }

        public virtual List<TModel> Get(Expression<Func<TModel, bool>>? filter = null, Expression<Func<TModel, int, TModel>>? select = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<TModel> query = _entity;
            List<TModel> entities = new List<TModel>();

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (filter != null)
                query = query.Where(filter);

            if (select != null)
                query = query.Select(select);

            if (orderBy != null)
                entities = orderBy(query).ToList();
            else
                entities = query.ToList();

            _context.ChangeTracker.Clear();

            return entities;
        }

        public virtual async Task<List<TModel>> GetAsync(Expression<Func<TModel, bool>>? filter = null, Expression<Func<TModel, int, TModel>>? select = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<TModel> query = _entity;
            List<TModel> entities = new List<TModel>();

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (filter != null)
                query = query.Where(filter);

            if (select != null)
                query = query.Select(select);

            if (orderBy != null)
                entities = await orderBy(query).ToListAsync();
            else
                entities = await query.ToListAsync();

            _context.ChangeTracker.Clear();

            return entities;
        }
        
        public virtual List<TModel> GetAll(bool? isActive = null)
        {
            List<TModel> entities = _entity.Where(x => isActive == null).ToList();
            _context.ChangeTracker.Clear();

            return entities;
        }

        public virtual async Task<List<TModel>> GetAllAsync(bool? isActive = null)
        {
            List<TModel> entities = await _entity.ToListAsync();
            _context.ChangeTracker.Clear();

            return entities;
        }

        public virtual TModel? GetById(object id)
        {
            TModel? entity = _entity.Find(id);
            _context.ChangeTracker.Clear();

            return entity;
        }

        public virtual async Task<TModel?> GetByIdAsync(object id)
        {
            TModel? entity = await _entity.FindAsync(id);
            _context.ChangeTracker.Clear();

            return entity;
        }
    }
}
