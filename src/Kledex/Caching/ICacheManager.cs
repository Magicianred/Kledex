﻿using System;
using System.Threading.Tasks;

namespace Kledex.Caching
{
    public interface ICacheManager
    {
        Task<T> GetOrCreateAsync<T>(string key, Func<Task<T>> acquireAsync);
        Task<T> GetOrCreateAsync<T>(string key, int cacheTime, Func<Task<T>> acquireAsync);
        T GetOrCreate<T>(string key, Func<T> acquire);
        T GetOrCreate<T>(string key, int cacheTime, Func<T> acquire);
    }
}
