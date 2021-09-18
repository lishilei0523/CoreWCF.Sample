using Sample.IAppService.DTOs.Outputs;
using System.ServiceModel;

namespace Sample.IAppService.Interfaces
{
    /// <summary>
    /// 订单服务契约接口
    /// </summary>
    [ServiceContract(Namespace = "http://Sample.IAppService.Interfaces")]
    public interface IOrderContract
    {
        /// <summary>
        /// 获取订单
        /// </summary>
        [OperationContract]
        OrderInfo GetOrder(string number);
    }
}
