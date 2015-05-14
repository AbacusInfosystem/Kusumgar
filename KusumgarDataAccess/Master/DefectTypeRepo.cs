using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using KusumgarBusinessEntities;
using System.Data;
using System.Data.SqlClient;

namespace KusumgarDataAccess
{
    public class DefectTypeRepo
    {
        private string _sqlCon = string.Empty;

        public DefectTypeRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["ProjectTestDB"].ToString();
        }

        public List<DefectTypeInfo> GetDefectTypes()
        {
            List<DefectTypeInfo> retVal = new List<DefectTypeInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();
                   
                    using (SqlCommand command = new SqlCommand("GetDefectTypes_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                DefectTypeInfo defectTypeItem = new DefectTypeInfo();

                                GetValuesFromDataReader(dataReader, defectTypeItem);

                                retVal.Add(defectTypeItem);
                            }
                        }

                        dataReader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return retVal;
        }
 
        private static void GetValuesFromDataReader(SqlDataReader dataReader, DefectTypeInfo defectType)
        {
            defectType.DefectTypeId = Convert.ToInt32(dataReader["DefectTypeId"]);
            defectType.DefectTypeName = Convert.ToString(dataReader["DefectTypeName"]);
            defectType.Status = Convert.ToBoolean(dataReader["Status"]);
       }

        public List<DefectTypeInfo> GetDefectTypeByName(string defectTypeName)
        {
            List<DefectTypeInfo> retVal = new List<DefectTypeInfo>();

            
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();
 
                    using (SqlCommand command = new SqlCommand("GetDefectTypeByName_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@DefectTypeName", defectTypeName));

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                
                                DefectTypeInfo defectTypeItem = new DefectTypeInfo();

                                GetValuesFromDataReader(dataReader, defectTypeItem);

                                retVal.Add(defectTypeItem);
                            }
                        }

                        dataReader.Close();
                    }
                }
            }
           

            return retVal;
        }

        public void Insert(DefectTypeInfo defectType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("InsertDefectType_sp", con))
                    {
                        SetValuesInDefectType(command, defectType, "Insert");

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private SqlCommand SetValuesInDefectType(SqlCommand command, DefectTypeInfo defectType, string mode)
        {
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@DefectTypeName", defectType.DefectTypeName));

            command.Parameters.Add(new SqlParameter("@Status", defectType.Status));


            if (mode=="Update")
            {
                command.Parameters.Add(new SqlParameter("@DefectTypeId", defectType.DefectTypeId));

            }

            return command;
        }

        public DefectTypeInfo GetDefectTypeById(int defectTypeId)
        {
            DefectTypeInfo retVal = new DefectTypeInfo();
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetDefectTypeById_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@DefectTypeId", defectTypeId));

                        SqlDataReader dataReader = command.ExecuteReader();


                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                GetValuesFromDataReader(dataReader, retVal);
                            }
                        }

                        dataReader.Close();

                    }
                }

            }
            catch (Exception ex)
            {
                  throw ex;
            }

            return retVal;
        }

        public void Update(DefectTypeInfo defectType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("UpdateDefectType_sp", con))
                    {
                        SetValuesInDefectType(command, defectType, "Update");

                        command.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception ex)
            {
               throw ex;
            }

        }
     
    }
}

