using System.Linq.Expressions;

namespace VLS.Infrastructure.Interfaces.IRepositories.IBaseRepositories.ReadRepositories
{
    public interface IReadDTORepository<TModel, TDTOModel>
    {
        List<TDTOModel> GeTDTOModel(
            Expression<Func<TModel, bool>>? filter = null,
            Expression<Func<TModel, int, TModel>>? select = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null,
            string includeProperties = ""
        );
        Task<List<TDTOModel>> GeTDTOModelAsync(
            Expression<Func<TModel, bool>>? filter = null,
            Expression<Func<TModel, int, TModel>>? select = null,
            Func<IQueryable<TModel>, IOrderedQueryable<TModel>>? orderBy = null,
            string includeProperties = ""
        );

        List<TDTOModel> GetAllDTO(bool? isActive = null);
        Task<List<TDTOModel>> GetAllDTOAsync(bool? isActive = null);

        TDTOModel? GeTDTOModelById(object id);
        Task<TDTOModel?> GeTDTOModelByIdAsync(object id);

    }
}
