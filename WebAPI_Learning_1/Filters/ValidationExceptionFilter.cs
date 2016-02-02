using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http.Filters;
using FluentValidation;
using Newtonsoft.Json;
using WebAPI_Learning_1.Responses;

namespace WebAPI_Learning_1.Filters
{
    public class ValidationExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is ValidationException)
            {
                actionExecutedContext.Response = new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Content = new StringContent(
                        JsonConvert.SerializeObject(
                            ((ValidationException) actionExecutedContext.Exception).Errors.Select(e => new ApiError(e))),
                        Encoding.UTF8,
                        "application/json"
                        )
                };
            }
        }
    }
}