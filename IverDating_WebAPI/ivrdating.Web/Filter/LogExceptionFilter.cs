using ivrdating.Log;
using ivrdating.Logic.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace ivrdating.Web.Filter
{
    public class LogExceptionFilter: ExceptionFilterAttribute
    {
        LogRequestResponse _logRequestResponse;
        public LogExceptionFilter()
        {
            _logRequestResponse = new LogRequestResponse();
        }
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            _logRequestResponse.LogData(string.Format("\r\n On exception controller {0}, action {1}\r\n{2}\r\n",
                 actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName,
                 actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                 actionExecutedContext.Exception.StackTrace),"Error");
        }
    }
}