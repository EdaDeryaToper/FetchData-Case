using System.Net;

namespace BackendCase.ExceptionHandler
{
    public static class ExceptionMiddleware 
    {
        public static string HandleError(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.TooManyRequests:
                    return ExceptionMessages.TooManyRequests;              
                case HttpStatusCode.NotFound:
                    return ExceptionMessages.NotFound;
                case HttpStatusCode.BadRequest:
                    return ExceptionMessages.BadRequests;
                default:
                    return ExceptionMessages.InternalServerError;
            }
        }
    }
}
