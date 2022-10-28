namespace NetAOP.WebApi.Services.Impl
{
    public class HelloService : IHelloService
    {
        public string Hi()
        {
            return "Hello AOP";
        }

        public Task<string> HiAsync()
        {
            return Task.Run<string>(() => "Hello AOP Async");
        }
    }
}
