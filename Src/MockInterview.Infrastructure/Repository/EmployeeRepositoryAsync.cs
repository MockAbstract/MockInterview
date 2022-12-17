using Microsoft.EntityFrameworkCore;
using MockInterview.Domain.Entities;
using MockInterview.Infrastructure.Data;
using MockInterview.Infrastructure.Interface;

namespace MockInterview.Infrastructure.Repository
{
    public class EmployeeRepositoryAsync : GenericRepositoryAsync<Employee>, IEmployeeRepositoryAsync
    {
        public readonly DbSet<Employee> Employees;
        public EmployeeRepositoryAsync(ApplicationDbContext context) : base(context)
        {
            this.Employees = context.Employees;
        }


        public async Task<Employee> LoginAsync(string login, string password) => 
            await FindAsync(e => e.Login == login && e.Password== password);
    }
}
