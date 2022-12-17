using Microsoft.Extensions.DependencyInjection;
using MockInterview.Business.Helper;
using MockInterview.Business.Interface;
using MockInterview.Business.Services;

namespace MockInterview.Business.Extentions
{
    public static class ServiseRegistration
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingInitializer));

            services.AddTransient<IEmployeeServiceAsync, EmployeeServiceAsync>();

        }
    }
}
