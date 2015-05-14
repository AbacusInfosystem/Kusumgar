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
    public class ComplaintManager
    {
        public ComplaintRepo _cRepo { get; set; }

        public ComplaintManager()
        {
            _cRepo = new ComplaintRepo();
        }

        public List<ComplaintInfo> Get_Complaint_List(PaginationInfo Pager)
        {
            return _cRepo.Get_Complaint_List(Pager);
        }

        public List<ComplaintInfo> Get_Complaints_By_CustName(string CustomerName, PaginationInfo Pager)
        {
            return _cRepo.Get_Complaints_By_CustName(CustomerName, Pager);
        }

        public ComplaintInfo Get_Complaint_By_Id(int ComplaintId)
        {
            return _cRepo.Get_Complaint_By_Id(ComplaintId);
        }
        
        public void Insert_Complaint(ComplaintInfo complaintInfo)
        {
            _cRepo.Insert_Complaint(complaintInfo);
        }

        public void Update_Complaint(ComplaintInfo complaintInfo)
        {
            _cRepo.Update_Complaint(complaintInfo);
        }

    }
}
