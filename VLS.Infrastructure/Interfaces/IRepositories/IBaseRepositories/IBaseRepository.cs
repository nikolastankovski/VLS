using VLS.Infrastructure.Interfaces.IRepositories.IBaseRepositories.ReadRepositories;

namespace VLS.Infrastructure.Interfaces.IRepositories.IBaseRepositories
{
    public interface IBaseRepository<TModel> : IReadRepository<TModel>
    {
        CRUDResponse Create(TModel entity);
        CRUDResponse Create(List<TModel> entities);
        Task<CRUDResponse> CreateAsync(TModel entity);
        Task<CRUDResponse> CreateAsync(List<TModel> entities);

        CRUDResponse Delete(object id);
        CRUDResponse Delete(List<object> ids);
        Task<CRUDResponse> DeleteAsync(object id);
        Task<CRUDResponse> DeleteAsync(List<object> ids);

        CRUDResponse Update(TModel entity);
        CRUDResponse Update(List<TModel> entities);
        Task<CRUDResponse> UpdateAsync(TModel entity);
        Task<CRUDResponse> UpdateAsync(List<TModel> entities);
    }
}
