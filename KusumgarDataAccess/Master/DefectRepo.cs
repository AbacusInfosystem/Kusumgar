using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace KusumgarDataAccess
{
 public class DefectRepo
    {
        private string _sqlCon = string.Empty;

        public DefectRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["ProjectTestDB"].ToString();
        }

        public List<DefectInfo> GetDefects()
        {
            List<DefectInfo> retVal = new List<DefectInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();
                   
                    using (SqlCommand command = new SqlCommand("GetDefects_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                DefectInfo defectItem = new DefectInfo();

                                GetValuesFromDataReader(dataReader, defectItem);

                                retVal.Add(defectItem);
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
  
        private static void GetValuesFromDataReader(SqlDataReader dataReader, DefectInfo defect)
        {

            defect.DefectId = Convert.ToInt32(dataReader["DefectId"]);
            defect.DefectTypeId = Convert.ToInt32(dataReader["DefectTypeId"]);
            defect.DefectTypeName = Convert.ToString(dataReader["DefectTypeName"]);
            defect.DefectCode = Convert.ToString(dataReader["DefectCode"]);
            defect.DefectName = Convert.ToString(dataReader["DefectName"]);
            defect.Status = Convert.ToBoolean(dataReader["Status"]);

        }
     
        public void Insert(DefectInfo defectType)
        {
            try
            {
               using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("InsertDefect_sp", con))
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

        private SqlCommand SetValuesInDefectType(SqlCommand command, DefectInfo defect, string mode)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@DefectTypeName", defect.DefectTypeName));
            command.Parameters.Add(new SqlParameter("@DefectCode", defect.DefectCode));
            command.Parameters.Add(new SqlParameter("@DefectName", defect.DefectName));
            command.Parameters.Add(new SqlParameter("@Status", defect.Status));
        
            if (mode=="Update")
            {
                command.Parameters.Add(new SqlParameter("@DefectId", defect.DefectId));
            }

            return command;
        }

        public List<DefectTypeInfo> GetDefectTypes()
        {
            List<DefectTypeInfo> retVal = new List<DefectTypeInfo>();
            using (SqlConnection con = new SqlConnection(_sqlCon))
            {
                con.Open();

                using (SqlCommand command = new SqlCommand("ListDefectTypes_sp", con))
                {
                    command.CommandType = CommandType.StoredProcedure;
                   
                    SqlDataReader dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            DefectTypeInfo defect = new DefectTypeInfo();
                            defect.DefectTypeId = Convert.ToInt32(dataReader["DefectTypeId"]);
                            defect.DefectTypeName = Convert.ToString(dataReader["DefectTypeName"]);
                            retVal.Add(defect);

                        }
                    }

                    dataReader.Close();
                }
            }
            return retVal;
        }

        public DefectInfo GetDefectById(int defectId)
        {
            DefectInfo retVal = new DefectInfo();
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetDefectById_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@DefectId", defectId));

                        SqlDataReader dataReader = command.ExecuteReader();


                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                DefectInfo defect = new DefectInfo();

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

        public void Update(DefectInfo defectType)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("UpdateDefect_sp", con))
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
   
        public List<DefectInfo> GetDefectByName(string defectName)
         {
            List<DefectInfo> retVal = new List<DefectInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetDefectByName_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@DefectName", defectName));

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                
                                DefectInfo defectTypeItem = new DefectInfo();
                             
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

        public List<DefectInfo> GetDefectByType(int defectType)
        {
            List<DefectInfo> retVal = new List<DefectInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetDefectByType_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@DefectTypeName", defectType));

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                               
                                DefectInfo defectTypeItem = new DefectInfo();

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

        public List<DefectInfo> GetDefectByTypeByName(int defectType,string defectName)
        {
            List<DefectInfo> retVal = new List<DefectInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetDefectByNameByType_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@DefectTypeName", defectType));
                        command.Parameters.Add(new SqlParameter("@DefectName", defectName));

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                               DefectInfo defectTypeItem = new DefectInfo();

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

    }
}
