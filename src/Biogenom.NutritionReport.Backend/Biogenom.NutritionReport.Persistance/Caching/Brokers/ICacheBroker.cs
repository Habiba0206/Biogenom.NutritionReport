using Biogenom.NutritionReport.Persistence.Caching.Models;

namespace Biogenom.NutritionReport.Persistence.Caching.Brokers;

/// <summary>
/// Defines cache broker functionality.
/// </summary>
public interface ICacheBroker
{
    /// <summary>
    /// Gets the cache entry value with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of the cache entry.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Found instance of <see cref="T"/> if found, otherwise default value.</returns>
    ValueTask<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default);

    /// <summary>
    /// Attempts to get the cache entry with the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of the cache entry.</param>
    /// <param name="value">Cached entry value if found, otherwise default value</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>True if the cached entry was found and retrieved successfully; otherwise, false.</returns>
    ValueTask<bool> TryGetAsync<T>(string key, out T? value, CancellationToken cancellationToken = default);

    /// <summary>
    /// Attempts to get the cache entry with the specified key. If not found, sets the cache entry with the specified key and value.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of the cache entry.</param>
    /// <param name="value">Value to create cache entry for</param>
    /// <param name="entryOptions">A cache entry options to specify caching options</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Found instance of <see cref="T"/> if found, otherwise default value.</returns>
    ValueTask<T?> GetOrSetAsync<T>(
        string key,
        T value,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Attempts to get the cache entry with the specified key. If not found, sets the cache entry with the specified key and value.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of the cache entry.</param>
    /// <param name="valueProvider">A broker that provides the entry to set</param>
    /// <param name="entryOptions">A cache entry options to specify caching options</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Found instance of <see cref="T"/> if found, otherwise default value.</returns>
    ValueTask<T?> GetOrSetAsync<T>(
        string key,
        Func<T> valueProvider,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Attempts to get the cache entry with the specified key. If not found, sets the cache entry with the specified key and value.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of the cache entry.</param>
    /// <param name="valueProvider">A broker that provides the entry to set</param>
    /// <param name="entryOptions">A cache entry options to specify caching options</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Found instance of <see cref="T"/> if found, otherwise default value.</returns>
    ValueTask<T?> GetOrSetAsync<T>(
        string key,
        Func<ValueTask<T>> valueProvider,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sets the cache entry with the specified key and value.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of the cache entry.</param>
    /// <param name="value">Value to create cache entry for</param>
    /// <param name="entryOptions">A cache entry options to specify caching options</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Found instance of <see cref="T"/> if found, otherwise default value.</returns>
    ValueTask SetAsync<T>(
        string key,
        T value,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sets the cache entry with the specified key and value.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of the cache entry.</param>
    /// <param name="valueProvider">A broker that provides the entry to set</param>
    /// <param name="entryOptions">A cache entry options to specify caching options</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Found instance of <see cref="T"/> if found, otherwise default value.</returns>
    ValueTask SetAsync<T>(
        string key,
        Func<T> valueProvider,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sets the cache entry with the specified key and value.
    /// </summary>
    /// <typeparam name="T">The type of the cache entry value.</typeparam>
    /// <param name="key">The key of the cache entry.</param>
    /// <param name="valueProvider">A broker that provides the entry to set</param>
    /// <param name="entryOptions">A cache entry options to specify caching options</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>Found instance of <see cref="T"/> if found, otherwise default value.</returns>
    ValueTask SetAsync<T>(
        string key,
        Func<ValueTask<T>> valueProvider,
        CacheEntryOptions? entryOptions = default,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes the cache entry with the specified key.
    /// </summary>
    /// <param name="key">The key of the cache entry.</param>
    /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    ValueTask DeleteAsync(string key, CancellationToken cancellationToken = default);
}