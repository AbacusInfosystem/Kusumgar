using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarDatabaseEntities;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarCrossCutting.Logging;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace KusumgarDataAccess
{
    public class LoginRepo
    {
        private string _sqlCon = string.Empty;

        public LoginRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();
        }

        public UserInfo AuthenticateUser(string userName, string password)
        {
            UserInfo retVal = new UserInfo();

            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand(StoredProcedures.Authenticate_User_sp.ToString(), con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@User_Name", userName));

                        command.Parameters.Add(new SqlParameter("@Password", password));

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {

                                retVal.UserEntity.UserId = Convert.ToInt32(dataReader["UserId"]);

                                retVal.UserEntity.Is_Active = Convert.ToBoolean(dataReader["Is_Active"]);
                            }
                        }

                        dataReader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("UserRepo - AuthenticateLoginCredentials: " + ex.ToString());
            }

            return retVal;
        }

        public UserInfo SetSession(string userName, string password)
        {
            UserInfo userInfo = new UserInfo();

            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand(StoredProcedures.Get_Session_Data_sp.ToString(), con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@User_Name", userName));

                        command.Parameters.Add(new SqlParameter("@Password", password));

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                userInfo.UserEntity.UserId = Convert.ToInt32(dataReader["UserId"]);

                                //userInfo.Employee.EmployeeId = Convert.ToInt32(dataReader["EmployeeId"]);

                                userInfo.UserEntity.First_Name = Convert.ToString(dataReader["First_Name"]);

                                userInfo.UserEntity.Middle_Name = Convert.ToString(dataReader["Middle_Name"]);

                                userInfo.UserEntity.Last_Name = Convert.ToString(dataReader["Last_Name"]);
                            }
                        }

                        if (dataReader.NextResult())
                        {
                            while (dataReader.Read())
                            {
                                userInfo.UserRoleList.Add(
                                    new UserRoleInfo()
                                    {
                                        UserRoleEntity = new M_User_Role_Mapping // while removing DatabaseEntities, let update RoleInfo. Lets add Role_Name field in RoleInfo only.
                                        {
                                            Role_Id = Convert.ToInt32(dataReader["Role_Id"])
                                        },
                                        Role_Name = Convert.ToString(dataReader["Role_Name"])
                                    });
                            }
                        }

                        if (dataReader.NextResult())
                        {
                            while (dataReader.Read())
                            {
                                userInfo.AccessFunctions.Add(new M_Access_Function { Access_Fuction_Id = Convert.ToInt32(dataReader["Access_Fuction_Id"]), Access_Function_Name = Convert.ToString(dataReader["Access_Function_Name"]) });
                            }
                        }

                        //if (dataReader.NextResult())
                        //{
                        //    while (dataReader.Read())
                        //    {
                        //        userInfo.TemplateCategories.Add(new TemplateCategoryInfo() { TemplateCategoryId = Convert.ToInt32(dataReader["TemplateCategoryId"]), TemplateCategoryName = LookUps.GetTemplateCategory()[Convert.ToInt32(dataReader["TemplateCategoryId"])] });
                        //    }
                        //}
                        dataReader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Error("UserRepo - SetSession: " + ex.ToString());
            }

            return userInfo;
        }
    }
}
