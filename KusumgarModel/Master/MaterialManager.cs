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
    public class MaterialManager
    {
        public MaterialRepo _materialRepo { get; set; }

        public MaterialManager()
        {
            _materialRepo = new MaterialRepo();
        }

        public List<MaterialInfo> Get_Materials(ref PaginationInfo pager)
        {
            return _materialRepo.Get_Materials(ref pager);
        }

        public List<MaterialInfo> Get_Materials_By_Material_Id(int Material_Id, ref PaginationInfo pager)
        {
            return _materialRepo.Get_Materials_By_Id(Material_Id, ref pager);
        }

        public List<AutocompleteInfo> Get_Materials_By_Name_Autocomplete(string Material_Name)
        {
            return _materialRepo.Get_Materials_By_Name_Autocomplete(Material_Name);
        }

        public MaterialInfo Get_Material_By_Id(int Material_Id)
        {
            return _materialRepo.Get_Material_By_Id(Material_Id);
        }

        public int Insert_Material(MaterialInfo MaterialInfo)
        {
            return _materialRepo.Insert_Material(MaterialInfo);
        }

        public void Update_Material(MaterialInfo MaterialInfo)
        {
            _materialRepo.Update_Material(MaterialInfo);
        }

        public List<MaterialCategoryInfo> Get_Material_Categories(ref PaginationInfo pager)
        {
            return _materialRepo.Get_Material_Categories(ref pager);
        }

        public List<MaterialSubCategoryInfo> Get_Material_SubCategories(int Material_Category_Id, ref PaginationInfo pager)
        {
            return _materialRepo.Get_Material_SubCategories(Material_Category_Id, ref pager);
        }

        public List<MaterialVendorInfo> Get_Material_Vendors_By_Id(int Material_Id)
        {
            return _materialRepo.Get_Material_Vendors_By_Id(Material_Id);
        }

        public int Insert_Material_Vendor(MaterialVendorInfo MaterialVendorInfo)
        {
            return _materialRepo.Insert_Material_Vendor(MaterialVendorInfo);
        }

        public void Delete_Material_Vendor_By_Id(int Material_Vendor_Id)
        {
            _materialRepo.Delete_Material_Vendor_By_Id(Material_Vendor_Id);
        }

        public List<AutocompleteInfo> Get_Vendor_Autocomplete(string vendor_Name)
        {
            return _materialRepo.Get_Vendor_Autocomplete(vendor_Name);
        }

        //search
        public List<MaterialInfo> Get_Materials_By_Material_Id_Vendor_Id(int material_Id, int vendor_Id, ref PaginationInfo pager)
        {
            return _materialRepo.Get_Materials_By_Material_Id_Vendor_Id(material_Id, vendor_Id, ref pager);
        }

        public List<MaterialInfo> Get_Materials_By_Vendor_Id(int vendor_Id, ref PaginationInfo pager)
        {
            return _materialRepo.Get_Materials_By_Vendor_Id(vendor_Id, ref pager);
        }
    }
}
