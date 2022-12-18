using Microsoft.EntityFrameworkCore;
using MockInterview.Domain.Entities;
using MockInterview.Infrastructure.Data;
using MockInterview.Infrastructure.Interface;
using System.Collections.Generic;

namespace MockInterview.Infrastructure.Repository
{
    public class EmployeeRepositoryAsync : GenericRepositoryAsync<Employee>, IEmployeeRepositoryAsync
    {
        public readonly DbSet<Employee> employees;
        private readonly ApplicationDbContext context;
        public EmployeeRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this.employees = context.Employees;
            this.context = context;
        }


        public async Task<Employee> LoginAsync(string login, string password) => 
            await FindAsync(e => e.Login == login && e.Password== password);

        public async Task<bool> RemoveAsync(Guid id, Guid currentId)
        {
            try
            {
                var entity = await employees.FindAsync(id);

                if (entity is null)
                    return true;

                entity.IsActive = false;
                entity.UpdatedBy = currentId;
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

    }
}
