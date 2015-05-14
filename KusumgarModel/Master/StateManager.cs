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
    public class StateManager
    {
       public StateRepo _StateRepo;

        public StateManager()
        {
            _StateRepo = new StateRepo();
        }

          public List<StateInfo> Get_State_List(int Nation_Id, PaginationInfo Pager)
        {
            return _StateRepo.Get_State_List(Nation_Id, Pager);
        }

    }
}
