using System.Collections.Generic;

namespace DB.Entity.ServiceResp
{
    public class ServiceResponse : IServiceResult
    {
        public object Data { get; set; }

        public string MessageType { get; set; }

        public List<Messages> Messages { get; set; }

        public bool Status { get; set; }


        public ServiceResponse(bool status, List<Messages> message = null, MessageType messageType = DB.Entity.ServiceResp.MessageType.Success)
        {
            MessageType = messageType.ToString();
            Messages = message;
            Status = status;
        }

    }
    public class ServiceResponse<T> : ServiceResponse
    {
        private T ResposeData { get; set; }
        public new T Data
        {
            get => this.ResposeData;
            set => base.Data = this.ResposeData = value;
        }


        public ServiceResponse(bool status, List<Messages> message = null, MessageType messageType = DB.Entity.ServiceResp.MessageType.Success)
            : base(status, message, messageType)
        {
        }
    }

}
