using Microsoft.Extensions.Caching.Memory;

namespace AdvancedCachingExample.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;
        private readonly ILogger<CacheService> _logger;

        public CacheService(IMemoryCache memoryCache, ILogger<CacheService> logger)
        {
            _memoryCache = memoryCache;
            _logger = logger;
        }

        public T Get<T>(string key)
        {
            bool found = _memoryCache.TryGetValue(key, out T value);
            _logger.LogInformation($"Cache {(found ? "HIT" : "MISS")} for key: {key}");
            return value;
        }

        public void Set<T>(string key, T value, TimeSpan expiration)
        {
            _logger.LogInformation($"Caching data with key: {key}, Expiration: {expiration}");
            var cacheOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiration
            };

            _memoryCache.Set(key, value, cacheOptions);
        }

        public void Remove(string key)
        {
            _logger.LogInformation($"Removing cache key: {key}");
            _memoryCache.Remove(key);
        }
    }
}
