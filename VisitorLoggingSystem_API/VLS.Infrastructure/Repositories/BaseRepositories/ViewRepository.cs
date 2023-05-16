using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;

namespace VLS.Infrastructure.Repositories.BaseRepositories
{
    public class ViewRepository<T> : IViewRepository<T> where T : BaseEntity
    {
        private readonly VLSDbContext _context;
        internal DbSet<T> _entity;
        protected readonly ILogger<T> _logger;

        public ViewRepository(VLSDbContext context, ILogger<T> logger)
        {
            _context = context;
            _entity = _context.Set<T>();
            _logger = logger;
        }

        public virtual List<T> Get(Expression<Func<T, bool>>? filter = null, Expression<Func<T, int, T>>? select = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _entity;
            List<T> entities = new List<T>();

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

        public virtual async Task<List<T>> GetAsync(Expression<Func<T, bool>>? filter = null, Expression<Func<T, int, T>>? select = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _entity;
            List<T> entities = new List<T>();

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

        public virtual List<T> GetAll(bool? isActive = null)
        {
            List<T> entities = _entity.Where(x => isActive == null).ToList();
            _context.ChangeTracker.Clear();

            return entities;
        }

        public virtual async Task<List<T>> GetAllAsync(bool? isActive = null)
        {
            List<T> entities = await _entity.Where(x => isActive == null).ToListAsync();
            _context.ChangeTracker.Clear();

            return entities;
        }

        public virtual T? GetById(object? id)
        {
            T? entity = _entity.Find(id);
            _context.ChangeTracker.Clear();

            return entity;
        }

        public virtual async Task<T?> GetByIdAsync(object? id)
        {
            T? entity = await _entity.FindAsync(id);
            _context.ChangeTracker.Clear();

            return entity;
        }

        public virtual List<T> Paginate(List<T>? entities = null, int itemsPerPage = 20, int page = 1)
        {
            if (entities == null)
                return new List<T>();

            int skip = (page - 1) * itemsPerPage;

            entities = entities.Skip(skip).Take(itemsPerPage).ToList();

            return entities;
        }
    }
}
