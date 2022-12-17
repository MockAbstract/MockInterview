using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockInterview.Infrastructure.Interface
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(Guid id);
        Task<T> Find(Func<T, bool> conditionLambda);
    }
}
