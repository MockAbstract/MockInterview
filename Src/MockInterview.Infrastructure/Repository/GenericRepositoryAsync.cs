using Microsoft.EntityFrameworkCore;
using MockInterview.Domain;
using MockInterview.Infrastructure.Data;
using MockInterview.Infrastructure.Interface;
using System.Linq.Expressions;

namespace MockInterview.Infrastructure.Repository
{
    public abstract class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> dbSet;

        public GenericRepositoryAsync(ApplicationDbContext context)
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
        public virtual Task<bool> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Find entity from condition
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> expression) => 
            await this.dbSet.AsNoTracking().FirstOrDefaultAsync(expression);

        /// <summary>
        /// Find enitity with including some tables from condition
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="tables"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<T> FindAsync(Expression<Func<T, bool>> expression, List<string> tables)
        {
            IQueryable<T> entities = dbSet.AsNoTracking();
            foreach(var table in tables)
            {
                entities = entities.Include(table);
            }
            return await entities.FirstOrDefaultAsync(expression);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<IEnumerable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual Task<bool> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
