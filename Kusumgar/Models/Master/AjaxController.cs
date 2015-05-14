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

        public JsonResult Get_State_List_By_Nation_Id(int NationId)
        {
            List<StateInfo> State_List = new List<StateInfo>();

            StateManager _stateMgr = new StateManager();
            
            PaginationInfo Pager = new PaginationInfo();

            Pager.IsPagingRequired = false;

            State_List = _stateMgr.Get_State_List(NationId, Pager);

            return Json(State_List);
        }

    }
}
