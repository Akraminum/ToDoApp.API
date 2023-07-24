namespace ToDoAppAPI.Utitlities.Responses;

public static class ResponseWrapperExtensions
    {
        public static IApplicationBuilder UseResponseWrapper(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseWrapperMiddlwware>();
        }
    }

