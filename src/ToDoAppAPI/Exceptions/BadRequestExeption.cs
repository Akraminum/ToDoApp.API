using ConsistentApiResponseErrors.Exceptions;
namespace ToDoAppAPI.Exceptions;

public class BadRequestExeption : ApiBaseException
    {
        private const int _httpStatusCode = 400;
        private const string _httpStatusMessage = "Bad Request";
        private const string _DefaultErrorMessage = "Invalid Request";

        public BadRequestExeption() :
            base(_httpStatusCode, _httpStatusMessage, _DefaultErrorMessage)
        {
        }

        public BadRequestExeption(string message)
           : base(_httpStatusCode, _httpStatusMessage, message)
        {
        }

        public BadRequestExeption(string message, Exception innerException)
            : base(_httpStatusCode, _httpStatusMessage, message, innerException)
        {
        }
    }