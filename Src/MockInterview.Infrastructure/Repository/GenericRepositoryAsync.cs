using Microsoft.EntityFrameworkCore;
using MockInterview.Domain;
using MockInterview.Infrastructure.Data;
using MockInterview.Infrastructure.Interface;
using System.Linq.Expressions;

namespace MockInterview.Infrastructure.Repository
{
    public abstract class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<T> dbSet;

        public GenericRepositoryAsync(ApplicationDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        /// <summary>
        /// Insert new entity to table
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<bool> InsertAsync(T entity)
        {
            try
            {
                await dbSet.AddAsync(entity);
                bool isSucces = await SaveChangesAsync();
                if(isSucces)
                {
                    return true;
                }
                return false;
            }
            catch
            {
                return true;
            }
        }

        /// <summary>
        /// Delete Entity
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<bool> RemoveAsync(Guid id)
        {
            try
            {
                var entity = await dbSet.FindAsync(id);

                if (entity is null)
                    return true;

                entity.IsActive = false;
                this.context.Entry(entity).State = EntityState.Modified;
                bool isSucces = await SaveChangesAsync();

                if (isSucces)
                {
                    return true;
                }

                return false;
            }
            catch
            {
                return false;
            }
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
        /// Get all entity
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<(IEnumerable<T> entities, int count)> GetAllAsync()
        {
            var entities = await dbSet.AsNoTracking()
                .Where(entity => entity.IsActive.Equals(true)).ToListAsync();

            return (entities, entities.Count);
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async virtual Task<bool> UpdateAsync(T entity)
        {
            try
            {
                this.context.Entry(entity).State = EntityState.Modified;
                bool isSucces = await SaveChangesAsync();

                if (isSucces)
                {
                    return true;
                }

                return false;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());

                return false;
            }
        }

        /// <summary>
        /// Get page entities
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public virtual async Task<(IEnumerable<T> entities, int count)> GetPageListAsync(int pageNumber, int pageSize)
        {
            var entities = await  dbSet.AsNoTracking()
                .Where(entity => entity.IsActive)
                    .Skip((pageNumber - 1)*pageSize).Take(pageSize).ToListAsync();

            var count = await dbSet.AsNoTracking()
                .Where(entity => entity.IsActive).CountAsync();

            return (entities, count);
        }

        public async Task<bool> SaveChangesAsync() =>
             await context.SaveChangesAsync() > 0 ? true : false;

        public virtual async Task<IEnumerable<T>> GetAllAsync(List<string> tables)
        {
            IQueryable<T> entities = dbSet.AsNoTracking();
            foreach (var table in tables)
            {
                entities = entities.Include(table);
            }
            return await entities.Where(entity => entity.IsActive.Equals(true)).ToListAsync();
        }
    }
}
