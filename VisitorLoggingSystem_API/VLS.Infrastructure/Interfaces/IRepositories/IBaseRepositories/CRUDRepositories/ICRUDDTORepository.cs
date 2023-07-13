namespace VLS.Infrastructure.Interfaces.IRepositories.IBaseRepositories.CRUDRepositories
{
    public interface ICRUDDTORepository<TDTOModel>
    {
        ActionResponse Create(TDTOModel entity);
        ActionResponse Create(List<TDTOModel> entities);
        Task<ActionResponse> CreateAsync(TDTOModel entity);
        Task<ActionResponse> CreateAsync(List<TDTOModel> entities);
    }
}
