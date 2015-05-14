using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
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

      public List<AutoCompleteInfo> Get_Customer_AutoComplete(string Customer_Name)
      {
          return _ajaxRepo.Get_Customer_AutoComplete(Customer_Name);
      }
    }
}
