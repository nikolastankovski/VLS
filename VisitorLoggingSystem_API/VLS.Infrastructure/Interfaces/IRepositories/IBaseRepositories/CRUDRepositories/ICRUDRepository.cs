namespace VLS.Infrastructure.Interfaces.IRepositories.IBaseRepositories.CRUDRepositories
{
    public interface ICRUDRepository<TModel>
    {
        ActionResponse Create(TModel entity);
        ActionResponse Create(List<TModel> entities);
        Task<ActionResponse> CreateAsync(TModel entity);
        Task<ActionResponse> CreateAsync(List<TModel> entities);

        ActionResponse Delete(object id);
        ActionResponse Delete(List<object> ids);
        Task<ActionResponse> DeleteAsync(object id);
        Task<ActionResponse> DeleteAsync(List<object> ids);

        ActionResponse Update(TModel entity);
        ActionResponse Update(List<TModel> entities);
        Task<ActionResponse> UpdateAsync(TModel entity);
        Task<ActionResponse> UpdateAsync(List<TModel> entities);
    }
}
