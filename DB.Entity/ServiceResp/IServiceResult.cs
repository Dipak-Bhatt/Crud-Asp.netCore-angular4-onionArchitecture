using System.Collections.Generic;

namespace DB.Entity.ServiceResp
{

    public interface IServiceResult
    {
        object Data { get; set; }
        bool Status { get; set; }
        List<Messages> Messages { get; set; }
        string MessageType { get; set; }
    }
    public class Messages
    {
        public string Description { get; set; }
        public string Code { get; set; }

    }
}
