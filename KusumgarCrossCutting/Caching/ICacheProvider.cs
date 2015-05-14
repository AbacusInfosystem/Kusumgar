using System;
using System.Collections.Generic;

namespace KusumgarCrossCutting.Caching
{
    public interface ICacheProvider
    {
        void Add(string key, object value);
        void Add(string key, object value, TimeSpan timeout);
        void Add(string key, object value, TimeSpan timeout, string region);

        IEnumerable<KeyValuePair<string, object>> BulkGet(IEnumerable<string> keys, string region);

        
        void CreateRegion(string region);
        void ClearRegion(string region);

        object Get(string key);
        object Get(string key, string region);
        IEnumerable<KeyValuePair<string, object>> GetObjectsInRegion(string region);
        IEnumerable<string> GetSystemRegions();
        string GetSystemRegionName(string key);

        bool Remove(string key);
        bool Remove(string key, string region);
        void RemoveRegion(string region);

        object this[string key] { get; set; }
        object this[string key,string region] { get; set; }

        bool RegionExists(string key, string region);
    }
}
