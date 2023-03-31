using InMemoryCache.Services.Cache.CacheInterface;
using InMemoryCaching.Domain.DTOs;
using InMemoryCaching.Domain.Interfaces.BussinessInterfaces;
using InMemoryCaching.Domain.Models;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCache.Services.Cache.CacheService
{
    public class CacheProvider : ICacheProvider
    {
        private static readonly SemaphoreSlim GetUsersSemaphore = new SemaphoreSlim(1, 1);
        private readonly IMemoryCache _cache;
        private readonly IEmployeeService _employeeService;
        public CacheProvider(IMemoryCache memoryCache, IEmployeeService employeeService)
        {
            _cache = memoryCache;
            _employeeService = employeeService;
        }
        public async Task<IEnumerable<EmployeeGetDto>> GetCachedResponse()
        {
            return await GetCachedResponse(CacheKeys.Employees, GetUsersSemaphore);

        }
        private async Task<IEnumerable<EmployeeGetDto>> GetCachedResponse(string cacheKey, SemaphoreSlim semaphore)
        {
            bool isAvaiable = _cache.TryGetValue(cacheKey, out List<EmployeeGetDto>? employees);
            if (isAvaiable) return employees;
            try
            {
                await semaphore.WaitAsync();
                isAvaiable = _cache.TryGetValue(cacheKey, out employees);
                if (isAvaiable) return employees;
                employees = _employeeService.GetAllEmployeeAsync().Result.ToList();
                var cacheEntryOptions = new MemoryCacheEntryOptions
                {
                    AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                    SlidingExpiration = TimeSpan.FromMinutes(2),
                    Size = 1024,
                };
                _cache.Set(cacheKey, employees, cacheEntryOptions);
            }
            finally
            {
                semaphore.Release();
            }
            return employees;
        }
    }
}
