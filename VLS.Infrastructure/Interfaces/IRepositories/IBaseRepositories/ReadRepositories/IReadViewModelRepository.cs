using System.Linq.Expressions;

namespace VLS.Infrastructure.Interfaces.IRepositories.IBaseRepositories.ReadRepositories
{
    public interface IReadViewModelRepository<TModel, TViewModel>
    {
        List<TViewModel> GetVM(
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

        List<TViewModel> GetAllVM(bool? isActive = null);
        Task<List<TViewModel>> GetAllVMAsync(bool? isActive = null);

        TViewModel? GetVMById(object id);
        Task<TViewModel?> GetVMByIdAsync(object id);

    }
}
