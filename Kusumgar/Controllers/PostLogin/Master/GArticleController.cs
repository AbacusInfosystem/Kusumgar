using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kusumgar.Models;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarModel;
using KusumgarHelper.PageHelper;
using KusumgarBusinessEntities.Common;
using KusumgarCrossCutting.Logging;

namespace Kusumgar.Controllers
{
    public class GArticleController : Controller
    {
        public GArticleManager _garticleMan;

        public AttributeCodeManager _attMan;

        public GArticleController()
        {
            _garticleMan = new GArticleManager();

            _attMan = new AttributeCodeManager();
        }

        public ActionResult Index(GArticleViewModel gaViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            PaginationInfo pager = new PaginationInfo();
            try
            {
                pager.IsPagingRequired = false;

                gaViewModel.G_Article.Qualities = _garticleMan.Get_Qualities(ref pager);

                gaViewModel.Attribute_Codes = _attMan.Get_Attribute_Codes(ref pager);

                gaViewModel.G_Article.Vendors = _garticleMan.Get_Vendors(ref pager);

            }
            catch (Exception ex)
            {
                gaViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error(" G Article Controller - Index " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return View("Index", gaViewModel);
        }

        public ActionResult Search(GArticleViewModel gaViewModel)
        {
            ViewBag.Title = "KPCL ERP :: Create, Update";

            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = false;

            try
            {
                gaViewModel.Attribute_Codes = _attMan.Get_Attribute_Codes(ref pager);
            }
            catch (Exception ex)
            {
                gaViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("YArticle Controller - Insert " + ex.ToString());
            }
            finally
            {
                pager = null;
            }

            return View("Search", gaViewModel);
        }

        public JsonResult Insert(GArticleViewModel gaViewModel)
        {
            try
            {
                gaViewModel.G_Article.CreatedBy = ((UserInfo)Session["User"]).UserId;

                gaViewModel.G_Article.CreatedOn = DateTime.Now;

                gaViewModel.G_Article.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                gaViewModel.G_Article.UpdatedOn = DateTime.Now;

                gaViewModel.G_Article.G_Article_Id = _garticleMan.Insert_G_Article(gaViewModel.G_Article);

                gaViewModel.Friendly_Message.Add(MessageStore.Get("GA001"));
            }
            catch (Exception ex)
            {
                gaViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("GArticle Controller - Insert " + ex.ToString());
            }

            return Json(gaViewModel);
        }

        public JsonResult Update(GArticleViewModel gaViewModel)
        {
            try
            {
                gaViewModel.G_Article.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                gaViewModel.G_Article.UpdatedOn = DateTime.Now;

                _garticleMan.Update_G_Article(gaViewModel.G_Article);

                gaViewModel.Friendly_Message.Add(MessageStore.Get("GA002"));
            }
            catch (Exception ex)
            {
                gaViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("GArticle Controller - Insert " + ex.ToString());
            }

            return Json(gaViewModel);
        }

        public JsonResult Get_G_Articles(GArticleViewModel gaViewModel)
        {
            PaginationInfo pager = new PaginationInfo();

            try
            {
                pager = gaViewModel.Pager;

                if (gaViewModel.Filter.G_Article_Id != 0 && gaViewModel.Filter.Yarn_Type_Id != 0)
                {
                    gaViewModel.G_Articles = _garticleMan.Get_G_Articles_By_G_Article_Id_By_Yarn_Type_Id(gaViewModel.Filter.G_Article_Id, gaViewModel.Filter.Yarn_Type_Id, ref pager);
                }
                else if (gaViewModel.Filter.G_Article_Id != 0)
                {
                    gaViewModel.G_Articles = _garticleMan.Get_G_Articles_By_G_Article_Id(gaViewModel.Filter.G_Article_Id, ref pager);
                }
                else if (gaViewModel.Filter.Yarn_Type_Id != 0)
                {
                    gaViewModel.G_Articles = _garticleMan.Get_G_Articles_By_Yarn_Type_Id(gaViewModel.Filter.Yarn_Type_Id, ref pager);
                }
                else
                {
                    gaViewModel.G_Articles = _garticleMan.Get_G_Articles(ref pager);
                }

                gaViewModel.Pager = pager;

                gaViewModel.Pager.PageHtmlString = PageHelper.NumericPager("javascript:PageMore({0})", gaViewModel.Pager.TotalRecords, gaViewModel.Pager.CurrentPage + 1, gaViewModel.Pager.PageSize, 10, true);
            }
            catch (Exception ex)
            {
                gaViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("GArticle Controller - Update " + ex.ToString());
            }
            finally
            {
                pager = null;
            }
            return Json(gaViewModel);
        }

        //Edit
        public ActionResult Get_G_Article_By_Id(GArticleViewModel gaViewModel)
        {
            try
            {
                gaViewModel.G_Article = _garticleMan.Get_G_Article_By_Id(gaViewModel.G_Article.G_Article_Id);
            }
            catch (Exception ex)
            {
                gaViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("YArticle Controller - Update " + ex.ToString());
            }

            return Index(gaViewModel);
        }

        //AutoComplete for Full_Code
        public JsonResult Get_G_Articles_By_Full_Code(string full_Code)
        {
            List<AutocompleteInfo> autoCompletes = new List<AutocompleteInfo>();

            try
            {
                autoCompletes = _garticleMan.Get_G_Articles_By_Full_Code(full_Code);
            }
            catch (Exception ex)
            {
                Logger.Error("GArticle Controller - Get_G_Articles_By_Full_Code " + ex.ToString());
            }

            return Json(autoCompletes, JsonRequestBehavior.AllowGet);
        }



    }
}
