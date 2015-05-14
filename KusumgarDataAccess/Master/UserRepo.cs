using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarDatabaseEntities;
using System.Data;
using System.Net;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;

namespace KusumgarDataAccess
{
    public class UserRepo
    {
        SQLHelperRepo sqlRepo;
        public SQLHelperRepo _sqlHelper { get; set; }

        public UserRepo()
        {
            sqlRepo = new SQLHelperRepo();
            _sqlHelper = new SQLHelperRepo();
        }

        public List<UserInfo> Get_User_List(ref PaginationInfo Pager)
        {
            List<UserInfo> UserList = new List<UserInfo>();

            DataTable dt = sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Users_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                if (Pager.IsPagingRequired)
                {
                    drList = drList.Skip(Pager.CurrentPage * Pager.PageSize).Take(Pager.PageSize).ToList();
                }

                Pager.TotalRecords = count;

                int pages = (Pager.TotalRecords + Pager.PageSize - 1) / Pager.PageSize;

                Pager.TotalPages = pages;

                foreach (DataRow dr in drList)
                {
                    UserInfo user = new UserInfo();

                    user.UserEntity.UserId = Convert.ToInt32(dr["UserId"]);

                    user.UserEntity.First_Name = Convert.ToString(dr["First_Name"]);

                    user.UserEntity.Middle_Name = Convert.ToString(dr["Middle_Name"]);

                    user.UserEntity.Last_Name = Convert.ToString(dr["Last_Name"]);

                    user.UserEntity.Mobile_No1 = Convert.ToString(dr["Mobile_No1"]);

                    user.UserEntity.Mobile_No2 = Convert.ToString(dr["Mobile_No2"]);

                    user.UserEntity.Residence_Landline = Convert.ToString(dr["Residence_Landline"]);

                    user.UserEntity.Office_Landline = Convert.ToString(dr["Office_Landline"]);

                    user.UserEntity.Office_Address = Convert.ToString(dr["Office_Address"]);

                    user.UserEntity.Residence_Address = Convert.ToString(dr["Residence_Address"]);

                    user.UserEntity.Office_PinCode = Convert.ToString(dr["Office_PinCode"]);

                    user.UserEntity.Residence_PinCode = Convert.ToString(dr["Residence_PinCode"]);

                    user.UserEntity.Designtation = Convert.ToString(dr["Designtation"]);

                    user.UserEntity.Birth_Date = Convert.ToDateTime(dr["Birth_Date"]);

                    user.UserEntity.Fax_No = Convert.ToString(dr["Fax_No"]);

                    user.UserEntity.Date_Of_Joining = Convert.ToDateTime(dr["Date_Of_Joining"]);

                    user.UserEntity.Personal_Email = Convert.ToString(dr["Personal_Email"]);

                    user.UserEntity.Office_Email = Convert.ToString(dr["Office_Email"]);

                    user.UserEntity.Gender = Convert.ToInt32(dr["Gender"]);

                    user.UserEntity.System_User_Flag = Convert.ToBoolean(dr["System_User_Flag"]);

                    user.UserEntity.User_Name = Convert.ToString(dr["User_Name"]);

                    user.UserEntity.Password = Convert.ToString(dr["Password"]);

                    user.UserEntity.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

                    user.UserEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

                    user.UserEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

                    user.UserEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

                    user.UserEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

                    UserList.Add(user);
                }
            }

            return UserList;
        }

        public List<UserInfo> Get_User_List_By_Name(PaginationInfo Pager, string FirstName)
        {
            List<UserInfo> UserList = new List<UserInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@FirstName", FirstName));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Users_By_Name_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                if (Pager.IsPagingRequired)
                {
                    drList = drList.Skip(Pager.CurrentPage * Pager.PageSize).Take(Pager.PageSize).ToList();
                }

                Pager.TotalRecords = count;

                int pages = (Pager.TotalRecords + Pager.PageSize - 1) / Pager.PageSize;

                Pager.TotalPages = pages;

                foreach (DataRow dr in drList)
                {
                    UserInfo user = new UserInfo();

                    user.UserEntity.UserId = Convert.ToInt32(dr["UserId"]);

                    user.UserEntity.First_Name = Convert.ToString(dr["First_Name"]);

                    user.UserEntity.Middle_Name = Convert.ToString(dr["Middle_Name"]);

                    user.UserEntity.Last_Name = Convert.ToString(dr["Last_Name"]);

                    user.UserEntity.Mobile_No1 = Convert.ToString(dr["Mobile_No1"]);

                    user.UserEntity.Mobile_No2 = Convert.ToString(dr["Mobile_No2"]);

                    user.UserEntity.Residence_Landline = Convert.ToString(dr["Residence_Landline"]);

                    user.UserEntity.Office_Landline = Convert.ToString(dr["Office_Landline"]);

                    user.UserEntity.Office_Address = Convert.ToString(dr["Office_Address"]);

                    user.UserEntity.Residence_Address = Convert.ToString(dr["Residence_Address"]);

                    user.UserEntity.Office_PinCode = Convert.ToString(dr["Office_PinCode"]);

                    user.UserEntity.Residence_PinCode = Convert.ToString(dr["Residence_PinCode"]);

                    user.UserEntity.Designtation = Convert.ToString(dr["Designtation"]);

                    user.UserEntity.Birth_Date = Convert.ToDateTime(dr["Birth_Date"]);

                    user.UserEntity.Fax_No = Convert.ToString(dr["Fax_No"]);

                    user.UserEntity.Date_Of_Joining = Convert.ToDateTime(dr["Date_Of_Joining"]);

                    user.UserEntity.Personal_Email = Convert.ToString(dr["Personal_Email"]);

                    user.UserEntity.Office_Email = Convert.ToString(dr["Office_Email"]);

                    user.UserEntity.Gender = Convert.ToInt32(dr["Gender"]);

                    user.UserEntity.System_User_Flag = Convert.ToBoolean(dr["System_User_Flag"]);

                    user.UserEntity.User_Name = Convert.ToString(dr["User_Name"]);

                    user.UserEntity.Password = Convert.ToString(dr["Password"]);

                    user.UserEntity.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

                    user.UserEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

                    user.UserEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

                    user.UserEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

                    user.UserEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

                    UserList.Add(user);
                }
            }

            return UserList;
        }

        public UserInfo Get_User_By_UserId(int UserId)
        {
            UserInfo user = new UserInfo();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@UserId", UserId));

            DataSet ds = sqlRepo.ExecuteDataSet(sqlParams, StoredProcedures.Get_Users_By_Id_Sp.ToString(), CommandType.StoredProcedure);

            DataTable dt = ds.Tables[0];

            DataTable dt1 = ds.Tables[1];

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = dt.Rows.Count;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    user.UserEntity.UserId = Convert.ToInt32(dr["UserId"]);

                    user.UserEntity.First_Name = Convert.ToString(dr["First_Name"]);

                    user.UserEntity.Middle_Name = Convert.ToString(dr["Middle_Name"]);

                    user.UserEntity.Last_Name = Convert.ToString(dr["Last_Name"]);

                    user.UserEntity.Mobile_No1 = Convert.ToString(dr["Mobile_No1"]);

                    user.UserEntity.Mobile_No2 = Convert.ToString(dr["Mobile_No2"]);

                    user.UserEntity.Residence_Landline = Convert.ToString(dr["Residence_Landline"]);

                    user.UserEntity.Office_Landline = Convert.ToString(dr["Office_Landline"]);

                    user.UserEntity.Office_Address = Convert.ToString(dr["Office_Address"]);

                    user.UserEntity.Residence_Address = Convert.ToString(dr["Residence_Address"]);

                    user.UserEntity.Office_PinCode = Convert.ToString(dr["Office_PinCode"]);

                    user.UserEntity.Residence_PinCode = Convert.ToString(dr["Residence_PinCode"]);

                    user.UserEntity.Designtation = Convert.ToString(dr["Designtation"]);

                    user.UserEntity.Birth_Date = Convert.ToDateTime(dr["Birth_Date"]);

                    user.UserEntity.Fax_No = Convert.ToString(dr["Fax_No"]);

                    user.UserEntity.Date_Of_Joining = Convert.ToDateTime(dr["Date_Of_Joining"]);

                    user.UserEntity.Personal_Email = Convert.ToString(dr["Personal_Email"]);

                    user.UserEntity.Office_Email = Convert.ToString(dr["Office_Email"]);

                    user.UserEntity.Gender = Convert.ToInt32(dr["Gender"]);

                    user.UserEntity.System_User_Flag = Convert.ToBoolean(dr["System_User_Flag"]);

                    user.UserEntity.User_Name = Convert.ToString(dr["User_Name"]);

                    user.UserEntity.Password = Convert.ToString(dr["Password"]);

                    user.UserEntity.Is_Active = Convert.ToBoolean(dr["Is_Active"]);

                    user.UserEntity.CreatedOn = Convert.ToDateTime(dr["CreatedOn"]);

                    user.UserEntity.CreatedBy = Convert.ToInt32(dr["CreatedBy"]);

                    user.UserEntity.UpdatedOn = Convert.ToDateTime(dr["UpdatedOn"]);

                    user.UserEntity.UpdatedBy = Convert.ToInt32(dr["UpdatedBy"]);

                    foreach (DataRow dr1 in dt1.Rows)
                    {
                        UserRoleInfo user_role = new UserRoleInfo();

                        user_role.Role_Name = Convert.ToString(dr1["Role_Name"]);

                        user_role.UserRoleEntity.Role_Id = Convert.ToInt32(dr1["Role_Id"]);

                        user_role.UserRoleEntity.UserId = Convert.ToInt32(dr1["UserId"]);

                        user.UserRoleList.Add(user_role);

                    }
                }

            }

            return user;
        }

        public void Insert_User(UserInfo userInfo)
        {
            int UserId = 0;

            UserId = Convert.ToInt32(sqlRepo.ExecuteScalerObj(SetValues_In_User(userInfo), StoredProcedures.Insert_User_Sp.ToString(), CommandType.StoredProcedure));

            Insert_User_Role_Mapping(userInfo.Role_Ids, UserId);

        }

        public void Update_User(UserInfo userInfo)
        {
            sqlRepo.ExecuteNonQuery(SetValues_In_User(userInfo), StoredProcedures.Update_User_Sp.ToString(), CommandType.StoredProcedure);

            Insert_User_Role_Mapping(userInfo.Role_Ids, userInfo.UserEntity.UserId);
        }

        private List<SqlParameter> SetValues_In_User(UserInfo user)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            if (user.UserEntity.UserId != 0)
            {
                sqlParamList.Add(new SqlParameter("@UserId", user.UserEntity.UserId));
            }
            sqlParamList.Add(new SqlParameter("@First_Name", user.UserEntity.First_Name));
            sqlParamList.Add(new SqlParameter("@Middle_Name", user.UserEntity.Middle_Name));
            sqlParamList.Add(new SqlParameter("@Last_Name", user.UserEntity.Last_Name));
            sqlParamList.Add(new SqlParameter("@Mobile_No1", user.UserEntity.Mobile_No1));
            sqlParamList.Add(new SqlParameter("@Mobile_No2", user.UserEntity.Mobile_No2));
            sqlParamList.Add(new SqlParameter("@Residence_Landline", user.UserEntity.Residence_Landline));
            sqlParamList.Add(new SqlParameter("@Office_Landline", user.UserEntity.Office_Landline));
            sqlParamList.Add(new SqlParameter("@Office_Address", user.UserEntity.Office_Address));
            sqlParamList.Add(new SqlParameter("@Residence_Address", user.UserEntity.Residence_Address));
            sqlParamList.Add(new SqlParameter("@Office_PinCode", user.UserEntity.Office_PinCode));
            sqlParamList.Add(new SqlParameter("@Residence_PinCode", user.UserEntity.Residence_PinCode));
            sqlParamList.Add(new SqlParameter("@Designtation", user.UserEntity.Designtation));
            sqlParamList.Add(new SqlParameter("@Birth_Date", user.UserEntity.Birth_Date));
            sqlParamList.Add(new SqlParameter("@Fax_No", user.UserEntity.Fax_No));
            sqlParamList.Add(new SqlParameter("@Date_Of_Joining", user.UserEntity.Date_Of_Joining));
            sqlParamList.Add(new SqlParameter("@Personal_Email", user.UserEntity.Personal_Email));
            sqlParamList.Add(new SqlParameter("@Office_Email", user.UserEntity.Office_Email));
            sqlParamList.Add(new SqlParameter("@Gender", user.UserEntity.Gender));
            sqlParamList.Add(new SqlParameter("@System_User_Flag", user.UserEntity.System_User_Flag));
            sqlParamList.Add(new SqlParameter("@User_Name", user.UserEntity.User_Name));
            sqlParamList.Add(new SqlParameter("@Password", user.UserEntity.Password));
            sqlParamList.Add(new SqlParameter("@Is_Active", user.UserEntity.Is_Active));
            if (user.UserEntity.UserId == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", user.UserEntity.CreatedBy));
            }
            sqlParamList.Add(new SqlParameter("@UpdatedBy", user.UserEntity.UpdatedBy));

            return sqlParamList;
        }

        public bool Check_Existing_User(string User_Name)
        {
            bool check = false;

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@User_Name", User_Name));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Check_Existing_User_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = dt.Rows.Count;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    check = Convert.ToBoolean(dr["check_User"]);
                }
            }

            return check;
        }

        public void Insert_User_Role_Mapping(string Role_Ids, int UserId)
        {
            List<SqlParameter> sqlParam = new List<SqlParameter>();

            sqlParam.Add(new SqlParameter("@UserId", UserId));

            sqlRepo.ExecuteNonQuery(sqlParam, StoredProcedures.Delete_User_Role_By_UserId_Sp.ToString(), CommandType.StoredProcedure);
            
            foreach (var item in Role_Ids.Split(','))
            {
                List<SqlParameter> sqlParamList = new List<SqlParameter>();

                int CreatedBy = 1;
                int UpdatedBy = 1;

                sqlParamList.Add(new SqlParameter("@UserId", UserId));
                sqlParamList.Add(new SqlParameter("@RoleId", item));
                sqlParamList.Add(new SqlParameter("@CreatedBy", CreatedBy));
                sqlParamList.Add(new SqlParameter("@UpdatedBy", UpdatedBy));

                sqlRepo.ExecuteNonQuery(sqlParamList, StoredProcedures.Insert_User_Role_Sp.ToString(), CommandType.StoredProcedure);
            }

        }

        public string Get_User_Role_By_Id(int UserId)
        {
            string Role_Ids ="";

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@UserId", UserId));

            DataTable dt = sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_User_Role_By_UserId_Sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = dt.Rows.Count;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                foreach (DataRow dr in drList)
                {
                    Role_Ids = Convert.ToString(dr["Role_Id"]) + ", ";
                }

                Role_Ids = Role_Ids.TrimEnd(',');
            }

            return Role_Ids;
        }
    }
}
