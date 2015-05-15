using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDataAccess;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarModel
{
    public class ConsumableMasterManager
    {
        public ConsumableMasterRepo cmRepo { get; set; }

        public ConsumableMasterManager()
        {
            cmRepo = new ConsumableMasterRepo();
        }

        public List<ConsumableMasterInfo> GetCategoryName()
        {
            List<ConsumableMasterInfo> consumablemaster = new List<ConsumableMasterInfo>();
            ConsumableMasterRepo CMRepo = new ConsumableMasterRepo();
            consumablemaster = CMRepo.GetCategoryName();
            return consumablemaster;
        }

        public List<ConsumableMasterInfo> GetSubCategoryName()
        {
            List<ConsumableMasterInfo> consumablemaster = new List<ConsumableMasterInfo>();
            ConsumableMasterRepo CMRepo = new ConsumableMasterRepo();
            consumablemaster = CMRepo.GetSubCategoryName();
            return consumablemaster;
        }

        //public void Insert(ConsumableMasterInfo CMInfo)
        //{
        //    ConsumableMasterRepo CMRepo = new ConsumableMasterRepo();
        //    CMRepo.Insert(CMInfo);
        //}
        public int Insert_Consumable(ConsumableMasterInfo CMInfo)
        {
            return cmRepo.Insert_Consumable(CMInfo);
        }

        //public List<ConsumableMasterInfo> GetConsumableMaster()
        //{
        //    List<ConsumableMasterInfo> consumablemaster = new List<ConsumableMasterInfo>();
        //    ConsumableMasterRepo CMRepo = new ConsumableMasterRepo();
        //    consumablemaster = CMRepo.GetConsumableMaster();
        //    return consumablemaster;
        //}

        public List<ConsumableMasterInfo> Get_ConsumableMasters(PaginationInfo Pager)
        {
            return cmRepo.Get_ConsumableMasters(Pager);
        }

        public List<ConsumableMasterInfo> Get_Supplier_Name(string SupplierName)
        {
            List<ConsumableMasterInfo> retVal = new List<ConsumableMasterInfo>();

            retVal = cmRepo.Get_Supplier_Name(SupplierName);

            return retVal;
        }
    }
}
