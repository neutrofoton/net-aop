using Castle.DynamicProxy;

namespace NetAOP.WebApi.Interceptors
{
    public class ConsoleBInterceptor : IInterceptor
    {
        private ILogger logger;
        public ConsoleBInterceptor(ILogger logger)
        {
            this.logger = logger;
        }
        public void Intercept(IInvocation invocation)
        {
            logger.LogDebug($"[ConsoleBInterceptor] -> Before Calling method: {invocation.Method.ReturnType} - {invocation.TargetType}.{invocation.Method.Name}");
            invocation.Proceed();
            logger.LogDebug($"[ConsoleBInterceptor] -> After Calling method: {invocation.Method.ReturnType} - {invocation.TargetType}.{invocation.Method.Name}");
 
        }
    }
}
