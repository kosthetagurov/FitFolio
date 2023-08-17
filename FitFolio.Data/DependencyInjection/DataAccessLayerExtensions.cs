using FitFolio.Data.Access;
using FitFolio.Data.Models;
using FitFolio.Data.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitFolio.Data.DependencyInjection
{
    public static class DataAccessLayerExtensions
    {
        public static IServiceCollection AddFitFolioData(this IServiceCollection services, DataAccessLayerOptions options)
        {
            services.AddDbContext<ApplicationDbContext>(o =>
            {
                o.UseNpgsql(options.ConnectionString);
            });

            services.AddScoped<RepositoryFactory>(provider =>
            {
                return new RepositoryFactory(options.ConnectionString);
            });

            return services;
        }
    }
}
