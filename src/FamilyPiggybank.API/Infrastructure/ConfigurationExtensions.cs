using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FamilyPiggybank.API.Infrastructure
{
    public static class ConfigurationExtensions
    {
        public static string GetDefaultConnectionString(this IConfiguration configuration)
            => configuration.GetConnectionString("DefaultConnection");

        public static AppSettings GetAppSettings(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationSettingsConfig = configuration.GetSection("ApplicationSettings");
            services.Configure<AppSettings>(applicationSettingsConfig);

            return applicationSettingsConfig.Get<AppSettings>();
        }
    }
}
