using MockInterview.Domain;
using System.Linq.Expressions;

namespace MockInterview.Infrastructure.Interface
{
    public interface IGenericRepositoryAsync<T> where T : BaseEntity
    {
        Task<bool> CreateAsync(T entity);
        bool UpdateAsync(T entity);
        Task<bool> DeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<T> FindAsync(Expression<Func<T, bool>> expression, List<string> tables);
    }
}
