using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;
using ivrdating.Log;
using System.Web.Http.Controllers;
using System.Diagnostics;
using System.Net.Http;
using ivrdating.Logic.Helpers;


namespace ivrdating.Web.Filter
{
    public class LogActionFilter: ActionFilterAttribute
    {
     
        LogRequestResponse _logRequestResponse;
        public LogActionFilter()
        {
            _logRequestResponse = new LogRequestResponse();
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            _logRequestResponse.LogData(string.Format("\r\n Executing controller {0}, action {1}\r\n{2}\r\n",
                    actionContext.ActionDescriptor.ControllerDescriptor.ControllerName,
                    actionContext.ActionDescriptor.ActionName, ExtensionMethods.SerializeToJson(actionContext.ActionArguments)),"Info");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            var objectContent = actionExecutedContext.Response.Content as ObjectContent;
            if (objectContent != null)
            {
                _logRequestResponse.LogData(string.Format("\r\n Executed controller {0}, action {1}\r\n{2}\r\n",
                   actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName,
                   actionExecutedContext.ActionContext.ActionDescriptor.ActionName,
                   ExtensionMethods.SerializeToJson(objectContent.Value)),"Info");
                //var type = objectContent.ObjectType; //type of the returned object
                //var value = objectContent.Value; //holding the returned value
            }
            //((System.Net.Http.ObjectContent)actionExecutedContext.ActionContext.Response.Content).Value


          
        }

      
    }
}