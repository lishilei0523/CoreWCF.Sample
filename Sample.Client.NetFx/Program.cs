using Microsoft.Extensions.DependencyInjection;
using Sample.IAppService.DTOs.Outputs;
using Sample.IAppService.Interfaces;
using SD.IOC.Core.Mediators;
using SD.IOC.Extension.NetFx;
using System;

namespace Sample.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!ResolveMediator.ContainerBuilt)
            {
                IServiceCollection builder = ResolveMediator.GetServiceCollection();
                builder.RegisterConfigs();
                ResolveMediator.Build();
            }

            IOrderContract orderContract = ResolveMediator.Resolve<IOrderContract>();

            OrderInfo orderInfo = orderContract.GetOrder("单据编号");

            Console.WriteLine("单据服务");
            Console.WriteLine("单据Id：" + orderInfo.Id);
            Console.WriteLine("单据编号：" + orderInfo.Number);

            ResolveMediator.Dispose();
            Console.ReadKey();
        }
    }
}
