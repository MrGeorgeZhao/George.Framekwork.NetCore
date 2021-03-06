﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace George.Framework.OrderWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args).ConfigureAppConfiguration((h, c) =>
            {
                c.SetBasePath(h.HostingEnvironment.ContentRootPath)
              .AddJsonFile("appsettings.json");
            }).UseStartup<Startup>().UseUrls("http://*:9001").Build();
    }
}
