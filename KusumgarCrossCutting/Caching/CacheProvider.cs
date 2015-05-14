using System;
using System.Configuration;
using System.Collections.Generic;
using Microsoft.ApplicationServer.Caching;

namespace KusumgarCrossCutting.Caching
{
    public class CacheProvider : ICacheProvider
    {
        private static DataCacheFactory _factory;
        private static DataCache _cache;

        // It creates a DataCache object which is mapped to AppFabricServer.
        private static DataCache GetCache()
        {
            if (_cache != null) return _cache;

            var configuration = new DataCacheFactoryConfiguration();
            _factory = new DataCacheFactory(configuration);
            _cache = _factory.GetCache(Convert.ToString(ConfigurationManager.AppSettings["CacheName"]));
            return _cache;
        }

        // Adds cache item having <key>,<value> to DataCache object.
        public void Add(string key, object value)
        {
            GetCache();
            if (Get(key) == null)
            {
                _cache.Add(key, value);
            }
        }

        // Adds cache item having <key>,<value>,<timeout> to DataCache object. 
        // This cache would get expired after timeout value elapses.
        public void Add(string key, object value, TimeSpan timeout)
        {
            GetCache();
            if (Get(key) == null)
            {
                _cache.Add(key, value, timeout);
            }
        }

        // Adds cache item having <key>, <value>, <timeout>, <region> to DataCache object. 
        // This cache would get expired after timeout value elapses.
        public void Add(string key, object value, TimeSpan timeout, string region)
        {
            GetCache();
            if (Cache.RegionExists(Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[1], Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[0]))
            {
                if (Get(key, region) == null)
                {
                    _cache.Add(key, value, timeout, region);
                }
            }
            else
            {
                CreateRegion(region);
                _cache.Add(key, value, timeout, region);
            }
        }

        // Returns all objects specified by <key> in the respective <region>.
        public IEnumerable<KeyValuePair<string, object>> BulkGet(IEnumerable<string> key, string region)
        {
            //var cache = GetCache();
            GetCache();
            if (Cache.RegionExists(Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[1], Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[0]))
                return _cache.BulkGet(key, region);
            else
                return null;
        }

        // Creates specified region in DataCache object. 
        // We should not be creating region by code as we dont have api to check whether a region already exist in CacheHost. 
        // In such case, if a region already exist and we try to create a same region the previously create region gets overlapped. 
        // So DO NOT USE this method.
        public void CreateRegion(string region)
        {
            GetCache();
            if (!Cache.RegionExists(Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[1], Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[0]))
            {
                // While creating a Region we should check whether it already exist. As done above.
                // If it doesnt exist then create the Region and set one default cache item, 
                // which we would use for checking if the region already exist.
                _cache.CreateRegion(Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[0]);

                // This cacheItem would be active in region till 1 year.
                _cache.Add(Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[1], "DefaultValue", new TimeSpan(365, 24, 60, 60, 0), Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[0]);
            }
        }

        // This deletes all object from the specified region.
        public void ClearRegion(string region)
        {
            GetCache();
            if (RegionExists(Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[1], Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[0]))
            {
                _cache.ClearRegion(region); // By this command DefaultCacheItem would also get cleared. Hence we are inserting it again as shown below.
                
                // This cacheItem would be active in region till 1 year.
                _cache.Add(Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[1], "DefaultValue", new TimeSpan(365, 24, 60, 60, 0), Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[0]);
            }
        }

        // Gets an object from cache using specified <key>.
        public object Get(string key)
        {
            GetCache();
            return _cache.Get(key);
        }

        // Gets an object from cache using specified <key> and <region>.
        public object Get(string key, string region)
        {
            GetCache();
            if (RegionExists(Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[1], Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[0]))
                return _cache.Get(key, region);
            else
                return null;
        }

        // It returns collection of objects from respective <region>.
        public IEnumerable<KeyValuePair<string, object>> GetObjectsInRegion(string region)
        {
            //var cache = GetCache();
            GetCache();
            if (RegionExists(Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[1], Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[0]))
                return _cache.GetObjectsInRegion(region);
            else
                return null;
        }

        // Returns all default regions existing in DataCache object. 
        // We would NOT BE USING this method as we are not creating default regions.
        public IEnumerable<string> GetSystemRegions()
        {
            GetCache();
            return _cache.GetSystemRegions();
        }

        // Returns region name in which parameter <key> resides.
        public string GetSystemRegionName(string key)
        {
            GetCache();
            return _cache.GetSystemRegionName(key);
        }

        // Removes cacheitem from DataCache object.
        public bool Remove(string key)
        {
            GetCache();
            if (Get(key) != null)
                return _cache.Remove(key);
            else
                return false;
        }

        // Remove cacheitem from a respective region from DataCache object.
        public bool Remove(string key, string region)
        {
            GetCache();
            if (RegionExists(Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[1], Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[0]))
            {
                if (Get(key, region) != null)
                    return _cache.Remove(key, region);
                else
                    return false;
            }
            else
            {
                return false;
            }
        }

        // Deletes specified region and all cached objects inside the region of respective DataCache object.
        public void RemoveRegion(string region)
        {
            GetCache();
            if (RegionExists(Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[1], Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[0]))
                _cache.RemoveRegion(region);
        }

        // It gets and sets values in cache object for respective <key>
        public object this[string key]
        {
            get { return this.Get(key); }
            set
            {
                GetCache();
                _cache.Put(key, value);
            }
        }

        // It gets and sets values in cache object for respective <key> and <region>
        public object this[string key, string region]
        {
            get { return this.Get(key, region); }
            set
            {
                GetCache();
                if (RegionExists(Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[1], Convert.ToString(ConfigurationManager.AppSettings[region]).Split('_')[0]))
                {
                    _cache.Put(key, value, region);
                }
                else
                {
                    CreateRegion(region);
                    _cache.Put(key, value, region);
                }
            }
        }

        public bool RegionExists(string key, string region)
        {
            GetCache();
            bool retVal = false;
            object cacheObj = _cache.Get(key, region);
            if (cacheObj != null)
                retVal = true;

            return retVal;
        }
    }
}
