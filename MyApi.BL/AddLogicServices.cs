using Microsoft.Extensions.DependencyInjection;

using MyApi.BL.Person;

namespace MyApi.BL
{
    public static class AddLogicServicesExtensions
    {
        public static void AddLogicServices(this IServiceCollection services)
        {
    
            services.AddScoped<IBlPerson, BlPerson>();
          
        }
    }
}
