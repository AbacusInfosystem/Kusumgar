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
    public class IndustrialManager
    {
        public IndustrialRepo _iRepo { get; set; }

        public IndustrialManager()
        {
            _iRepo = new IndustrialRepo();
        }

        public List<IndustrialInfo> Get_Industrial_Master(PaginationInfo Pager)
        {
            return _iRepo.GetIndustrialMaster(Pager);
        }

        public IndustrialInfo Get_Industrial_Master_By_Id(int IndustrialMasterId)
        {
            return _iRepo.GetIndustrialMasterById(IndustrialMasterId);
        }

        public void Insert_Industrial_Master(IndustrialInfo industrialInfo)
        {
            _iRepo.Insert_Industrial_Master(industrialInfo);
        }

        public void Update_Industrial_Master(IndustrialInfo industrialInfo)
        {
            _iRepo.Update_Industrial_Master(industrialInfo);
        }
    }
}
