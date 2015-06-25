using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kusumgar.Models;
using KusumgarBusinessEntities;

using KusumgarModel;
using KusumgarBusinessEntities.Common;
using KusumgarHelper.PageHelper;
using System.IO;
using KusumgarCrossCutting.Logging;

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

        #region Attachments

        public JsonResult Insert_Attachment(object obj)
        {

            AjaxViewModel aViewModel = new AjaxViewModel();

            try
            {
                AjaxManager aMan = new AjaxManager();

                var length = Request.ContentLength;
                var bytes = new byte[length];
                Request.InputStream.Read(bytes, 0, length);
                // bytes has byte content here. what do do next?

                var fileName = Request.Headers["X-File-Name"];
                var fileSize = Request.Headers["X-File-Size"];
                var fileType = Request.Headers["X-File-Type"];
                var ref_Id = Request.Headers["RefId"];
                var ref_Type = Request.Headers["RefType"];

               

                aViewModel.Attachment.Document_Name = fileName;

                aViewModel.Attachment.Ref_Type = Convert.ToInt32(ref_Type);

                aViewModel.Attachment.Ref_Id = Convert.ToInt32(ref_Id);

                aViewModel.Attachment.CreatedBy = ((UserInfo)Session["User"]).UserId;

                aViewModel.Attachment.UpdatedBy = ((UserInfo)Session["User"]).UserId;

                aViewModel.Attachment.CreatedOn = DateTime.Now;

                aViewModel.Attachment.UpdatedOn = DateTime.Now;

                 var saveToFileLoc = string.Format("{0}\\{1}",
                                               Server.MapPath("/uploads/" + aViewModel.Attachment.Ref_Type_Str + "/" + aViewModel.Attachment.Ref_Id),
                                               fileName);

                 bool directoryExists = System.IO.Directory.Exists(Server.MapPath("/uploads/" + aViewModel.Attachment.Ref_Type_Str + "/" + aViewModel.Attachment.Ref_Id));

                 if (!directoryExists)
                 {
                     System.IO.Directory.CreateDirectory(Server.MapPath("/uploads/" + aViewModel.Attachment.Ref_Type_Str + "/" + aViewModel.Attachment.Ref_Id));
                 }

                 bool FileExists = System.IO.File.Exists(Server.MapPath("/uploads/" + aViewModel.Attachment.Ref_Type_Str + "/" + aViewModel.Attachment.Ref_Id + "/" + fileName));

                 if (!FileExists)
                 {
                     // save the file.
                     var fileStream = new FileStream(saveToFileLoc, FileMode.Create, FileAccess.ReadWrite);

                     fileStream.Write(bytes, 0, length);

                     fileStream.Close();

                    aViewModel.Attachment.Attachment_Id = aMan.Insert_Attachment(aViewModel.Attachment);

                    aViewModel.Friendly_Message.Add(MessageStore.Get("AJ001"));
                }
                 else
                 {
                     aViewModel.Friendly_Message.Add( MessageStore.Get("AJ003"));
                 }

                // aViewModel.Attachments = aMan.Get_Attachments_By_Ref_Type_Ref_Id(aViewModel.Attachment.Ref_Type, aViewModel.Attachment.Ref_Id);
            }
            catch (Exception ex)
            {
                aViewModel.Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Ajax Controller - Insert_Attachments " + ex.ToString());
            }

            return Json(aViewModel , JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete_Attachment(long attachment_Id)
        {
            List<FriendlyMessageInfo> Friendly_Message = new List<FriendlyMessageInfo>();

            AttachmentsInfo attachments = new AttachmentsInfo();

            try
            {
                AjaxManager aMan = new AjaxManager();

                attachments = aMan.Get_Attachment_By_Id(attachment_Id);

                var saveToFileLoc = string.Format("{0}\\{1}",
                                                Server.MapPath("/uploads/" + attachments.Ref_Type_Str + "/" + attachments.Ref_Id),
                                                attachments.Document_Name);
      
                if (saveToFileLoc != null || saveToFileLoc != string.Empty)
                {
                    if ((System.IO.File.Exists(saveToFileLoc)))
                    {
                        System.IO.File.Delete(saveToFileLoc);
                    }

                }

                aMan.Delete_Attachment_By_Id(attachment_Id);

                Friendly_Message.Add(MessageStore.Get("AJ002"));
            }
            catch(Exception ex)
            {
                Friendly_Message.Add(MessageStore.Get("SYS01"));

                Logger.Error("Ajax Controller - Delete_Attachment " + ex.ToString());
            }

            return Json(new { Friendly_Message }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Get_Attachments_By_Ref_Type_Ref_Id(int ref_Type, int ref_Id)
        {
            List<AttachmentsInfo> Attachments = new List<AttachmentsInfo>();

            try
            {
                AjaxManager aMan = new AjaxManager();

                Attachments = aMan.Get_Attachments_By_Ref_Type_Ref_Id(ref_Type, ref_Id);
            }
            catch(Exception ex)
            {
                Logger.Error("Ajax Controller - Get_Attachments_By_Ref_Type_Ref_Id " + ex.ToString());
            }

            return Json(new { Attachments }, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}
