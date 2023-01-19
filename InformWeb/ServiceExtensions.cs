using InformWeb.Repository.Common;
using InformWeb.Repository.Implementation;
using InformWeb.Repository.Interface;
using InformWeb.Service.Implementation;
using InformWeb.Service.Interface;
using Microsoft.Extensions.DependencyInjection;


namespace InformWeb
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }


        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IDbFactory, DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactService, ContactService>();
        }
    }
}
