using System.Linq.Expressions;

namespace VLS.Infrastructure.Interfaces.IRepositories.IBaseRepositories
{
    public interface IViewRepository<TModel, TViewModel, TDTO> 
        where TModel : BaseEntity
        where TViewModel : VMBaseEntity
    {
        List<TModel> Get(
            Expression<Func<TModel, bool>>? filter = null,
            Expression<Func<TModel, int, TModel>>? select = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null,
            string includeProperties = ""
        );
        List<TViewModel> GetVM(
            Expression<Func<TModel, bool>>? filter = null,
            Expression<Func<TModel, int, TModel>>? select = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null,
            string includeProperties = ""
        );
        List<TDTO> GetDTO(
            Expression<Func<TModel, bool>>? filter = null,
            Expression<Func<TModel, int, TModel>>? select = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null,
            string includeProperties = ""
        );
        Task<List<TModel>> GetAsync(
            Expression<Func<TModel, bool>>? filter = null,
            Expression<Func<TModel, int, TModel>>? select = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null,
            string includeProperties = ""
        );
        Task<List<TViewModel>> GetVMAsync(
            Expression<Func<TModel, bool>>? filter = null,
            Expression<Func<TModel, int, TModel>>? select = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null,
            string includeProperties = ""
        );
        Task<List<TDTO>> GetDTOAsync(
            Expression<Func<TModel, bool>>? filter = null,
            Expression<Func<TModel, int, TModel>>? select = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null,
            string includeProperties = ""
        );
        List<TModel> GetAll(bool? isActive = null);
        List<TViewModel> GetAllVM(bool? isActive = null);
        List<TDTO> GetAllDTO(bool? isActive = null);

        Task<List<TModel>> GetAllAsync(bool? isActive = null);
        Task<List<TViewModel>> GetAllVMAsync(bool? isActive = null);
        Task<List<TDTO>> GetAllDTOAsync(bool? isActive = null);

        TModel? GetById(object id);
        TViewModel? GetVMById(object id);
        TDTO? GetDTOById(object id);

        Task<TModel?> GetByIdAsync(object id);
        Task<TViewModel?> GetVMByIdAsync(object id);
        Task<TDTO?> GetDTOByIdAsync(object id);

        private string GetIncludeProperties() { return string.Empty; }
    
        #pragma warning disable CS8603 // Possible null reference return.
        internal Expression<Func<TModel, bool>> GetWhereClauseByPK(object id) { return default; }
    }
}
