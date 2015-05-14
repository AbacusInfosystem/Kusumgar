using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using System.Configuration;
using KusumgarCrossCutting.Logging;
using KusumgarCrossCutting.Caching;
namespace Kusumgar.Controllers.PreLogin
{
    public class Demo1Controller : Controller
    {
        //
        // GET: /DefaultFunctionality/

        public ActionResult Log()
        {
            for (int i = 0; i < 10; i++)
            {
                Logger.Info(new DBLogInfo { IPAddress = "192.168.0.101", UserId = 1, Exception = "ERROR MESSAGE TEXT", CreatedOn = DateTime.Now });
                Logger.Debug("COUNTER: " + i.ToString() + ", " + DateTime.Now.ToShortDateString());
                //_logger.Info("COUNTER: " + i.ToString() + ", " + DateTime.Now.ToShortDateString());
                //_logger.Error("COUNTER: " + i.ToString() + ", " + DateTime.Now.ToShortDateString());
                //_logger.Fatal("COUNTER: " + i.ToString() + ", " + DateTime.Now.ToShortDateString());
                //_logger.Warn("COUNTER: " + i.ToString() + ", " + DateTime.Now.ToShortDateString());
            }
            return View("Index");
        }

        public ActionResult Using_CreateRegion()
        {
            Cache.CreateRegion("BMRegion1");
            return View("Index");
        }

        public ActionResult Using_Add()
        {
            string str = "StringValue";
            string strKeyName = "CacheKeyName1";

            //object cacheObj = Cache.Get(strKeyName);
            //if (cacheObj == null)
            //{
            try
            {
                Cache.Add(strKeyName, str);
            }
            catch (Exception ex)
            {
                Logger.Info("INNER EXCEPTION: " + ex.InnerException);
                Logger.Info("INNER MESSAGE: " + ex.Message);
            }
                
            //}
            return View("Index");
        }

        public ActionResult Using_Add_TimeStamp()
        {
            string str = "StringValue";
            string strKeyName = "CacheKeyName1";
            TimeSpan ts = new TimeSpan(0, 1, 0);

            //object cacheObj = Cache.Get(strKeyName);
            //if (cacheObj == null)
            //{
                Cache.Add(strKeyName, str, ts);
            //}
            return View("Index");
        }

        public ActionResult Using_Add_TimeStamp_Region()
        {
            string str = "StringValue";
            string strKeyName = "CacheKeyName1";
            TimeSpan ts = new TimeSpan(0, 1, 0);
            //object cacheObj = Cache.Get(strKeyName, "BMRegion1");
            //if (cacheObj == null)
            //{
                Cache.Add(strKeyName, str, ts, "BMRegion1");
            //}
            return View("Index");
        }

        public ActionResult Using_BulkGet()
        {
            string str = "StringValue";
            string strKeyName = "CacheKeyName1";
            TimeSpan ts = new TimeSpan(0, 1, 0);

            //1. Insert String.
            Cache.Add(strKeyName, str, ts, "BMRegion1");


            //2. Insert Integer.
            int i = 1;
            strKeyName = "CacheKeyName2";
            Cache.Add(strKeyName, i, ts, "BMRegion1");

            //3. Insert Boolean.
            bool flag = true;
            strKeyName = "CacheKeyName3";
            Cache.Add(strKeyName, flag, ts, "BMRegion1");

            //4. Insert Class Object.
            List<CollectionOfData> data = new List<CollectionOfData>{
                new CollectionOfData{Id = 1, Name = "Name1"},
                new CollectionOfData{Id = 2, Name = "Name2"}
            };

            strKeyName = "CacheKeyName4";
            Cache.Add(strKeyName, data, ts, "BMRegion1");

            // Read all selective cache from BulkGet method.
            IEnumerable<KeyValuePair<string, object>> collection = Cache.BulkGet(new[] { "CacheKeyName1", "CacheKeyName2", "CacheKeyName3", "CacheKeyName4" }, "BMRegion1");

            foreach (KeyValuePair<string, object> item in collection)
            {
                if (item.Key == "CacheKeyName1")
                {
                    str = Convert.ToString(item.Value);
                }

                if (item.Key == "CacheKeyName2")
                {
                    i = Convert.ToInt32(item.Value);
                }

                if (item.Key == "CacheKeyName3")
                {
                    flag = Convert.ToBoolean(item.Value);
                }

                if (item.Key == "CacheKeyName4")
                {
                    data = (List<CollectionOfData>)item.Value;
                }
            }
            Response.Write("CacheKeyName1: " + str + ", CacheKeyName2: " + i.ToString() + ", CacheKeyName3: " + flag.ToString());
            foreach (CollectionOfData item in data)
            {
                Response.Write("CacheKeyName4: ID: " + item.Id + ", Name: " + item.Name);
            }

            return View("Index");
        }

        public ActionResult Using_RemoveCache()
        {
            string strKeyName = "CacheKeyName1";
            Cache.Remove(strKeyName);
            return View("Index");
        }

        public ActionResult Using_RemoveCache_Region()
        {
            string strKeyName = "CacheKeyName1";
            Cache.Remove(strKeyName,"BMRegion1");
            return View("Index");
        }

        public ActionResult Using_RemoveRegion()
        {
            // if Region already exist then only remove.
            Cache.RemoveRegion("BMRegion1");
            return View("Index");
        }

        public ActionResult Using_ClearRegion()
        {
            Cache.ClearRegion("BMRegion1");
            return View("Index");
        }

        public ActionResult Using_Get()
        {
            //string str = "StringValue";
            string str = "";
            string strKeyName = "CacheKeyName1";
            TimeSpan ts = new TimeSpan(0, 1, 0);

            object cacheObj = Cache.Get(strKeyName);
            if (cacheObj != null)
            {
                str = Convert.ToString(cacheObj);
            }
            Response.Write("CacheKeyName1: " + str);
            return View("Index");
        }

        public ActionResult Using_Get_Region()
        {
            //string str = "StringValue";
            string str = "";
            string strKeyName = "CacheKeyName1";
            TimeSpan ts = new TimeSpan(0, 1, 0);

            object cacheObj = Cache.Get(strKeyName, "BMRegion1");
            if (cacheObj != null)
            {
                str = Convert.ToString(cacheObj);
            }
            Response.Write("CacheKeyName1: " + str);
            return View("Index");
        }

        public ActionResult Using_GetObjectsInRegion()
        {
            string str = "StringValue";
            string strKeyName = "CacheKeyName1";
            TimeSpan ts = new TimeSpan(0, 1, 0);

            //1. Insert String.
            Cache.Add(strKeyName, str, ts, "BMRegion1");


            //2. Insert Integer.
            int i = 1;
            strKeyName = "CacheKeyName2";
            Cache.Add(strKeyName, i, ts, "BMRegion1");

            //3. Insert Boolean.
            bool flag = true;
            strKeyName = "CacheKeyName3";
            Cache.Add(strKeyName, flag, ts, "BMRegion1");

            //4. Insert Class Object.
            List<CollectionOfData> data = new List<CollectionOfData>{
                new CollectionOfData{Id = 1, Name = "Name1"},
                new CollectionOfData{Id = 2, Name = "Name2"}
            };
            strKeyName = "CacheKeyName4";
            Cache.Add(strKeyName, data, ts, "BMRegion1");
            


            IEnumerable<KeyValuePair<string, object>> collection = Cache.GetObjectsInRegion("BMRegion1");

            foreach (KeyValuePair<string, object> item in collection)
            {
                if (item.Key == "CacheKeyName1")
                {
                    str = Convert.ToString(item.Value);
                }

                if (item.Key == "CacheKeyName2")
                {
                    i = Convert.ToInt32(item.Value);
                }

                if (item.Key == "CacheKeyName3")
                {
                    flag = Convert.ToBoolean(item.Value);
                }

                if (item.Key == "CacheKeyName4")
                {
                    data = (List<CollectionOfData>)item.Value;
                }
            }

            Response.Write("CacheKeyName1: " + str + ", CacheKeyName2: " + i.ToString() + ", CacheKeyName3: " + flag.ToString());
            foreach (CollectionOfData item in data)
            {
                Response.Write("CacheKeyName4: ID: " + item.Id + ", Name: " + item.Name);
            }
            return View("Index");
        }

        public ActionResult EncryptInformation()
        {
            //string encryptedValue = Encrypter.Encrypt("shakti.pawar@gmail.com".Trim());

            //Response.Write("EncryptedValue: " + encryptedValue);

            //string decryptedValue = Encrypter.Decrypt(encryptedValue);

            //Response.Write("DecryptedValue: " + decryptedValue);

            return View("Index");
        }
    }

    [Serializable]
    class CollectionOfData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
}
