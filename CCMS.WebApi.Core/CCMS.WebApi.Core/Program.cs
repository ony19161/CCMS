using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CCMS.WebApi.Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost webHost = CreateWebHostBuilder(args);
            webHost.Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args)
        {
            IWebHostBuilder webhostBuilder = WebHost.CreateDefaultBuilder(args)
                .ConfigureLogging((hostingContext, builder) => 
                {
                    builder.AddFile("C:/Temp/Logs/appLog-{Date}.txt");
                })
                .UseStartup<Startup>();

            return webhostBuilder.Build();
        }
    }
}
