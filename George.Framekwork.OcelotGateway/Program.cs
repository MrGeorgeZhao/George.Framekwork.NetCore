﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Ocelot.DependencyInjection;

namespace George.Framekwork.OcelotGateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration((h, b) =>
            {
                b.SetBasePath(h.HostingEnvironment.ContentRootPath)
                .AddJsonFile("Ocelot.json");
            }).UseStartup<Startup>().UseUrls("http://*:7000")
                .Build();
    }
}
