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
using KusumgarCrossCutting.Logging;

namespace Kusumgar.Controllers
{
    public class YArticleController : Controller
    {
        //
        // GET: /YArticle/

        public YArticleManager _yArticleMan;

        public AttributeCodeManager _attMan;

        public YArticleController()
        {
            _yArticleMan = new YArticleManager();

            _attMan = new AttributeCodeManager();
        }

        public ActionResult Index(YArticleViewModel yViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = false; 

            try
            {
                yViewModel.Attribute_Codes = _attMan.Get_Attribute_Codes(pager);

                yViewModel.Is_Primary = true;
            }
            catch(Exception ex)
            {
                yViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("YArticle Controller - Index " + ex.ToString());
            }
            finally
            {
                pager = null;
            }
            return View("Index",yViewModel);
        }

        public ActionResult Search(YArticleViewModel yViewModel)
        {
            return View("Search",yViewModel);
        }

        public PartialViewResult Load_YArticle(YArticleViewModel yViewModel)
        {
            return PartialView("_YArticle", yViewModel);
        }

        public JsonResult Insert(YArticleViewModel yViewModel)
        {
            try
            {
                yViewModel.YArticle.YArticle_Entity.CreatedBy = 1;

                yViewModel.YArticle.YArticle_Entity.UpdatedBy = 1;

                int yArticle_Id = _yArticleMan.Insert_YArticle(yViewModel.YArticle);

                yViewModel.YArticle.YArticle_Entity.Y_Article_Id = yArticle_Id;

                yViewModel.Friendly_Message.Add(MessageStore.Get("CU001"));
            }
            catch (Exception ex)
            {
                yViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Insert " + ex.ToString());
            }

            return Json(yViewModel);
        }

        public JsonResult Update(YArticleViewModel yViewModel)
        {
            try
            {
                yViewModel.YArticle.YArticle_Entity.UpdatedBy = 1;

                _yArticleMan.Update_YArticle(yViewModel.YArticle);

                yViewModel.Friendly_Message.Add(MessageStore.Get("CU002"));
            }
            catch (Exception ex)
            {
                yViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Customer Controller - Update " + ex.ToString());
            }

            return Json(yViewModel);
        }

    }
}
