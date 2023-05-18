namespace VLS.Infrastructure.Interfaces.IRepositories.IBaseRepositories
{
    public interface IRepository<TModel, TViewModel, TDTO> : IViewRepository<TModel, TViewModel, TDTO> 
        where TModel : BaseEntity
        where TViewModel : VMBaseEntity
    {
        ActionResponse Create(TModel entity);
        ActionResponse Create(TDTO entity);
        ActionResponse Create(List<TModel> DbModels);
        ActionResponse Create(List<TDTO> DbModels);
        Task<ActionResponse> CreateAsync(TModel entity);
        Task<ActionResponse> CreateAsync(TDTO entity);
        Task<ActionResponse> CreateAsync(List<TModel> DbModels);
        Task<ActionResponse> CreateAsync(List<TDTO> DbModels);

        ActionResponse Delete(object id);
        ActionResponse Delete(List<object> ids);
        Task<ActionResponse> DeleteAsync(object id);
        Task<ActionResponse> DeleteAsync(List<object> ids);

        ActionResponse Update(TModel entity);
        ActionResponse Update(List<TModel> DbModels);
        Task<ActionResponse> UpdateAsync(TModel entity);
        Task<ActionResponse> UpdateAsync(List<TModel> DbModels);
    }
}
