using System;
using System.Collections.Generic;

namespace KusumgarCrossCutting.Caching
{
    public static class Cache
    {
        private static readonly ICacheProvider CacheProvider;

        static Cache()
        {
            //CacheProvider =
            //    (ICacheProvider) ServiceLocator.Current
            //                         .GetInstance(typeof (ICacheProvider));

            CacheProvider = new CacheProvider();
        }

        public static void Add(string key, object value)
        {
            CacheProvider.Add(key, value);
        }

        public static void Add(string key, object value, TimeSpan timeout)
        {
            CacheProvider.Add(key, value, timeout);
        }

        public static void Add(string key, object value, TimeSpan timeout, string region)
        {
            CacheProvider.Add(key, value, timeout, region);
        }

        public static IEnumerable<KeyValuePair<string,object>> BulkGet(IEnumerable<string> key, string region)
        {
            return CacheProvider.BulkGet(key,region);
        }

        public static void CreateRegion(string region)
        {
            CacheProvider.CreateRegion(region);
        }

        public static void ClearRegion(string region)
        {
            CacheProvider.ClearRegion(region);
        }

        public static object Get(string key)
        {
            return CacheProvider[key];
        }

        public static object Get(string key, string region)
        {
            return CacheProvider[key,region];
        }

        public static IEnumerable<KeyValuePair<string, object>> GetObjectsInRegion(string region)
        {
            return CacheProvider.GetObjectsInRegion(region);
        }

        public static IEnumerable<string> GetSystemRegions()
        {
            return CacheProvider.GetSystemRegions();
        }

        public static string GetSystemRegionName(string key)
        {
            return CacheProvider.GetSystemRegionName(key);
        }

        public static bool Remove(string key)
        {
            return CacheProvider.Remove(key);
        }

        public static bool Remove(string key, string region)
        {
            return CacheProvider.Remove(key, region);
        }

        public static void RemoveRegion(string region)
        {
            CacheProvider.RemoveRegion(region);
        }

        public static bool RegionExists(string key, string region)
        {
            return CacheProvider.RegionExists(key, region);
        }
    }
}
