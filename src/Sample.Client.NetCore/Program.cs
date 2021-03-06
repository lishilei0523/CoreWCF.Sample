using Microsoft.Extensions.DependencyInjection;
using Sample.IAppService.DTOs.Outputs;
using Sample.IAppService.Interfaces;
using SD.IOC.Core.Mediators;
using SD.IOC.Extension.NetCore.ServiceModel;
using System;

namespace Sample.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            #region # 信道工厂方式

            //初始化绑定
            //BasicHttpBinding binding = new BasicHttpBinding(BasicHttpSecurityMode.None);
            //binding.MaxBufferPoolSize = 2147483647;
            //binding.MaxBufferSize = 2147483647;
            //binding.MaxReceivedMessageSize = 2147483647;
            //binding.OpenTimeout = new TimeSpan(0, 10, 0);
            //binding.CloseTimeout = new TimeSpan(0, 10, 0);
            //binding.SendTimeout = new TimeSpan(0, 10, 0);
            //binding.ReceiveTimeout = new TimeSpan(0, 10, 0);

            //EndpointAddress orderContractAddress = new EndpointAddress("http://localhost:4071/Hosts/OrderContract.svc");
            //ChannelFactory<IOrderContract> orderContractFactory = new ChannelFactory<IOrderContract>(binding, orderContractAddress);
            //IOrderContract orderContract = orderContractFactory.CreateChannel(); 

            #endregion

            #region # 依赖注入方式

            if (!ResolveMediator.ContainerBuilt)
            {
                IServiceCollection builder = ResolveMediator.GetServiceCollection();
                builder.RegisterServiceModels();
                ResolveMediator.Build();
            }

            IOrderContract orderContract = ResolveMediator.Resolve<IOrderContract>();

            #endregion

            string orderNo = $"WO{DateTime.Now:yyyyMMddHHmmss}";
            OrderInfo orderInfo = orderContract.GetOrder(orderNo);

            Console.WriteLine("单据服务");
            Console.WriteLine("单据Id：" + orderInfo.Id);
            Console.WriteLine("单据编号：" + orderInfo.Number);

            ResolveMediator.Dispose();
            Console.ReadKey();
        }
    }
}
