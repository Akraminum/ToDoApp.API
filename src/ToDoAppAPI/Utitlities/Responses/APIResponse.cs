using System.Net;
using System.Runtime.Serialization;

namespace ToDoAppAPI.Utitlities.Responses
{
    [DataContract]
    public class APIResponse
    {
        [DataMember]
        public int StatusCode { get; set; }
        public string Message { get; set; } = string.Empty;

        [DataMember(EmitDefaultValue = false)]
        public List<string>? ErrorMessages { get; set; }

        [DataMember(EmitDefaultValue = false)]
        public object? Result { get; set; }

        public APIResponse(
            HttpStatusCode statusCode, 
            object? result = null, 
            List<string>? errorMessages = null)
        {
            StatusCode = (int)statusCode;
            Result = result;
            ErrorMessages = errorMessages;
        }

    }
}
