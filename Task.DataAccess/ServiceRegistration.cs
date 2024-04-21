
using Microsoft.Extensions.DependencyInjection;
using Task.DataAccess.Repositories.Abstractions;
using Task.DataAccess.Repositories.Implementations;

namespace Task.DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            //var cc = Configuration.ConnectionString;


            services.AddScoped<IGoodRepository, GoodRepository>();
           
           
        }
    }
}