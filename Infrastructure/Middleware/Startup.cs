using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Middleware
{
    public static class Startup
    {
        //public static IServiceCollection AddExceptionMiddleware(this IServiceCollection services)
        //{
        //    return services.AddScoped<ErrorHandlerMiddleware>();
        //}

        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}
