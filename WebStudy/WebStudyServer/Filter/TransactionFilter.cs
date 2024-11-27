﻿using Microsoft.AspNetCore.Mvc.Filters;
using WebStudyServer.Repo;

namespace WebStudyServer.Filter
{
    public class AuthTransactionFilter : ActionFilterAttribute
    {
        public AuthTransactionFilter(RpcContext rpcContext, AuthRepo authRepo, ILogger<AuthTransactionFilter> logger)
        {
            _rpcContext = rpcContext;
            _authRepo = authRepo;
            _logger = logger;
        }

        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _authRepo.Init(_rpcContext.ShardId);

            // TODO: UserLock
            //


            var executedContext = await next(); // 실제 API Action

            // API 실행 이후 
            if (executedContext.Exception != null)
            {
                // 롤백
                _authRepo.Rollback();
                return;
            }

            // 저장
            _authRepo.Commit();
        }

        private readonly RpcContext _rpcContext;
        private readonly AuthRepo _authRepo;
        private readonly ILogger _logger;
    }
}