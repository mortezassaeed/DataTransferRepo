using DataAccess.SQL.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace DataAccess.SQL
{
    public static class MyConfigServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessServices(
             this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContextFactory<DatabaseContext>(option => 
                option.UseSqlServer(config.GetConnectionString("SQLDefault"),option => {
                })
            );


            services.AddTransient<IDataRepository, DataRespository>();
            
            return services;
        }
    }
}