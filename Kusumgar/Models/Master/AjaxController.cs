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

namespace Kusumgar.Models
{
    public class AjaxController : Controller
    {
        //
        // GET: /Ajax/

        public JsonResult Get_State_List_By_Nation_Id(int nationId)
        {
            List<StateInfo> State_List = new List<StateInfo>();

            StateManager _stateMan = new StateManager();
            
            PaginationInfo pager = new PaginationInfo();

            pager.IsPagingRequired = false;

            State_List = _stateMan.Get_States(nationId,ref pager);

            return Json(State_List);
        }

    }
}
