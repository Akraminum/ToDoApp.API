using ConsistentApiResponseErrors.Exceptions;

namespace ToDoAppAPI.Exceptions;

public class EntityExistsException : ApiBaseException
    {
        private const int _httpStatusCode = 409;
        private const string _httpStatusMessage = "Conflict";
        private const string _DefaultErrorMessage = "Entity already exists";

        public EntityExistsException() :
            base(_httpStatusCode, _httpStatusMessage, _DefaultErrorMessage)
        {
        }

        public EntityExistsException(string message)
           : base(_httpStatusCode, _httpStatusMessage, message)
        {
        }

        public EntityExistsException(string message, Exception innerException)
            : base(_httpStatusCode, _httpStatusMessage, message, innerException)
        {
        }
    }

