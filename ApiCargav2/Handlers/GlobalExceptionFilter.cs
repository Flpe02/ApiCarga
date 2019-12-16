using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace ApiCargav2.Handlers
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exception = actionExecutedContext.Exception;

            var logger =
                actionExecutedContext.ActionContext.ControllerContext.Configuration.DependencyResolver.GetService(
                    typeof(ILogger)) as ILogger;

            if (logger != null)
            {
                logger.Error(exception, exception.Message);
            }

            const string genericErrorMessage = "Ha ocurrido un error";

            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(genericErrorMessage)
            };

            response.Headers.Add("X-Error", genericErrorMessage);
        }
    }
}