using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities;
using KusumgarDataAccess;
using KusumgarBusinessEntities.Common;

namespace KusumgarModel
{
  public  class AjaxManager
    {

      public AjaxRepo _ajaxRepo;

      public AjaxManager()
      {
          _ajaxRepo = new AjaxRepo();
      }

      public List<TestUnitInfo> GetTestUnit(string testUnitName)
        {
            return _ajaxRepo.GetTestUnit(testUnitName);
        }

      public List<AutocompleteInfo> Get_Vendor_AutoComplete(string Vendor_Name)
      {
          return _ajaxRepo.Get_Vendor_AutoComplete(Vendor_Name);
      }

      #region Attachments

      public long Insert_Attachment(AttachmentsInfo attachment)
      {
          return _ajaxRepo.Insert_Attachment(attachment);
      }

      public void Delete_Attachment_By_Id(long attachment_Id)
      {
           _ajaxRepo.Delete_Attachment_By_Id(attachment_Id);
      }

      public List<AttachmentsInfo> Get_Attachments_By_Ref_Type_Ref_Id(int ref_Type, int ref_Id)
      {
          return _ajaxRepo.Get_Attachments_By_Ref_Type_Ref_Id(ref_Type, ref_Id);
      }

      public AttachmentsInfo Get_Attachment_By_Id(long attachment_Id)
      {
          return _ajaxRepo.Get_Attachment_By_Id(attachment_Id);
      }

      #endregion

      #region Autorize Web Elements

      public bool Get_Web_Element_Authorize(WebElementInfo webElement)
      {
          return _ajaxRepo.Get_Web_Element_Authorize(webElement);
      }

      #endregion

    }
}
