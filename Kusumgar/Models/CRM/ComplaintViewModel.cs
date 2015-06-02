using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class ComplaintViewModel
    {
        public ComplaintInfo Complaint { get; set; }
        public List<ComplaintInfo> Complaints { get; set; }
        public PaginationInfo Pager { get; set; }
        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
        public Complaint_Filter Filter { get; set; }
        public int Complaint_Id { get; set; }        

        public ComplaintViewModel()
        {
            Complaint = new ComplaintInfo();
            Complaints = new List<ComplaintInfo>();
            Pager = new PaginationInfo();
            Friendly_Message = new List<FriendlyMessageInfo>();
            Filter = new Complaint_Filter();
        }
        
    }
    
    public class Complaint_Filter
    {
        public string Customer_Name { get; set; }
        public int Customer_Id { get; set; }
    }
}