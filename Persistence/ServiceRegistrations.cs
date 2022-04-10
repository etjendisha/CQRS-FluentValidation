using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.GenericRepository;
using Persistence.GenericRepository;
using Persistence.Repositories;
using Application.Interfaces.Repositories;

namespace Persistence
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddPersistenceLayer(this IServiceCollection services)
        {
            services.AddTransient(typeof(IGenericRepositoryAsync<,>), typeof(GenericRepositoryAsync<,>));
            services.AddScoped<IActivityRepositoryAsync, ActivityRepositoryAsync>();

            return services;
        }
    }
}
