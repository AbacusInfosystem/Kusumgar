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
    public class ComplaintManager
    {
        public ComplaintRepo _cRepo { get; set; }

        public ComplaintManager()
        {
            _cRepo = new ComplaintRepo();
        }

        public List<ComplaintInfo> Get_Complaints(ref PaginationInfo pager)
        {
            return _cRepo.Get_Complaints(ref pager);
        }

        public List<ComplaintInfo> Get_Complaints_By_Cust_Id(int customer_Id, ref PaginationInfo pager)
        {
            return _cRepo.Get_Complaints_By_Cust_Id(customer_Id, ref pager);
        }

        public ComplaintInfo Get_Complaint_By_Id(int complaint_Id)
        {
            return _cRepo.Get_Complaint_By_Id(complaint_Id);
        }

        public int Insert_Complaint(ComplaintInfo complaintInfo)
        {
            return _cRepo.Insert_Complaint(complaintInfo);
        }

        public void Update_Complaint(ComplaintInfo complaintInfo)
        {
            _cRepo.Update_Complaint(complaintInfo);
        }

        public List<AutocompleteInfo> Get_Customer_Id(string customer_Name)
        {
            List<AutocompleteInfo> auto_List = new List<AutocompleteInfo>();            
            auto_List = _cRepo.Get_Customer_Id(customer_Name);
            return auto_List;
        }

        public void Insert_Complaint_Lot_Mapping(ComplaintLotMappingInfo complaint_Lot_Mapping)
        {
            _cRepo.Insert_Complaint_Lot_Mapping(complaint_Lot_Mapping);
        }

        public List<ComplaintLotMappingInfo> Get_Complaint_Lot_Mappings(int complaint_Id)
        {
            return _cRepo.Get_Complaint_Lot_Mappings(complaint_Id);
        }
    }
}
