using Microsoft.Extensions.DependencyInjection;
using MockInterview.Business.Profile;

namespace MockInterview.Business.Extentions
{
    public static class ServiseRegistration
    {
        public static void AddBusinessLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingInitializer));

        }
    }
}
