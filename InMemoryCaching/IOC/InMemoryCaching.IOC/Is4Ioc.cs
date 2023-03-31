using InMemoryCache.Services.Cache.CacheInterface;
using InMemoryCache.Services.Cache.CacheService;
using InMemoryCaching.Domain.Interfaces.BussinessInterfaces;
using InMemoryCaching.Domain.Interfaces.RepositoryInterfaces;
using InMemoryCaching.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InMemoryCaching.IOC
{
    public static class Is4Ioc
    {
        public static void RegisterService(IServiceCollection services)
        {
            services.AddTransient<IEmployeeService, EmployeeServices>();
            services.AddTransient<IEmployeeRepository, Repositories.Repositories.EmployeeRepository>();
            services.AddTransient<ICacheProvider, CacheProvider>();
        }
    }
}
