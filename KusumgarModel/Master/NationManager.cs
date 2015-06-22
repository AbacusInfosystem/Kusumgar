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

        public List<NationInfo> Get_Nations_By_Customer_Id(int Customer_Id, ref PaginationInfo pager)
        {
            return _nationRepo.Get_Nations_By_Customer_Id(Customer_Id,ref pager);
        }

    }
}
