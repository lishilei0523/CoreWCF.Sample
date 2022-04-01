using CoreWCF.Configuration;
using CoreWCF.Description;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Sample.AppService.Implements;
using System.Configuration;

namespace Sample.AppService.Host
{
    /// <summary>
    /// Ӧ�ó���������
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// ���÷���
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceModelServices();
            services.AddServiceModelMetadata();

            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            services.AddServiceModelConfigurationManagerFile(configuration.FilePath);
        }

        /// <summary>
        /// ����Ӧ�ó���
        /// </summary>
        public void Configure(IApplicationBuilder appBuilder)
        {
            ServiceMetadataBehavior metadataBehavior = appBuilder.ApplicationServices.GetRequiredService<ServiceMetadataBehavior>();
            metadataBehavior.HttpGetEnabled = true;
            metadataBehavior.HttpsGetEnabled = true;
            UseRequestHeadersForMetadataAddressBehavior addressBehavior = new UseRequestHeadersForMetadataAddressBehavior();

            appBuilder.UseServiceModel(builder =>
            {
                builder.ConfigureServiceHostBase<OrderContract>(host => host.Description.Behaviors.Add(addressBehavior));
            });
        }
    }
}
