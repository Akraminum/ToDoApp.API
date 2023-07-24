using System.Net;
using System.Runtime.Serialization;

namespace ToDoAppAPI.Utitlities.Responses;

public class CommonApiResponse
{
    public static CommonApiResponse Create(HttpStatusCode statusCode, object result = null)
        {
            return new CommonApiResponse(statusCode, result);
        }

        public string RequestId { get; }
        public int StatusCode { get; set; }
        public bool IsSuccessful => StatusCode >= 200 && StatusCode <= 299;

        [DataMember(EmitDefaultValue = false)]
        public object Result { get; set; }

        protected CommonApiResponse(HttpStatusCode statusCode, object result = null)
        {
            RequestId = Guid.NewGuid().ToString();
            StatusCode = (int)statusCode;
            Result = result;
        }

}
