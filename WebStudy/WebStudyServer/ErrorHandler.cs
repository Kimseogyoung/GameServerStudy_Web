using Microsoft.AspNetCore.Diagnostics;
using WebStudyServer.Service.Singleton;

namespace WebStudyServer
{
    public class ErrorHandler : IExceptionHandler
    {
        public ErrorHandler(ILogger<ErrorHandler> logger) 
        {
            _logger = logger;
        }

        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {

            // TODO: Exception별로 핸들링

            // TODO: 로그

            // TODO: 에러 리포트

            return ValueTask.FromResult(true);
        }

        private readonly ILogger _logger;
    }
}
