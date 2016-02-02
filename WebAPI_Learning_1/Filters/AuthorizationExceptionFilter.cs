using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;
using WebAPI_Learning_1.Exceptions;

namespace WebAPI_Learning_1.Filters
{
    public class AuthorizationExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is AuthorizationException)
            {
                actionExecutedContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    Content = new StringContent("You do not have permission...")
                };
            }
        }
    }
}