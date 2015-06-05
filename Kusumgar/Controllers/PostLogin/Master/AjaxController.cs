using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kusumgar.Models;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarModel;
using KusumgarBusinessEntities.Common;
using KusumgarHelper.PageHelper;

namespace Kusumgar.Controllers
{
    public class AjaxController : Controller
    {
        public AjaxManager _ajaxMgr;

        public AjaxController()
        {
            _ajaxMgr = new AjaxManager();
        }

        public JsonResult GetTestUnit(string testUnitName)
        {
            AjaxManager aMan = new AjaxManager();

            List<TestUnitInfo> retVal = new List<TestUnitInfo>();

            retVal = aMan.GetTestUnit(testUnitName);

            return Json(retVal, JsonRequestBehavior.AllowGet);
        }

       

        public JsonResult Get_Vendor_Autocomplete(string Vendor_Name)
        {
            AjaxManager aMan = new AjaxManager();

            List<AutocompleteInfo> vendorNames = new List<AutocompleteInfo>();

            vendorNames = aMan.Get_Vendor_AutoComplete(Vendor_Name);

            return Json(vendorNames, JsonRequestBehavior.AllowGet);
        }
       
    }
}
