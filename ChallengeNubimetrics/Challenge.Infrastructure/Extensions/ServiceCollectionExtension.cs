using Challenge.Core.CustomEntities;
using Challenge.Core.Interfaces;
using Challenge.Core.Services;
using Challenge.Infrastructure.Data;
using Challenge.Infrastructure.Interfaces;
using Challenge.Infrastructure.Repositories;
using Challenge.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using static Challenge.Core.Enumerations.Enum;

namespace Challenge.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddOptions(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<PasswordOptions>(options => configuration.GetSection("PasswordOptions").Bind(options));

            return services;
        }
        public static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<NubimetricsDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("defaultConnection"));
            });
            return services;
        }
        public static IServiceCollection AddAllowAllHeadersCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllHeaders",
                      builder =>
                      {
                          builder.AllowAnyOrigin()
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
            });
            return services;
        }
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient(nameof(Client.MercadoLibreClient), client =>
            {
                client.BaseAddress = new Uri(configuration["BaseUrl"]);
            });
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPasswordService, PasswordService>();
            return services;
        }
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Nubimetrics {groupName}",
                    Version = groupName,
                    Description = "Nubimetrics API",
                    Contact = new OpenApiContact
                    {
                        Name = "Nubimetrics",
                        Email = string.Empty,
                        Url = new Uri("https://www.nubimetrics.com/"),
                    }
                });
            });
            return services;
        }
    }
}
