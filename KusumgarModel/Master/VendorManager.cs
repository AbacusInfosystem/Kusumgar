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
    public class VendorManager
    {
        public int Insert_Vendor(VendorInfo vendor)
        {
            VendorRepo dRepo = new VendorRepo();

            return dRepo.Insert(vendor);
        }

       
    }
}
