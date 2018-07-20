using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace George.Framework.Extension
{
    public static class CorsExtension
    {
        public static void AddAnyCors(this IServiceCollection services)
        {
            services.AddCors(p =>
            {
                p.AddDefaultPolicy(c =>
                {
                    c.AllowAnyHeader();
                    c.AllowAnyMethod();
                    c.AllowAnyOrigin();
                });
            });
        }
    }
}
