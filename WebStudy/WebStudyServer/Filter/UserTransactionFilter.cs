using Microsoft.AspNetCore.Mvc.Filters;
using WebStudyServer.Repo;

namespace WebStudyServer.Filter
{
    public class UserTransactionFilter : ActionFilterAttribute
    {
        public UserTransactionFilter(RpcContext rpcContext, UserRepo userRepo, UserLockService userLockService, ILogger<UserTransactionFilter> logger)
        {
            _rpcContext = rpcContext;
            _userRepo = userRepo;
            _userLockService = userLockService;
            _logger = logger;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _userRepo.Init(_rpcContext.ShardId);

            ActionExecutedContext executedContext = null;
            await _userLockService.RunAtomicAsync(_rpcContext.AccountId, async () =>
            {
                executedContext = await next(); // 실제 API Action
            });

            // API 실행 이후 
            if (executedContext == null || executedContext.Exception != null)
            {
                // 롤백
                _userRepo.Rollback();
                return;
            }

            // 저장
            _userRepo.Commit();
        }

        private readonly RpcContext _rpcContext;
        private readonly UserRepo _userRepo;
        private readonly UserLockService _userLockService;
        private readonly ILogger _logger;
    }
}
