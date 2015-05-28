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
    public class ConsumableManager
    {

        public ConsumableRepo _cRepo;

        public ConsumableManager()
        {
            _cRepo = new ConsumableRepo();
        }

        public List<ConsumableInfo> Get_Category_Name(PaginationInfo pager)
        {

            return _cRepo.Get_Category_Name(pager);
        }

        public List<ConsumableInfo> Get_SubCategory_Name(PaginationInfo pager)
        {

            return _cRepo.Get_SubCategory_Name(pager);
        }


        public int Insert_Consumable(ConsumableInfo consumable)
        {
            return _cRepo.Insert_Consumable(consumable);
        }

        public List<ConsumableInfo> Get_Consumables(PaginationInfo pager)
        {
            return _cRepo.Get_Consumables(pager);
        }

        public int Insert_Consumable_Vendor(ConsumableInfo consumable)
        {
            return _cRepo.Insert_Consumable_Vendor(consumable);
        }


        public List<ConsumableVendorInfo> Get_Consumable_Vendor_By_Consumable_Id(int consumable_Id)
        {
            return _cRepo.Get_Consumable_Vendor_By_Consumable_Id(consumable_Id);
        }

        public void Delete_Vendor_By_Id(int consumable_vendor_Id)
        {
            _cRepo.Delete_Vendor_By_Id(consumable_vendor_Id);
        }

        public ConsumableInfo Get_Consumable_By_Id(int consumable_Id)
        {
            return _cRepo.Get_Consumable_By_Id(consumable_Id);
        }

        public void Update_Consumable(ConsumableInfo consumable)
        {
            _cRepo.Update_Consumable(consumable);
        }

        public List<ConsumableInfo> Get_Consumable_By_Category_Id_By_Material_Name(int category_Id, string material_Name, PaginationInfo pager)
        {
            return _cRepo.Get_Consumable_By_Category_Id_By_Material_Name(category_Id, material_Name, pager);
        }

        public List<ConsumableInfo> Get_Consumable_By_Category_Id(int category_Id, PaginationInfo pager)
        {
            return _cRepo.Get_Consumable_By_Category_Id(category_Id, pager);
        }

        public List<ConsumableInfo> Get_Consumable_By_Material_Name(string material_name, PaginationInfo pager)
        {
            return _cRepo.Get_Consumable_By_Material_Name(material_name, pager);
        }

        public List<AutocompleteInfo> Get_Vendor_AutoComplete(string vendor_Name)
        {
            return _cRepo.Get_Vendor_AutoComplete(vendor_Name);
        }

        public void Update_Consumable_Vendors(ConsumableInfo consumable)
        {
            _cRepo.Update_Consumable_Vendors(consumable);
        }

    }
}
