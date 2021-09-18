using System;
using Sample.IAppService.DTOs.Outputs;
using Sample.IAppService.Interfaces;
#if NET461_OR_GREATER
using System.ServiceModel;
#endif
#if NETSTANDARD2_0_OR_GREATER
using CoreWCF;
#endif

namespace Sample.AppService.Implements
{
    /// <summary>
    /// 订单服务契约实现
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class OrderContract : IOrderContract
    {
        /// <summary>
        /// 获取订单
        /// </summary>
        public OrderInfo GetOrder(string number)
        {
            OrderInfo orderInfo = new OrderInfo
            {
                Id = Guid.NewGuid(),
                Number = number
            };

            return orderInfo;
        }
    }
}
