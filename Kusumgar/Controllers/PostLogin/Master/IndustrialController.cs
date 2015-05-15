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
    public class IndustrialController : Controller
    {
        //
        // GET: /Industrial/

        public IndustrialManager _iMgr;

        public IndustrialController()
        {
            _iMgr = new IndustrialManager();
        }

        public ActionResult Index(IndustrialViewModel industrialViewModel)
        {
            try
            {
                industrialViewModel.Pager.IsPagingRequired = false;
            }
            catch (Exception ex)
            {
                industrialViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }
            return View("Index", industrialViewModel);
        }

        public ActionResult Search(IndustrialViewModel industrialViewModel)
        {            
            if(TempData["industrialViewModel"] != null)
            {
                industrialViewModel = (IndustrialViewModel)TempData["industrialViewModel"];
            }                      
            return View("Search", industrialViewModel);
        }

        public ActionResult Insert(IndustrialViewModel industrialViewModel)
        {
            try
            {
                _iMgr.Insert_Industrial_Master(industrialViewModel.Industrial);

            }
            catch (Exception ex)
            {
                industrialViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }
            TempData["industrialViewModel"] = industrialViewModel;
            return RedirectToAction("Search");
        }

        public ActionResult Update(IndustrialViewModel industrialViewModel)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                industrialViewModel.FriendlyMessage.Add(MessageStore.Get("SYS01"));
            }
            return RedirectToAction("Search");
        }
    }
}
