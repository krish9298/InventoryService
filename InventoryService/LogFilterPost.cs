using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService
{
    public class LogFilterPost:ActionFilterAttribute
    {
        Guid g = Guid.NewGuid();
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LogRequest("OnActionExecuted", filterContext.RouteData);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            LogResponse("OnResultExecuted", filterContext.RouteData);
        }

      

        private void LogRequest(string methodName, RouteData routeData)
        {


            string message = "BatchID: " + g + Environment.NewLine;


            string path = @"C:\Demologs\" + "Post_" + g + "_Request.txt";


            File.AppendAllText(path, message);
        }
        private void LogResponse(string methodName, RouteData routeData)
        {

            string message = "BatchID: " + g + Environment.NewLine;

            string path = @"C:\Demologs\" + "Post_" + g + "_Response.txt";
            File.AppendAllText(path, message);
        }
    }
}

