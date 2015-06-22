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
            VendorRepo vRepo = new VendorRepo();

            return vRepo.Insert_Vendor(vendor);
        }

        public List<VendorInfo> Get_Vendors(ref PaginationInfo pager)
        {
            List<VendorInfo> vendors= new List<VendorInfo>();
            
            VendorRepo vRepo = new VendorRepo();

            vendors = vRepo.Get_Vendors(ref pager);

            return vendors;
        }

        //public int Insert_Product_Services(ProductVendorInfo productVendors)
        //{
        //    VendorRepo vRepo = new VendorRepo();

        //    return vRepo.Insert_Product_Services(productVendors);
        // }

        public void Update_Vendor(VendorInfo vendors)
        {
            VendorRepo vRepo = new VendorRepo();
            
            vRepo.Update_Vendor(vendors);
        }

        //public void Update_Product_Services(ProductVendorInfo productVendors)
        //{
        //    VendorRepo vRepo = new VendorRepo();
        //    vRepo.Update_Product_Services(productVendors);
        //}

        public VendorInfo Get_Vendor_By_Id(int vendor_Id)
        {
           VendorRepo vRepo = new VendorRepo();

           return vRepo.Get_Vendor_By_Id(vendor_Id);
  
        }

        public List<VendorInfo> Get_Vendors_By_Id(int vendor_Id, ref PaginationInfo pager)
        {
            VendorRepo vRepo = new VendorRepo();

            return vRepo.Get_Vendors_By_Id(vendor_Id,ref pager);
        }

        //public void Delete_Product_Service_By_Id(int product_Vendor_Id)
        //{
        //    VendorRepo vRepo = new VendorRepo();

        //    vRepo.Delete_Product_Service_By_Id(product_Vendor_Id);
        //}

        public List<AutocompleteInfo> Get_Vendor_AutoComplete(string vendor_Name)
        {
            VendorRepo vRepo = new VendorRepo();
            return vRepo.Get_Vendor_AutoComplete(vendor_Name);
        }

        //public List<ProductVendorInfo> Get_Product_Vendor_By_Id(int product_Vendor_Id)
        //{
        //    VendorRepo vRepo = new VendorRepo();
           
        //    return vRepo.Get_Product_Vendor_By_Id(product_Vendor_Id);
            
        //}

        public bool Check_Existing_Vendor(string vendor_Name)
        {
            VendorRepo vRepo = new VendorRepo();
            return vRepo.Check_Existing_Vendor(vendor_Name);
        }

        public List<MaterialCategoryInfo> Get_Material_Category()
        {
            List<MaterialCategoryInfo> materialCategories = new List<MaterialCategoryInfo>();

            VendorRepo vRepo = new VendorRepo();

            materialCategories = vRepo.Get_Material_Category();

            return materialCategories;
        }

        public int Insert_Attribute_Code(AttributeCodeInfo attributeCode)
        {
            VendorRepo vRepo = new VendorRepo();

            return vRepo.Insert_Attribute_Code(attributeCode);
        }

        //
        public List<VendorInfo> Get_Vendors_By_Vendor_Id_Material_Id(int vendor_Id, int material_Id, ref PaginationInfo pager)
        {
            VendorRepo vRepo = new VendorRepo();

            return vRepo.Get_Vendors_By_Vendor_Id_Material_Id(vendor_Id, material_Id, ref pager);
        }

        public List<VendorInfo> Get_Vendors_By_Material_Id(int material_Id, ref PaginationInfo pager)
        {
            VendorRepo vRepo = new VendorRepo();

            return vRepo.Get_Vendors_By_Material_Id(material_Id, ref pager);
        }
     }
}

    