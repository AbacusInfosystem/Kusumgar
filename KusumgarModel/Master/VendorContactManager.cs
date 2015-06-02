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
    public class VendorContactManager
    {
        VendorContactRepo _vendorcontactRepo;

        public VendorContactManager()
        {
            _vendorcontactRepo = new VendorContactRepo();
        }

        public List<AutocompleteInfo> Get_Vendor_AutoComplete(string vendor_Name)
        {
            return _vendorcontactRepo.Get_Vendor_AutoComplete(vendor_Name);
        }

        public int Insert_Vendor_Contact(VendorContactInfo vendor_Contact)
        {
            return _vendorcontactRepo.Insert_Vendor_Contact(vendor_Contact);
        }

        public void Update_Vendor_Contact(VendorContactInfo vendor_Contact)
        {
            _vendorcontactRepo.Update_Vendor_Contact(vendor_Contact);
        }


        public void Insert_Vendor_Contact_Custom_Field(VendorContactCustomFieldsInfo vendor_Custom_Field)
        {
            _vendorcontactRepo.Insert_Vendor_Contact_Custom_Field(vendor_Custom_Field);
        }

        public void Update_Vendor_Contact_Custom_Field(VendorContactCustomFieldsInfo vendor_Custom_Field)
        {
            _vendorcontactRepo.Update_Vendor_Contact_Custom_Field(vendor_Custom_Field);
        }


        public List<VendorContactInfo> Get_Vendor_Contacts(ref PaginationInfo pager)
        {
            return _vendorcontactRepo.Get_Vendor_Contacts(ref pager);
        }

        public List<VendorContactInfo> Get_Vendor_Contacts_By_Vendor_Name(int vendor_Id, ref PaginationInfo pager)
        {
            return _vendorcontactRepo.Get_Vendor_Contacts_By_Vendor_Name(vendor_Id, ref pager);
        }

        public VendorContactInfo Get_Vendor_Contact_By_Id(int contact_Id)
        {
            return _vendorcontactRepo.Get_Vendor_Contact_By_Id(contact_Id);
        }


        public void Delete_Vendor_Contact_Custom_Field(int contact_Custom_Field_Id)
        {
            _vendorcontactRepo.Delete_Vendor_Contact_Custom_Field(contact_Custom_Field_Id);
        }

       


    }
}
