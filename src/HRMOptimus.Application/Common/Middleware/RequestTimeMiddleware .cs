using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace HRMOptimus.Application.Common.Middleware
{
    public class RequestTimeMiddleware : IMiddleware
    {
        private readonly ILogger<RequestTimeMiddleware> _loger;
        private Stopwatch _stoper;

        public RequestTimeMiddleware(ILogger<RequestTimeMiddleware> loger)
        {
            _loger = loger;
            _stoper = new Stopwatch();
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            _stoper.Start();
            await next.Invoke(context);
            _stoper.Stop();

            if (_stoper.ElapsedMilliseconds > 4000)
                _loger.LogWarning($"The request: {context.Request.Method} at {context.Request.Path} took {_stoper.ElapsedMilliseconds / 1000} s");
        }
    }
}