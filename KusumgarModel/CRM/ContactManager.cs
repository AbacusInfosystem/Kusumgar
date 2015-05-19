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

        public List<ContactInfo> Get_Contacts(ref  PaginationInfo Pager)
        {
            return _contactRepo.Get_Contacts(ref Pager);
        }

        public List<ContactInfo> Get_Contacts_By_Name(int customer_Id, ref PaginationInfo pager)
        {
            return _contactRepo.Get_Contacts_By_Name(customer_Id, ref pager);
        }

        public ContactInfo Get_Contact_By_Id(int contact_Id)
        {
            return _contactRepo.Get_Contact_By_Id(contact_Id);
        }

        public int Insert_Contact(ContactInfo contact)
        {
           return  _contactRepo.Insert_Contact(contact);
        }

        public void Update_Contact(ContactInfo contact)
        {
            _contactRepo.Update_Contact(contact);
        }

        public void Insert_Contact_Custom_Fields(ContactCustomFieldsInfo custom_Fields)
        {
            _contactRepo.Insert_Contact_Custom_Fields(custom_Fields);
        }

        public void Update_Contact_Custom_Fields(ContactCustomFieldsInfo custom_Fields)
        {
            _contactRepo.Update_Contact_Custom_Fields(custom_Fields);
        }

        public void Delete_Contact_Custom_Fields(int contact_Custom_Field_Id)
        {
            _contactRepo.Delete_Contact_Custom_Fields(contact_Custom_Field_Id);
        }
    }
}
