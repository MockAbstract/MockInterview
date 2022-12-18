using MockInterview.Domain;
using System.Linq.Expressions;

namespace MockInterview.Infrastructure.Interface
{
    public interface IGenericRepositoryAsync<T> where T : BaseEntity
    {
        Task<bool> InsertAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> RemoveAsync(Guid id);
        Task<(IEnumerable<T> entities, int count)> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(List<string> tables);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<T> FindAsync(Expression<Func<T, bool>> expression, List<string> tables);
        Task<(IEnumerable<T> entities, int count)> GetPageListAsync(int pageNumber, int pageSize);
        Task<bool> SaveChangesAsync();
    }
}
