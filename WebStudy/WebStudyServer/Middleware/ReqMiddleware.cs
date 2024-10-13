namespace WebStudyServer.Middleware
{
    public class ReqMiddleware
    {
        public ReqMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpCtx)
        {
            try
            {
                CancelReqException.ThrowCancelRequestException(httpCtx);

                await _next(httpCtx);
                return;
            }
            catch (Exception ex)
            {
                //var errorHandler = httpCtx.RequestServices.GetRequiredService<ErrorHandler>();
                //await errorHandler.Handle(httpCtx, ex);
            }
            finally
            {

            }
        }

        private readonly RequestDelegate _next;

    }
}
