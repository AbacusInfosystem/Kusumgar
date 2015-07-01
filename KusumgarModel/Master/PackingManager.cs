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
    public class PackingManager
    {
        public PackingRepo _packingRepo { get; set; }

        public PackingManager()
        {
            _packingRepo = new PackingRepo();
        }

        public void Insert_Packing(PackingInfo PackingInfo)
        {
            _packingRepo.Insert_Packing(PackingInfo);
        }

        public void Update_Packing(PackingInfo PackingInfo)
        {
            _packingRepo.Update_Packing(PackingInfo);
        }

        public List<PackingInfo> Get_Packings(ref PaginationInfo pager)
        {
            return _packingRepo.Get_Packings(ref pager);
        }

        public PackingInfo Get_Packing_By_Packing_Id(int packing_Id)
        {
            return _packingRepo.Get_Packing_By_Packing_Id(packing_Id);
        }

        public List<AutocompleteInfo> Get_Packing_By_Name_Autocomplete(string packing_Name)
        {
            return _packingRepo.Get_Packing_By_Name_Autocomplete(packing_Name);
        }

        public List<PackingInfo> Get_Packing_By_Id(int packing_Id, ref PaginationInfo pager)
        {
            return _packingRepo.Get_Packing_By_Id(packing_Id, ref pager);
        }
    }
}
