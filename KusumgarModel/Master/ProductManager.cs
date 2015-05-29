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
    public class ProductManager
    {
        public ProductRepo _productRepo { get; set; }

        public ProductManager()
        {
            _productRepo = new ProductRepo();
        }

        public List<ProductInfo> Get_Products(ref PaginationInfo pager)
        {
            return _productRepo.Get_Products(ref pager);
        }

        public List<ProductInfo> Get_Products_By_Product_Id(int product_Id, ref PaginationInfo pager)
        {
            return _productRepo.Get_Products_By_Id(product_Id, ref pager);
        }

        public List<AutocompleteInfo> Get_Products_By_Name_Autocomplete(string product_Name)
        {
            return _productRepo.Get_Products_By_Name_Autocomplete(product_Name);
        }

        public ProductInfo Get_Product_By_Id(int product_Id)
        {
            return _productRepo.Get_Product_By_Id(product_Id);
        }

        public int Insert_Product(ProductInfo productInfo)
        {
            return _productRepo.Insert_Product(productInfo);
        }

        public void Update_Product(ProductInfo productInfo)
        {
            _productRepo.Update_Product(productInfo);
        }

        public List<ProductCategoryInfo> Get_Product_Categories(ref PaginationInfo pager)
        {
            return _productRepo.Get_Product_Categories(ref pager);
        }

        public List<ProductSubCategoryInfo> Get_Product_SubCategories(int product_Category_Id, ref PaginationInfo pager)
        {
            return _productRepo.Get_Product_SubCategories(product_Category_Id, ref pager);
        }

        public List<ProductVendorInfo> Get_Product_Vendors_By_Id(int product_Id, ref PaginationInfo pager)
        {
            return _productRepo.Get_Product_Vendors_By_Id(product_Id, ref pager);
        }

        public int Insert_Product_Vendor(ProductVendorInfo productVendorInfo)
        {
            return _productRepo.Insert_Product_Vendor(productVendorInfo);
        }

        public void Delete_Product_Vendor_By_Id(int product_Vendor_Id)
        {
            _productRepo.Delete_Product_Vendor_By_Id(product_Vendor_Id);
        }

        public List<AutocompleteInfo> Get_Vendor_Autocomplete(string vendor_Name)
        {
            return _productRepo.Get_Vendor_Autocomplete(vendor_Name);
        }
    }
}
