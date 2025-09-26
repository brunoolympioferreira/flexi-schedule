namespace FlexiSchedule.Application.Services.Cache;
public class CacheService(IDistributedCache cache) : ICacheService
{
    public async Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) where T : class
    {
        var cachedData = await cache.GetStringAsync(key, cancellationToken);
        if (string.IsNullOrEmpty(cachedData))
        {
            return null;
        }

        return JsonSerializer.Deserialize<T>(cachedData);
    }

    public Task SetAsync<T>(string key, T value, TimeSpan expiration, CancellationToken cancellationToken = default) where T : class
    {
        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = expiration
        };

        var serializedData = JsonSerializer.Serialize(value);
        return cache.SetStringAsync(key, serializedData, options, cancellationToken);
    }
}
