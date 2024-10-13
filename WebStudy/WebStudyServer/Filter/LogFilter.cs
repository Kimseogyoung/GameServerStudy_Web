using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using WebStudyServer.Extension;

namespace WebStudyServer.Filter
{
    public class LogFilter : ActionFilterAttribute
    {
        public LogFilter(ILogger<LogFilter> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var httpReq = context.HttpContext.Request;
            var args = new Dictionary<string, object>()
            {
                { "Method", httpReq.Method },
                { "Path", httpReq.Path.ToString() },
                { "Body", context.ActionArguments },
            };

            _logger.Info("Req Method({Method}) Path({Path})", args);
        }

        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var httpReq = context.HttpContext.Request;
            var httpRes = context.HttpContext.Response;

            object resBody = null;
            if (context.Result is ObjectResult result)
            {
                resBody = result.Value;
            }

            var args = new Dictionary<string, object>()
            {
                { "Method", httpReq.Method },
                { "Path", httpReq.Path.ToString() },
                { "Code", httpRes.StatusCode },
                { "Body", resBody },
            };

            _logger.Info("Res Method({Method}) Path({Path}) Code({Code})", args);
        }

        private readonly ILogger _logger;
    }
}
