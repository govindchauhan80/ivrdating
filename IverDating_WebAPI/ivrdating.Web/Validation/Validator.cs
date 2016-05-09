using ivrdating.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ivrdating.Web.Validation
{
    public class Validator : ActionFilterAttribute, IActionFilter
    {
        void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Log("OnActionExecuting", filterContext.RouteData);
            WebServiceController.validationError = "Test Error";
        }

        void IActionFilter.OnActionExecuted(ActionExecutedContext filterContext)
        {
            //Log("OnActionExecuted", filterContext.RouteData);
        }

        //void IActionFilter. (ResultExecutingContext filterContext)
        //{
        //    //Log("OnResultExecuting", filterContext.RouteData);
        //}

        //public override void OnResultExecuted(ResultExecutedContext filterContext)
        //{
        //    //Log("OnResultExecuted", filterContext.RouteData);
        //}

        //public void OnException(ExceptionContext filterContext)
        //{

        //}
    }
}