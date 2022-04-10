using Infrastructure.Cors;
using Infrastructure.Mailing;
using Infrastructure.Mappings;
using Infrastructure.Middleware;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class ServiceRegistrations
    {
        public static IServiceCollection AddInfrastrucutreLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCorsPolicy(configuration);
            services.AddAutomapper();
            services.AddMailing(configuration);
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }

        public static IApplicationBuilder UseInfrastrucutreLayer(this IApplicationBuilder builder, IConfiguration configuration)
        {
            builder.UseExceptionMiddleware();
            builder.UseCorsPolicy();

            return builder;
        }
            
    }
}
