namespace NetAOP.WebApi.Services
{
    public interface IHelloService
    {
        public string Hi();
        public Task<string> HiAsync();
    }
}
