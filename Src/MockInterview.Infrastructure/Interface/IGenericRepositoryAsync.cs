using MockInterview.Domain;
using System.Linq.Expressions;

namespace MockInterview.Infrastructure.Interface
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> Find(Expression<Func<T, bool>> expression);
        Task<T> Find(Expression<Func<T, bool>> expression, List<string> tables);
    }
}
