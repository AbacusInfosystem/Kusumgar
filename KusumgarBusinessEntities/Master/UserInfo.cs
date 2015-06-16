using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class UserInfo
    {
        public UserInfo()
        {
           // UserEntity = new M_User();

            User_Roles = new List<UserRoleInfo>();

            Access_Functions = new List<AccessFunctionInfo>();
            
        }

        //public M_User UserEntity { get; set; }

        public int UserId { get; set; }

        public string First_Name { get; set; }

        public string Middle_Name { get; set; }

        public string Last_Name { get; set; }

        public string Mobile_No1 { get; set; }

        public string Mobile_No2 { get; set; }

        public string Residence_Landline { get; set; }

        public string Office_Landline { get; set; }

        public string Office_Address { get; set; }

        public string Residence_Address { get; set; }

        public string Office_PinCode { get; set; }

        public string Residence_PinCode { get; set; }

        public string Designtation { get; set; }

        public DateTime Birth_Date { get; set; }

        public string Fax_No { get; set; }

        public DateTime Date_Of_Joining { get; set; }

        public string Personal_Email { get; set; }

        public string Office_Email { get; set; }

        public int Gender { get; set; }

        public bool System_User_Flag { get; set; }

        public string User_Name { get; set; }

        public string Password { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }


        #region Additional Fields

        public List<AccessFunctionInfo> Access_Functions { get; set; }

        public string Gender_Str 
        {
            get
            {
                return ((GenderType)Gender).ToString();
            }
            set
            {
                Gender_Str = value;
            }
        }

        public List<UserRoleInfo> User_Roles { get; set; }

        public string Role_Ids
        {
            get;
            set;
        }

        #endregion
    }
}
