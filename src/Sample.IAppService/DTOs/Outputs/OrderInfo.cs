using System;
using System.Runtime.Serialization;

namespace Sample.IAppService.DTOs.Outputs
{
    [DataContract]
    public class OrderInfo
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public string Number { get; set; }
    }
}
