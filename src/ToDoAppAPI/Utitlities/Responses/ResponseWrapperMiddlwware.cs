using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Schema;

namespace ToDoAppAPI.Utitlities.Responses;

public class ResponseWrapperMiddlwware
{
    private readonly RequestDelegate _next;

        public ResponseWrapperMiddlwware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // get the current body of the response before we do anything. 
            var currentBody = context.Response.Body;

            // create a new memory stream... 
            // ... and set the current body to this new memory stream. 
            // ... this way we can read the response body from this memory stream. 
            // ... we will read the response body from memory stream only after we have written the response body to memory stream. 
            // ... so we can set the body back to the original body. 
            // ... otherwise we will get an error. 
            using (var memoryStream = new MemoryStream())
            {
                // set the current body to the memory stream.
                context.Response.Body = memoryStream;

                //invoke the next middleware
                await _next(context);


                //reset the body 
                //... we will read the response body from memory stream only after we have written the response body to memory stream.
                //... so we can set the body back to the original body.
                //... otherwise we will get an error.
                context.Response.Body = currentBody;
                //move the memory stream to the beginning position.
                // ... so we can read the content of the memory stream
                // ... and write it to the response body
                memoryStream.Seek(0, SeekOrigin.Begin);
                
                //read the content of the memory stream
                var readToEnd = new StreamReader(memoryStream).ReadToEnd();

                object? objResult = readToEnd;
                if ((readToEnd.StartsWith("{") && readToEnd.EndsWith("}")) || //For object
                        (readToEnd.StartsWith("[") && readToEnd.EndsWith("]"))) //For array
                {
                    //convert the content to json
                    objResult = JsonConvert.DeserializeObject(readToEnd);
                }
               
                //convert the json to common api response
                var result = CommonApiResponse.Create((HttpStatusCode)context.Response.StatusCode, objResult!);
                //write the content of the common api response to the response body
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
            }
        }

}
