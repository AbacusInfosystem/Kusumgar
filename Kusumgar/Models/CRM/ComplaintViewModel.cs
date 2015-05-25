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
        public List<ComplaintInfo> ComplaintList { get; set; }
        public PaginationInfo Pager { get; set; }
        public List<FriendlyMessageInfo> FriendlyMessage { get; set; }
        public Complaint_Filter Complaint_Filter { get; set; }
        public int ComplaintId { get; set; }        

        public ComplaintViewModel()
        {
            Complaint = new ComplaintInfo();
            ComplaintList = new List<ComplaintInfo>();
            Pager = new PaginationInfo();
            FriendlyMessage = new List<FriendlyMessageInfo>();
            Complaint_Filter = new Complaint_Filter();
        }
        
    }
    
    public class Complaint_Filter
    {
        public string CustomerName { get; set; }
    }
}