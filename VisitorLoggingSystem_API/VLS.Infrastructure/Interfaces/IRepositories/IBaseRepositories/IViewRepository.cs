using System.Linq.Expressions;
using VLS.Domain;

namespace VLS.Infrastructure.Interfaces.IRepositories.IBaseRepositories
{
    public interface IViewRepository<T> where T : BaseEntity
    {
        List<T> Get(
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, int, T>>? select = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = ""
        );
        Task<List<T>> GetAsync(
            Expression<Func<T, bool>>? filter = null,
            Expression<Func<T, int, T>>? select = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = ""
        );
        List<T> GetAll(bool? isActive = null);
        Task<List<T>> GetAllAsync(bool? isActive = null);
        T? GetById(object? id);
        Task<T?> GetByIdAsync(object? id);
    }
}
