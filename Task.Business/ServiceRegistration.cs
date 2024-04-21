

using Microsoft.Extensions.DependencyInjection;
using Task.Business.Services.Abstractions;
using Task.Business.Services.Implementations;

namespace Task.Business.Services
{
    public static class ServiceRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
           

  
            services.AddScoped<IGoodtService, GoodService>();
           
            
        }
    }
}