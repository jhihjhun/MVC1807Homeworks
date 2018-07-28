using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp1.Helpers.ActionFilters
{
    public class ActionTimeLogFilter : ActionFilterAttribute
    {
        private Stopwatch _stopWatch;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.ActionName;
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

            _stopWatch = new Stopwatch();
            _stopWatch.Start();
            Debug.WriteLine($"Controller = {controllerName},  Action = {actionName}");
            Debug.WriteLine($"OnActionExecuting : {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}");
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            _stopWatch.Stop();
            Debug.WriteLine($"OnResultExecuting : {DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}");
            Debug.WriteLine($"Elapsed = {_stopWatch.Elapsed}");
        }
    }
}