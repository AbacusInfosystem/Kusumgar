using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarDataAccess;

namespace KusumgarModel
{
    public class EnquiryManager
    {
        EnquiryRepo _enquiryRepo;

        public EnquiryManager()
        {
            _enquiryRepo = new EnquiryRepo();
        }

        public int Insert_Enquiry(EnquiryInfo enquiry)
        {
            return _enquiryRepo.Insert_Enquiry(enquiry);
        }

        public void Update_Enquiry(EnquiryInfo enquiry)
        {
            _enquiryRepo.Update_Enquiry(enquiry);
        }

        public List<EnquiryInfo> Get_Enquiries(ref PaginationInfo Pager)
        {
            return _enquiryRepo.Get_Enquiries(ref Pager);
        }

        public EnquiryInfo Get_Enquiry_By_Id(int Enquiry_Id)
        {
            return _enquiryRepo.Get_Enquiry_By_Id(Enquiry_Id);
        }

        public List<AutocompleteInfo> Get_Quality_Autocomplete(string quality_No)
        {
            return _enquiryRepo.Get_Quality_Autocomplete(quality_No);
        }
    }
}
