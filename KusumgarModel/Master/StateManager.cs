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
    public class StateManager
    {
       public StateRepo _StateRepo;

        public StateManager()
        {
            _StateRepo = new StateRepo();
        }

        public List<StateInfo> Get_States(int nation_Id, ref PaginationInfo pager)
        {
            return _StateRepo.Get_States(nation_Id, ref pager);
        }

    }
}
