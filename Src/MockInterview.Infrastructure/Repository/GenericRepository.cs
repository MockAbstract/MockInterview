using Microsoft.EntityFrameworkCore;
using MockInterview.Domain;
using MockInterview.Infrastructure.Data;
using MockInterview.Infrastructure.Interface;
using System.Linq.Expressions;

namespace MockInterview.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<T> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<T> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="tables"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<T> Find(Expression<Func<T, bool>> expression, List<string> tables)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
