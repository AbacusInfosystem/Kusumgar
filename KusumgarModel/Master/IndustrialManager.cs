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
    public class IndustrialManager
    {
        public IndustrialRepo _industrialRepo { get; set; }

        public IndustrialManager()
        {
            _industrialRepo = new IndustrialRepo();
        }

        public List<IndustrialInfo> Get_Industrials(ref PaginationInfo pager)
        {
            return _industrialRepo.Get_Industrials(ref pager);
        }

        public List<IndustrialInfo> Get_Industrials_By_Industrial_Category_Name(int industrial_Category_Id, ref PaginationInfo pager)
        {
            return _industrialRepo.Get_Industrials_By_Industrial_Category_Name(industrial_Category_Id, ref pager);
        }

        public List<IndustrialInfo> Get_Industrials_By_Industrial_Category_Id_Group_Name(int industrial_Category_Id, int industrial_Group_Id, ref PaginationInfo pager)
        {
            return _industrialRepo.Get_Industrials_By_Industrial_Category_Id_Group_Name(industrial_Category_Id, industrial_Group_Id, ref pager);
        }

        public IndustrialInfo Get_Industrial_Master_By_Id(int industrial_Master_Id)
        {
            return _industrialRepo.Get_Industrial_Master_By_Id(industrial_Master_Id);
        }

        public int Insert_Industrial(IndustrialInfo industrialInfo)
        {
            return _industrialRepo.Insert_Industrial(industrialInfo);
        }

        public void Update_Industrial(IndustrialInfo industrialInfo)
        {
            _industrialRepo.Update_Industrial(industrialInfo);
        }

        public List<IndustrialCategoryInfo> Get_Industrial_Categories(ref PaginationInfo pager)
        {
            return _industrialRepo.Get_Industrial_Categories(ref pager);
        }

        public List<IndustrialGroupInfo> Get_Industrial_Groups(int industrial_Category_Id, ref PaginationInfo pager)
        {
            return _industrialRepo.Get_Industrial_Groups(industrial_Category_Id, ref pager);
        }

        public List<IndustrialVendorInfo> Get_Industrial_Vendors_By_Id(int industrial_Master_Id, ref PaginationInfo pager)
        {
            return _industrialRepo.Get_Industrial_Vendors_By_Id(industrial_Master_Id, ref pager);
        }

        public int Insert_Industrial_Vendor(IndustrialVendorInfo industrialVendorInfo)
        {
            return _industrialRepo.Insert_Industrial_Vendor(industrialVendorInfo);
        }

        public void Update_Industrial_Vendor(IndustrialVendorInfo industrialVendorInfo)
        {

        }

        public void Delete_Industrial_Vendor_By_Id(int industrial_Vendor_Id)
        {
            _industrialRepo.Delete_Industrial_Vendor_By_Id(industrial_Vendor_Id);
        }
    }
}
