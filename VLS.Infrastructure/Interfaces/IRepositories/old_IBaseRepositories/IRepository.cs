namespace VLS.Infrastructure.Interfaces.IRepositories.old_IBaseRepositories
{
    public interface IRepository<TModel, TViewModel, TDTO> : IViewRepository<TModel, TViewModel, TDTO> 
        where TModel : BaseEntity
        where TViewModel : VMBaseEntity
    {
        CRUDResponse Create(TModel entity);
        CRUDResponse Create(TDTO entity);
        CRUDResponse Create(List<TModel> DbModels);
        CRUDResponse Create(List<TDTO> DbModels);
        Task<CRUDResponse> CreateAsync(TModel entity);
        Task<CRUDResponse> CreateAsync(TDTO entity);
        Task<CRUDResponse> CreateAsync(List<TModel> entities);
        Task<CRUDResponse> CreateAsync(List<TDTO> entities);

        CRUDResponse Delete(object id);
        CRUDResponse Delete(List<object> ids);
        Task<CRUDResponse> DeleteAsync(object id);
        Task<CRUDResponse> DeleteAsync(List<object> ids);

        CRUDResponse Update(TModel entity);
        CRUDResponse Update(List<TModel> DbModels);
        Task<CRUDResponse> UpdateAsync(TModel entity);
        Task<CRUDResponse> UpdateAsync(List<TModel> DbModels);
    }
}
