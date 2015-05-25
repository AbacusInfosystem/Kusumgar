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
    public class NationManager
    {
        public NationRepo _nationRepo;
         
        public NationManager()
        {
            _nationRepo = new NationRepo();
        }

        public List<NationInfo> Get_Nations(ref PaginationInfo pager)
        {
            return _nationRepo.Get_Nations(ref pager);
        }

    }
}
