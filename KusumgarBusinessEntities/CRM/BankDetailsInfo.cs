using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class BankDetailsInfo
    {
        public BankDetailsInfo()
        {
           // Bank_Details_Entity = new Bank_Details();
        }

        //public Bank_Details Bank_Details_Entity { get; set; }

        public int Bank_Details_Id { get; set; }

        public int Supplier_Id { get; set; }

        public int Customer_Id { get; set; }

        public string Bank_Name { get; set; }

        public string Bank_Account_No { get; set; }

        public string Branch_Name { get; set; }

        public string Ifsc_Code { get; set; }

        public string Swift_Code { get; set; }

        public string Rtgs_No { get; set; }

        public string Bank_Address { get; set; }

        public string Bank_Code { get; set; }

        public string Account_Code { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public string Vat { get; set; }

        public int Currency_Id { get; set; }

        public int Payment_Term_Id { get; set; }

        public string Tax_Excemption_Code { get; set; }

        public int Credit_limit { get; set; }
    }
}
