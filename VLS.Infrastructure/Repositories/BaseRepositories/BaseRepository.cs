using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VLS.Infrastructure.Interfaces.IRepositories.IBaseRepositories;
using VLS.Shared.Resources;

namespace VLS.Infrastructure.Repositories.BaseRepositories
{
    public class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : BaseEntity
    {
        private readonly VLSDbContext _context;
        private new DbSet<TModel> _entity;
        //protected new readonly ILogger<TModel> _logger;
        //private readonly IMapper _mapper;

        public BaseRepository(
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

        public virtual CRUDResponse Create(TModel entity)
        {
            if (entity == null)
                return new CRUDResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entity.CreatedBy = 1;
                entity.CreatedOn = DateTime.Now;
                _entity.Add(entity);
                _context.SaveChanges();

                return new CRUDResponse() { IsSuccess = true, Message = Resources.SuccessCreate };
            }
            catch (Exception e)
            {
                return new CRUDResponse() { IsSuccess = false, Message = $"Exception: {(e.InnerException == null ? e.Message : e.InnerException.Message)}" };
            }
        }

        public virtual CRUDResponse Create(List<TModel> entities)
        {
            entities.TryGetNonEnumeratedCount(out int count);

            if (entities == null || count == 0)
                return new CRUDResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entities.ForEach(x =>
                {
                    x.CreatedBy = 1;
                    x.CreatedOn = DateTime.Now;
                });
                _entity.AddRange(entities);
                _context.SaveChanges();

                return new CRUDResponse() { IsSuccess = true, Message = Resources.SuccessCreate };
            }
            catch (Exception e)
            {
                return new CRUDResponse() { IsSuccess = false, Message = $"Exception: {(e.InnerException == null ? e.Message : e.InnerException.Message)}" };
            }
        }

        public virtual async Task<CRUDResponse> CreateAsync(TModel entity)
        {
            if (entity == null)
                return new CRUDResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entity.CreatedBy = 1;
                entity.CreatedOn = DateTime.Now;
                await _entity.AddAsync(entity);
                await _context.SaveChangesAsync();

                return new CRUDResponse() { IsSuccess = true, Message = Resources.SuccessCreate };
            }
            catch (Exception e)
            {
                return new CRUDResponse() { IsSuccess = false, Message = $"Exception: {(e.InnerException == null ? e.Message : e.InnerException.Message)}" };
            }
        }

        public virtual async Task<CRUDResponse> CreateAsync(List<TModel> entities)
        {
            entities.TryGetNonEnumeratedCount(out int count);

            if (entities == null || count == 0)
                return new CRUDResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entities.ForEach(x =>
                {
                    x.CreatedBy = 1;
                    x.CreatedOn = DateTime.Now;
                });
                await _entity.AddRangeAsync(entities);
                await _context.SaveChangesAsync();

                return new CRUDResponse() { IsSuccess = true, Message = Resources.SuccessCreate };
            }
            catch (Exception e)
            {
                return new CRUDResponse() { IsSuccess = false, Message = $"Exception: {(e.InnerException == null ? e.Message : e.InnerException.Message)}" };
            }
        }

        public virtual CRUDResponse Delete(object id)
        {
            TModel? entity = GetById(id);

            if (entity == null)
                return new CRUDResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            try
            {
                _entity.Remove(entity);
                _context.SaveChanges();

                return new CRUDResponse() { IsSuccess = true, Message = Resources.SuccessDelete };
            }
            catch (Exception e)
            {
                return new CRUDResponse() { IsSuccess = false, Message = $"Exception: {(e.InnerException == null ? e.Message : e.InnerException.Message)}" };
            }
        }

        public virtual CRUDResponse Delete(List<object> ids)
        {
            List<TModel> entities = new List<TModel>();
            List<object> missingEntities = new List<object>();

            foreach (var id in ids)
            {
                TModel? entity = GetById(id);

                if (entity == null)
                {
                    missingEntities.Add(id);
                    continue;
                }

                entities.Add(entity);
            }

            missingEntities.TryGetNonEnumeratedCount(out int count);

            if (count > 0)
                return new CRUDResponse() { IsSuccess = false, Message = $"Error! Missing entities: {missingEntities.ToString()}" };

            try
            {
                _entity.RemoveRange(entities);
                _context.SaveChanges();

                return new CRUDResponse() { IsSuccess = true, Message = Resources.SuccessDelete };

            }
            catch (Exception e)
            {
                return new CRUDResponse() { IsSuccess = false, Message = $"Exception: {(e.InnerException == null ? e.Message : e.InnerException.Message)}" };
            }
        }

        public virtual async Task<CRUDResponse> DeleteAsync(object id)
        {
            TModel? entity = await GetByIdAsync(id);

            if (entity == null)
                return new CRUDResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            try
            {
                _entity.Remove(entity);
                await _context.SaveChangesAsync();

                return new CRUDResponse() { IsSuccess = true, Message = Resources.SuccessDelete };
            }
            catch (Exception e)
            {
                return new CRUDResponse() { IsSuccess = false, Message = $"Exception: {(e.InnerException == null ? e.Message : e.InnerException.Message)}" };
            }
        }

        public virtual async Task<CRUDResponse> DeleteAsync(List<object> ids)
        {
            List<TModel> entities = new List<TModel>();
            List<object> missingEntities = new List<object>();

            foreach (var id in ids)
            {
                TModel? entity = await GetByIdAsync(id);

                if (entity == null)
                {
                    missingEntities.Add(id);
                    continue;
                }

                entities.Add(entity);
            }

            missingEntities.TryGetNonEnumeratedCount(out int count);

            if (count > 0)
                return new CRUDResponse() { IsSuccess = false, Message = $"Error! Missing entities: {missingEntities.ToString()}" };

            try
            {
                _entity.RemoveRange(entities);
                await _context.SaveChangesAsync();

                return new CRUDResponse() { IsSuccess = true, Message = Resources.SuccessDelete };

            }
            catch (Exception e)
            {
                return new CRUDResponse() { IsSuccess = false, Message = $"Exception: {(e.InnerException == null ? e.Message : e.InnerException.Message)}" };
            }
        }

        public virtual CRUDResponse Update(TModel entity)
        {
            if (entity == null)
                return new CRUDResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entity.ModifiedBy = 1;
                entity.ModifiedOn = DateTime.Now;
                _entity.Update(entity);
                _context.SaveChanges();

                return new CRUDResponse() { IsSuccess = true, Message = Resources.SuccessUpdate };
            }
            catch (Exception e)
            {
                return new CRUDResponse() { IsSuccess = false, Message = $"Exception: {(e.InnerException == null ? e.Message : e.InnerException.Message)}" };
            }
        }

        public virtual CRUDResponse Update(List<TModel> entities)
        {
            entities.TryGetNonEnumeratedCount(out int count);

            if (entities == null || count == 0)
                return new CRUDResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entities.ForEach(x =>
                {
                    x.ModifiedBy = 1;
                    x.ModifiedOn = DateTime.Now;
                });
                _entity.UpdateRange(entities);
                _context.SaveChanges();

                return new CRUDResponse() { IsSuccess = true, Message = Resources.SuccessUpdate };
            }
            catch (Exception e)
            {
                return new CRUDResponse() { IsSuccess = false, Message = $"Exception: {(e.InnerException == null ? e.Message : e.InnerException.Message)}" };
            }
        }

        public virtual async Task<CRUDResponse> UpdateAsync(TModel entity)
        {
            if (entity == null)
                return new CRUDResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entity.ModifiedBy = 1;
                entity.ModifiedOn = DateTime.Now;
                _entity.Update(entity);
                await _context.SaveChangesAsync();

                return new CRUDResponse() { IsSuccess = true, Message = Resources.SuccessUpdate };
            }
            catch (Exception e)
            {
                return new CRUDResponse() { IsSuccess = false, Message = $"Exception: {(e.InnerException == null ? e.Message : e.InnerException.Message)}" };
            }
        }

        public virtual async Task<CRUDResponse> UpdateAsync(List<TModel> entities)
        {
            entities.TryGetNonEnumeratedCount(out int count);

            if (entities == null || count == 0)
                return new CRUDResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entities.ForEach(x =>
                {
                    x.ModifiedBy = 1;
                    x.ModifiedOn = DateTime.Now;
                });
                _entity.UpdateRange(entities);
                await _context.SaveChangesAsync();

                return new CRUDResponse() { IsSuccess = true, Message = Resources.Success };
            }
            catch (Exception e)
            {
                return new CRUDResponse() { IsSuccess = false, Message = $"Exception: {(e.InnerException == null ? e.Message : e.InnerException.Message)}" };
            }
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
