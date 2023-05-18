using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VLS.Shared.Resources;

namespace VLS.Infrastructure.Repositories.BaseRepositories
{
    public class Repository<TModel, TViewModel, TDTO> : ViewRepository<TModel, TViewModel, TDTO>, IRepository<TModel, TViewModel, TDTO> 
        where TModel : BaseEntity
        where TViewModel : VMBaseEntity
    {
        private readonly VLSDbContext _context;
        internal new DbSet<TModel> _entity;
        protected new readonly ILogger<TModel> _logger;
        private readonly IMapper _mapper;

        public Repository(VLSDbContext context, ILogger<TModel> logger, IMapper mapper) : base(context, logger, mapper)
        {
            _context = context;
            _entity = _context.Set<TModel>();
            _logger = logger;
            _mapper = mapper;
        }

        public virtual ActionResponse Create(TModel entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entity.CreatedBy = 1;
                entity.CreatedOn = DateTime.Now;
                _entity.Add(entity);
                _context.SaveChanges();

                return new ActionResponse() { IsSuccess = true, Message = Resources.SuccessCreate };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual ActionResponse Create(TDTO entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            var dbEntity = _mapper.Map<TModel>(entity);

            try
            {
                dbEntity.CreatedBy = 1;
                dbEntity.CreatedOn = DateTime.Now;
                _entity.Add(dbEntity);
                _context.SaveChanges();

                return new ActionResponse() { IsSuccess = true, Message = Resources.SuccessCreate };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual ActionResponse Create(List<TModel> entities)
        {
            entities.TryGetNonEnumeratedCount(out int count);

            if (entities == null || count == 0)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entities.ForEach(x =>
                {
                    x.CreatedBy = 1;
                    x.CreatedOn = DateTime.Now;
                });
                _entity.AddRange(entities);
                _context.SaveChanges();

                return new ActionResponse() { IsSuccess = true, Message = Resources.SuccessCreate };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual ActionResponse Create(List<TDTO> entities)
        {
            entities.TryGetNonEnumeratedCount(out int count);

            if (entities == null || count == 0)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            var dbEntities = entities.Select(e => _mapper.Map<TModel>(e)).ToList();
            try
            {
                dbEntities.ForEach(x =>
                {
                    x.CreatedBy = 1;
                    x.CreatedOn = DateTime.Now;
                });
                _entity.AddRange(dbEntities);
                _context.SaveChanges();

                return new ActionResponse() { IsSuccess = true, Message = Resources.SuccessCreate };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual async Task<ActionResponse> CreateAsync(TModel entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entity.CreatedBy = 1;
                entity.CreatedOn = DateTime.Now;
                await _entity.AddAsync(entity);
                await _context.SaveChangesAsync();

                return new ActionResponse() { IsSuccess = true, Message = Resources.SuccessCreate };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual async Task<ActionResponse> CreateAsync(TDTO entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            var dbEntity = _mapper.Map<TModel>(entity);

            try
            {
                dbEntity.CreatedBy = 1;
                dbEntity.CreatedOn = DateTime.Now;
                await _entity.AddAsync(dbEntity);
                await _context.SaveChangesAsync();

                return new ActionResponse() { IsSuccess = true, Message = Resources.SuccessCreate };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual async Task<ActionResponse> CreateAsync(List<TModel> entities)
        {
            entities.TryGetNonEnumeratedCount(out int count);

            if (entities == null || count == 0)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entities.ForEach(x =>
                {
                    x.CreatedBy = 1;
                    x.CreatedOn = DateTime.Now;
                });
                await _entity.AddRangeAsync(entities);
                await _context.SaveChangesAsync();

                return new ActionResponse() { IsSuccess = true, Message = Resources.SuccessCreate };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual async Task<ActionResponse> CreateAsync(List<TDTO> entities)
        {
            entities.TryGetNonEnumeratedCount(out int count);

            if (entities == null || count == 0)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            var dbEntities = entities.Select(e => _mapper.Map<TModel>(e)).ToList();

            try
            {
                dbEntities.ForEach(x =>
                {
                    x.CreatedBy = 1;
                    x.CreatedOn = DateTime.Now;
                });
                await _entity.AddRangeAsync(dbEntities);
                await _context.SaveChangesAsync();

                return new ActionResponse() { IsSuccess = true, Message = Resources.SuccessCreate };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual ActionResponse Delete(object? id)
        {
            TModel? entity = GetById(id);

            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            try
            {
                _entity.Remove(entity);
                _context.SaveChanges();

                return new ActionResponse() { IsSuccess = true, Message = Resources.SuccessDelete };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public ActionResponse Delete(List<object> ids)
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
                return new ActionResponse() { IsSuccess = false, Message = $"Error! Missing entities: {missingEntities.ToString()}" };

            try
            {
                _entity.RemoveRange(entities);
                _context.SaveChanges();

                return new ActionResponse() { IsSuccess = true, Message = Resources.SuccessDelete };

            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual async Task<ActionResponse> DeleteAsync(object? id)
        {
            TModel? entity = await GetByIdAsync(id);

            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNotFound };

            try
            {
                _entity.Remove(entity);
                await _context.SaveChangesAsync();

                return new ActionResponse() { IsSuccess = true, Message = Resources.SuccessDelete };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual async Task<ActionResponse> DeleteAsync(List<object> ids)
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
                return new ActionResponse() { IsSuccess = false, Message = $"Error! Missing entities: {missingEntities.ToString()}" };

            try
            {
                _entity.RemoveRange(entities);
                await _context.SaveChangesAsync();

                return new ActionResponse() { IsSuccess = true, Message = Resources.SuccessDelete };

            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public ActionResponse Update(TModel entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entity.ModifiedBy = 1;
                entity.ModifiedOn = DateTime.Now;
                _entity.Update(entity);
                _context.SaveChanges();

                return new ActionResponse() { IsSuccess = true, Message = Resources.SuccessUpdate };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public ActionResponse Update(List<TModel> entities)
        {
            entities.TryGetNonEnumeratedCount(out int count);

            if (entities == null || count == 0)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entities.ForEach(x =>
                {
                    x.ModifiedBy = 1;
                    x.ModifiedOn = DateTime.Now;
                });
                _entity.UpdateRange(entities);
                _context.SaveChanges();

                return new ActionResponse() { IsSuccess = true, Message = Resources.SuccessUpdate };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual async Task<ActionResponse> UpdateAsync(TModel entity)
        {
            if (entity == null)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entity.ModifiedBy = 1;
                entity.ModifiedOn = DateTime.Now;
                _entity.Update(entity);
                await _context.SaveChangesAsync();

                return new ActionResponse() { IsSuccess = true, Message = Resources.SuccessUpdate };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }

        public virtual async Task<ActionResponse> UpdateAsync(List<TModel> entities)
        {
            entities.TryGetNonEnumeratedCount(out int count);

            if (entities == null || count == 0)
                return new ActionResponse() { IsSuccess = false, Message = Resources.EntityNull };

            try
            {
                entities.ForEach(x =>
                {
                    x.ModifiedBy = 1;
                    x.ModifiedOn = DateTime.Now;
                });
                _entity.UpdateRange(entities);
                await _context.SaveChangesAsync();

                return new ActionResponse() { IsSuccess = true, Message = Resources.Success };
            }
            catch (Exception e)
            {
                return new ActionResponse() { IsSuccess = false, Message = $"Exception: {e.InnerException}" };
            }
        }
    }
}
