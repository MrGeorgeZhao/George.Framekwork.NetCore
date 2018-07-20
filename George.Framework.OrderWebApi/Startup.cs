using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using George.Framekwork.Consul;
using George.Framework.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace George.Framework.OrderWebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();


            ConsulProcessProvider.Register(new ConsulSetting()
            {
                ClientPort = Configuration.GetValue<int>("Consul:ClientPort"),
                Ip = Configuration.GetValue<string>("Consul:Ip"),
                ServiceName = Configuration.GetValue<string>("Consul:ServiceName"),
                Url = Configuration.GetValue<string>("Consul:Url"),
                ServiceId = Configuration.GetValue<string>("Consul:ServiceId"),
            }).Wait();

            applicationLifetime.ApplicationStopped.Register(() =>
            {
                ConsulProcessProvider.DeRegister(new ConsulSetting()
                {
                    ClientPort = Configuration.GetValue<int>("Consul:ClientPort"),
                    Ip = Configuration.GetValue<string>("Consul:Ip"),
                    ServiceName = Configuration.GetValue<string>("Consul:ServiceName"),
                    Url = Configuration.GetValue<string>("Consul:Url"),
                    ServiceId = Configuration.GetValue<string>("Consul:ServiceId"),
                }).Wait();
            });

        }
    }
}
