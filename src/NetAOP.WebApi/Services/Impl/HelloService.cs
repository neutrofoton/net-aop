namespace NetAOP.WebApi.Services.Impl
{
    public class HelloService : IHelloService
    {
        private ILogger logger;
        public HelloService(ILogger<HelloService> logger)
        {
            this.logger = logger;
        }
        public string Hi()
        {
            logger.LogDebug("[HelloService] -> Calling Hi");
            return "Hello AOP";
        }

        public Task<string> HiAsync()
        {
            logger.LogDebug("[HelloService] -> Calling HiAsync");
            return Task.Run<string>(() => "Hello AOP Async");
        }
    }
}
