using CoreWCF.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SD.Toolkits.AspNet;
using SD.Toolkits.AspNet.Configurations;
using System.Collections.Generic;
using System.Linq;

namespace Sample.AppService.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHostBuilder hostBuilder = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder();

            //WebHost配置
            hostBuilder.ConfigureWebHostDefaults(webBuilder =>
            {
                ICollection<string> urls = new HashSet<string>();
                foreach (HostElement hostElement in AspNetSection.Setting.HostElements)
                {
                    urls.Add(hostElement.Url);
                }

                webBuilder.UseKestrel();
                webBuilder.UseUrls(urls.ToArray());
                webBuilder.UseNetTcp(40710);
                webBuilder.UseStartup<Startup>();
            });

            //依赖注入配置
            ServiceLocator serviceLocator = new ServiceLocator();
            hostBuilder.UseServiceProviderFactory(serviceLocator);

            IHost host = hostBuilder.Build();
            host.Run();
        }
    }
}
