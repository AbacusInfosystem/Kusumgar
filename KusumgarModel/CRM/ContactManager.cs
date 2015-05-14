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
    public class ContactManager
    {
        ContactRepo _contactRepo;

        public ContactManager()
        {
            _contactRepo = new ContactRepo();
        }

        public List<ContactInfo> Get_Contact_List(PaginationInfo Pager)
        {
            return _contactRepo.Get_Contact_List(ref Pager);
        }

        public List<ContactInfo> Get_Contact_List_By_Name(int Customer_Id, PaginationInfo Pager)
        {
            return _contactRepo.Get_Contact_List_By_Name(Customer_Id, ref Pager);
        }

        public ContactInfo Get_Contact_By_Id(int Contact_Id)
        {
            return _contactRepo.Get_Contact_By_Id(Contact_Id);
        }

        public int Insert_Contact(ContactInfo contact)
        {
           return  _contactRepo.Insert_Contact(contact);
        }

        public void Update_Contact(ContactInfo contact)
        {
            _contactRepo.Update_Contact(contact);
        }

        public void Insert_Contact_Custom_Fields(ContactCustomFieldsInfo customfields)
        {
            _contactRepo.Insert_Contact_Custom_Fields(customfields);
        }

        public void Update_Contact_Custom_Fields(ContactCustomFieldsInfo customfields)
        {
            _contactRepo.Update_Contact_Custom_Fields(customfields);
        }

        public void Delete_Contact_Custom_Fields(int Contact_Custom_Field_Id)
        {
            _contactRepo.Delete_Contact_Custom_Fields(Contact_Custom_Field_Id);
        }
    }
}
