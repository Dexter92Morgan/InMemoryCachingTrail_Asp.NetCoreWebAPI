using InMemoryCaching.Domain.DTOs;
using InMemoryCaching.Domain.Models;

namespace InMemoryCache.Services.Cache.CacheInterface
{
    public interface ICacheProvider
    {
        Task<IEnumerable<EmployeeGetDto>> GetCachedResponse();
    }
}
