using Microsoft.Extensions.Caching.Memory;

namespace AuthService.Infrastructure.Caching;

/// <summary>
/// Service for caching operations
/// </summary>
public class CacheService
{
    private readonly IMemoryCache _cache;

    /// <summary>
    /// Initializes a new instance of the <see cref="CacheService"/> class
    /// </summary>
    public CacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    /// <summary>
    /// Gets a value from cache
    /// </summary>
    public T? Get<T>(string key)
    {
        return _cache.TryGetValue(key, out T? value) ? value : default;
    }

    /// <summary>
    /// Sets a value in cache
    /// </summary>
    public void Set<T>(string key, T value, TimeSpan? expiration = null)
    {
        var options = new MemoryCacheEntryOptions();

        if (expiration.HasValue)
        {
            options.AbsoluteExpirationRelativeToNow = expiration;
        }

        _cache.Set(key, value, options);
    }

    /// <summary>
    /// Removes a value from cache
    /// </summary>
    public void Remove(string key)
    {
        _cache.Remove(key);
    }
}
