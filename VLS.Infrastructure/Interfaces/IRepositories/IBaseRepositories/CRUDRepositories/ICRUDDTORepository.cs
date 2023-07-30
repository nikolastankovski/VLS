namespace VLS.Infrastructure.Interfaces.IRepositories.IBaseRepositories.CRUDRepositories
{
    public interface ICRUDDTORepository<TDTOModel>
    {
        CRUDResponse Create(TDTOModel entity);
        CRUDResponse Create(List<TDTOModel> entities);
        Task<CRUDResponse> CreateAsync(TDTOModel entity);
        Task<CRUDResponse> CreateAsync(List<TDTOModel> entities);
    }
}
