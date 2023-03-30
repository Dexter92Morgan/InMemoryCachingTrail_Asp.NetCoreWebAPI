using Microsoft.Extensions.DependencyInjection;

namespace InMemoryCaching.IOC
{
    public static class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            Is4Ioc.RegisterService(services);
        }
    }
}
