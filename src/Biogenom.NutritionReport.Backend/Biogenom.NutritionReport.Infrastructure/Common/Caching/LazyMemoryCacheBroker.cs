using Force.DeepCloner;
using LazyCache;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Biogenom.NutritionReport.Application.Common.Settings;
using Biogenom.NutritionReport.Persistence.Caching.Brokers;
using Biogenom.NutritionReport.Persistence.Caching.Models;

namespace Biogenom.NutritionReport.Infrastructure.Common.Caching;

public class LazyMemoryCacheBroker(
    IOptions<CacheSettings> cacheSettings,
    IAppCache appCache) :
    ICacheBroker
{
    private readonly MemoryCacheEntryOptions _memoryCacheEntryOptions = new()
    {
        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(cacheSettings.Value.AbsoluteExpirationInSeconds),

        SlidingExpiration = TimeSpan.FromSeconds(cacheSettings.Value.SlidingExpirationInSeconds)
    };

    public ValueTask<T?> GetAsync<T>(
        string key,
        CancellationToken cancellationToken = default)
    {
        var value = appCache.Get<T?>(key);

        return ValueTask.FromResult(value);
    }

    public ValueTask<bool> TryGetAsync<T>(
        string key,
        out T? value,
        CancellationToken cancellationToken = default)
    {
        value = appCache.Get<T?>(key);

        return value is not null ? ValueTask.FromResult(true) : ValueTask.FromResult(false);
    }

    public async ValueTask<T?> GetOrSetAsync<T>(
        string key,
        T value,
        CacheEntryOptions? entryOptions = null,
        CancellationToken cancellationToken = default)
    {
        var cachedValue = appCache.Get<T?>(key);

        if (cachedValue is not null)
            return cachedValue;

        await SetAsync(key, value, entryOptions, cancellationToken);

        return value;
    }

    public async ValueTask<T?> GetOrSetAsync<T>(
        string key, Func<T> valueProvider,
        CacheEntryOptions? entryOptions = null,
        CancellationToken cancellationToken = default)
    {
        var cachedValue = appCache.Get<T?>(key);

        if (cachedValue is not null)
            return cachedValue;

        var value = valueProvider();
        await SetAsync(key, () => value, entryOptions, cancellationToken);

        return value;
    }

    public async ValueTask<T?> GetOrSetAsync<T>(
        string key, Func<ValueTask<T>> valueProvider,
        CacheEntryOptions? entryOptions = null,
        CancellationToken cancellationToken = default)
    {
        var cachedValue = appCache.Get<T?>(key);

        if (cachedValue is not null)
            return cachedValue;

        var value = await valueProvider();
        await SetAsync(key, () => value, entryOptions, cancellationToken);

        return value;
    }

    public ValueTask SetAsync<T>(
        string key, T value,
        CacheEntryOptions? entryOptions = null,
        CancellationToken cancellationToken = default)
    {
        appCache.Add(key, value, GetCacheEntryOptions(entryOptions));
        return ValueTask.CompletedTask;
    }

    public ValueTask SetAsync<T>(
        string key, Func<T> valueProvider,
        CacheEntryOptions? entryOptions = null,
        CancellationToken cancellationToken = default)
    {
        appCache.Add(key, valueProvider(), GetCacheEntryOptions(entryOptions));
        return ValueTask.CompletedTask;
    }

    public async ValueTask SetAsync<T>(
        string key,
        Func<ValueTask<T>> valueProvider,
        CacheEntryOptions? entryOptions = null,
        CancellationToken cancellationToken = default)
    {
        appCache.Add(key, await valueProvider(), GetCacheEntryOptions(entryOptions));
    }

    public ValueTask DeleteAsync(
        string key,
        CancellationToken cancellationToken = default)
    {
        appCache.Remove(key);
        return ValueTask.CompletedTask;
    }

    private MemoryCacheEntryOptions GetCacheEntryOptions(CacheEntryOptions? cacheEntryOptions)
    {
        if (!cacheEntryOptions.HasValue ||
            (!cacheEntryOptions.Value.AbsoluteExpirationRelativeToNow.HasValue || !cacheEntryOptions.Value.SlidingExpiration.HasValue))
            return _memoryCacheEntryOptions;

        var currentEntryOptions = _memoryCacheEntryOptions.DeepClone();

        currentEntryOptions.AbsoluteExpirationRelativeToNow = cacheEntryOptions.Value.AbsoluteExpirationRelativeToNow;
        currentEntryOptions.SlidingExpiration = cacheEntryOptions.Value.SlidingExpiration;

        return currentEntryOptions;
    }
}