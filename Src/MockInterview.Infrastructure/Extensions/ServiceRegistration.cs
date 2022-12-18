using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MockInterview.Infrastructure.Data;
using MockInterview.Infrastructure.Interface;
using MockInterview.Infrastructure.Repository;

namespace MockInterview.Infrastructure.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("DefaultSqlServerConnection")
                ));

            services.AddTransient<IEmployeeRepositoryAsync, EmployeeRepositoryAsync>();
            services.AddTransient<IClientRepositoryAsync, ClientRepositoryAsync>();
            services.AddTransient<ICategoryRepositoryAsync, CategoryRepositoryAsync>();
            services.AddTransient<IInterviewRepositoryAsync, InterviewRepositoryAsync>();
        }
    }
}
