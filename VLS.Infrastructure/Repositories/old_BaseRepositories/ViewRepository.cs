﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using VLS.Infrastructure.Interfaces.IRepositories.old_IBaseRepositories;

namespace VLS.Infrastructure.Repositories.old_BaseRepositories
{
    public class ViewRepository<TModel, TViewModel, TDTO> : IViewRepository<TModel, TViewModel, TDTO>
        where TModel : BaseEntity
        where TViewModel : VMBaseEntity
    {
        private readonly VLSDbContext _context;
        internal DbSet<TModel> _entity;
        protected readonly ILogger<TModel> _logger;
        private readonly IMapper _mapper;
        public ViewRepository(VLSDbContext context, ILogger<TModel> logger, IMapper mapper)
        {
            _context = context;
            _entity = _context.Set<TModel>();
            _logger = logger;
            _mapper = mapper;
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
        public virtual List<TViewModel> GetVM(Expression<Func<TModel, bool>>? filter = null, Expression<Func<TModel, int, TModel>>? select = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<TModel> query = _entity;
            List<TViewModel> entities = new List<TViewModel>();

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (filter != null)
                query = query.Where(filter);

            if (select != null)
                query = query.Select(select);

            if (orderBy != null)
                entities = orderBy(query).Select(e => _mapper.Map<TViewModel>(e)).ToList();
            else
                entities = query.Select(e => _mapper.Map<TViewModel>(e)).ToList();

            _context.ChangeTracker.Clear();

            return entities;
        }
        public virtual List<TDTO> GetDTO(Expression<Func<TModel, bool>>? filter = null, Expression<Func<TModel, int, TModel>>? select = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<TModel> query = _entity;
            List<TDTO> entities = new List<TDTO>();

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (filter != null)
                query = query.Where(filter);

            if (select != null)
                query = query.Select(select);

            if (orderBy != null)
                entities = orderBy(query).Select(e => _mapper.Map<TDTO>(e)).ToList();
            else
                entities = query.Select(e => _mapper.Map<TDTO>(e)).ToList();

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
        public virtual async Task<List<TViewModel>> GetVMAsync(Expression<Func<TModel, bool>>? filter = null, Expression<Func<TModel, int, TModel>>? select = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<TModel> query = _entity;
            List<TViewModel> entities = new List<TViewModel>();

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (filter != null)
                query = query.Where(filter);

            if (select != null)
                query = query.Select(select);

            if (orderBy != null)
                entities = await orderBy(query).Select(e => _mapper.Map<TViewModel>(e)).ToListAsync();
            else
                entities = await query.Select(e => _mapper.Map<TViewModel>(e)).ToListAsync();

            _context.ChangeTracker.Clear();

            return entities;
        }
        public virtual async Task<List<TDTO>> GetDTOAsync(Expression<Func<TModel, bool>>? filter = null, Expression<Func<TModel, int, TModel>>? select = null, Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null, string includeProperties = "")
        {
            IQueryable<TModel> query = _entity;
            List<TDTO> entities = new List<TDTO>();

            query = includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            if (filter != null)
                query = query.Where(filter);

            if (select != null)
                query = query.Select(select);

            if (orderBy != null)
                entities = await orderBy(query).Select(e => _mapper.Map<TDTO>(e)).ToListAsync();
            else
                entities = await query.Select(e => _mapper.Map<TDTO>(e)).ToListAsync();

            _context.ChangeTracker.Clear();

            return entities;
        }

        public virtual List<TModel> GetAll(bool? isActive = null)
        {
            List<TModel> entities = _entity.Where(x => isActive == null).ToList();
            _context.ChangeTracker.Clear();

            return entities;
        }
        public virtual List<TViewModel> GetAllVM(bool? isActive = null)
        {

            var includeProperties = GetIncludeProperties();

            IQueryable<TModel> query = _entity;
            query = includeProperties.Aggregate(query, (curr, includeProperty) => curr.Include(includeProperty));
            List<TViewModel> entities = query.Select(e => _mapper.Map<TViewModel>(e)).ToList();
            
            _context.ChangeTracker.Clear();

            return entities;
        }
        public virtual List<TDTO> GetAllDTO(bool? isActive = null)
        {
            List<TDTO> entities = _entity.Select(e => _mapper.Map<TDTO>(e)).ToList();
            _context.ChangeTracker.Clear();

            return entities;
        }

        public virtual async Task<List<TModel>> GetAllAsync(bool? isActive = null)
        {
            List<TModel> entities = await _entity.ToListAsync();
            _context.ChangeTracker.Clear();

            return entities;
        }
        public virtual async Task<List<TViewModel>> GetAllVMAsync(bool? isActive = null)
        {
            var includeProperties = GetIncludeProperties();

            IQueryable<TModel> query = _entity;
            query = includeProperties.Aggregate(query, (curr, includeProperty) => curr.Include(includeProperty));
            List<TViewModel> entities = await query.Select(e => _mapper.Map<TViewModel>(e)).ToListAsync();

            _context.ChangeTracker.Clear();

            return entities;
        }
        public virtual async Task<List<TDTO>> GetAllDTOAsync(bool? isActive = null)
        {
            List<TDTO> entities = await _entity.Select(e => _mapper.Map<TDTO>(e)).ToListAsync();
            _context.ChangeTracker.Clear();

            return entities;
        }

        public virtual TModel? GetById(object id)
        {
            TModel? entity = _entity.Find(id);
            _context.ChangeTracker.Clear();

            return entity;
        }
        public virtual TViewModel? GetVMById(object id)
        {
            var includeProperties = GetIncludeProperties();

            IQueryable<TModel> query = _entity;
            query = includeProperties.Aggregate(query, (curr, includeProperty) => curr.Include(includeProperty));
            query = query.Where(GetWhereClauseByPK(id));

            TViewModel entity = _mapper.Map<TViewModel>(query.FirstOrDefault());

            _context.ChangeTracker.Clear();

            return entity;
        }
        public virtual TDTO? GetDTOById(object id)
        {
            TDTO? entity = _mapper.Map<TDTO>(_entity.Find(id));
            _context.ChangeTracker.Clear();

            return entity;
        }

        public virtual async Task<TModel?> GetByIdAsync(object id)
        {
            TModel? entity = await _entity.FindAsync(id);
            _context.ChangeTracker.Clear();

            return entity;
        }
        public virtual async Task<TViewModel?> GetVMByIdAsync(object id)
        {
            var includeProperties = GetIncludeProperties();

            IQueryable<TModel> query = _entity;
            query = includeProperties.Aggregate(query, (curr, includeProperty) => curr.Include(includeProperty));
            query = query.Where(GetWhereClauseByPK(id));

            TViewModel entity = _mapper.Map<TViewModel>(await query.FirstOrDefaultAsync());
            
            _context.ChangeTracker.Clear();

            return entity;
        }
        public virtual async Task<TDTO?> GetDTOByIdAsync(object id)
        {
            TDTO? entity = _mapper.Map<TDTO>(await _entity.FindAsync(id));
            _context.ChangeTracker.Clear();

            return entity;
        }

        private List<string> GetIncludeProperties()
        {
            try
            {
                var dbEntities = typeof(VLSDbContext)
                                    .GetProperties()
                                    .Where(prop => prop.PropertyType.IsGenericType)
                                    .Where(prop => prop.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                                    .Select(prop => prop.PropertyType.GenericTypeArguments.First().FullName)
                                    .Distinct()
                                    .ToList();

                return typeof(TModel).GetProperties().Where(x => dbEntities.Contains(x.PropertyType.FullName)).Select(x => x.Name).ToList();
            }
            catch (Exception)
            {
                return new List<string>();
            }
        }

        internal virtual Expression<Func<TModel, bool>> GetWhereClauseByPK(object id) 
        {
            throw new NotImplementedException();
        }        
        
        /*private Expression<Func<TModel, bool>>? GetPKFilterString(object id)
        {
            try
            {
                var pk = typeof(TModel).GetProperties()
                                                .FirstOrDefault(p => p.GetCustomAttributes(false)
                                                .Any(a => a.GetType() == typeof(KeyAttribute)));

                var pkType = Type.GetType(pk.PropertyType.FullName);

                return x => Convert.ChangeType(x.GetType().GetProperty(pk.Name).GetValue(x), pkType) == Convert.ChangeType(id, pkType) ;
            }
            catch (Exception)
            {
                return default;
            }
        }

        private static object GetObjectValue<T>(T entity, string propertyName) where T : class
        {
            return entity.GetType().GetProperty(propertyName).GetValue(entity);
        }*/
        /*public virtual List<TModel> Paginate(List<TModel>? entities = null, int itemsPerPage = 20, int page = 1)
        {
            if (entities == null)
                return new List<TModel>();

            int skip = (page - 1) * itemsPerPage;

            entities = entities.Skip(skip).Take(itemsPerPage).ToList();

            return entities;
        }*/
    }
}
