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

        #region Enquiry

        public void Insert_Enquiry(ref EnquiryInfo enquiry)
        {
             _enquiryRepo.Insert_Enquiry(ref enquiry);
        }

        public void Update_Enquiry(EnquiryInfo enquiry)
        {
            _enquiryRepo.Update_Enquiry(enquiry);
        }

        public List<EnquiryInfo> Get_Enquiries(ref PaginationInfo pager)
        {
            return _enquiryRepo.Get_Enquiries(ref pager);
        }

        public List<EnquiryInfo> Get_Enquiries_By_Status(ref PaginationInfo pager, int enquiry_Status_Id)
        {
            return _enquiryRepo.Get_Enquiries_By_Status(ref pager, enquiry_Status_Id);
        }

        public EnquiryInfo Get_Enquiry_By_Id(int Enquiry_Id)
        {
            return _enquiryRepo.Get_Enquiry_By_Id(Enquiry_Id);
        }

        public List<AutocompleteInfo> Get_Quality_Autocomplete(string quality_No)
        {
            return _enquiryRepo.Get_Quality_Autocomplete(quality_No);
        }

        #endregion

        #region Staggered Order

         public void Insert_Staggered_Order(StaggeredOrderInfo staggeredorder)
        {
            _enquiryRepo.Insert_Staggered_Order(staggeredorder);
        }

        public void Update_Staggered_Order(StaggeredOrderInfo staggeredorder)
         {
             _enquiryRepo.Update_Staggered_Order(staggeredorder);
         }

         public List<StaggeredOrderInfo> Get_Staggered_Orders(ref PaginationInfo pager)
        {
           return _enquiryRepo.Get_Staggered_Orders(ref pager);
        }

        public List<StaggeredOrderInfo> Get_Staggered_Orders_By_Enquiry_Id(int enquiry_Id,ref PaginationInfo pager)
         {
             return _enquiryRepo.Get_Staggered_Orders_By_Enquiry_Id(enquiry_Id, ref pager);
         }

         public StaggeredOrderInfo Get_Staggered_Order_By_Id(int staggered_Order_Id)
        {
            return _enquiryRepo.Get_Staggered_Order_By_Id(staggered_Order_Id);
        }

         public void Delete_Staggered_Order_By_Id(int staggered_Order_Id)
         {
             _enquiryRepo.Delete_Staggered_Order_By_Id(staggered_Order_Id);
         }
        
        #endregion

        #region Supporting Details

         public void Insert_Supporting_Details(SupportingDetailsInfo supporting_Details)
         {
             _enquiryRepo.Insert_Supporting_Details(supporting_Details);
         }

        public void Update_Supporting_Details(SupportingDetailsInfo supporting_Details)
         {
             _enquiryRepo.Update_Supporting_Details(supporting_Details);
         }

         public SupportingDetailsInfo Get_Supporting_Details_By_Enquiry_Id(int enquiry_Id)
        {
           return _enquiryRepo.Get_Supporting_Details_By_Enquiry_Id(enquiry_Id);
        }

        #endregion

        #region Temp Customer Quality Details

         public void Insert_Temp_Customer_Quality_Details(TempCustomerQualityDetailsInfo temp_Customer_Quality_Details)
         {
             _enquiryRepo.Insert_Temp_Customer_Quality_Details(temp_Customer_Quality_Details);
         }

        public void Update_Temp_Customer_Quality_Details(TempCustomerQualityDetailsInfo temp_Customer_Quality_Details)
         {
             _enquiryRepo.Update_Temp_Customer_Quality_Details(temp_Customer_Quality_Details);
         }

        public TempCustomerQualityDetailsInfo Get_Temp_Customer_Quality_Details_By_Id(int enquiry_Id)
        {
           return  _enquiryRepo.Get_Temp_Customer_Quality_Details_By_Id(enquiry_Id);
        }

        #endregion
    }
}
