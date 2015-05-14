using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace KusumgarDataAccess
{
   public class AttributeCodeRepo
    {
        private string _sqlCon = string.Empty;

        public AttributeCodeRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["ProjectTestDB"].ToString();
        }

        public List<AttributeCodeInfo> GetAttributeCodes()
        {
            List<AttributeCodeInfo> retVal = new List<AttributeCodeInfo>();

            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetAttributeCodes_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                AttributeCodeInfo attributeCodeItem = new AttributeCodeInfo();

                                GetValuesFromDataReader(dataReader, attributeCodeItem);

                                retVal.Add(attributeCodeItem);
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

        private static void GetValuesFromDataReader(SqlDataReader dataReader, AttributeCodeInfo attributeCode)
        {

            attributeCode.AttributeCodeId = Convert.ToInt32(dataReader["AttributeCodeId"]);
            attributeCode.AttributeId = Convert.ToInt32(dataReader["AttributeId"]);
            attributeCode.AttributeCodeName = Convert.ToString(dataReader["AttributeCodeName"]);
            attributeCode.Code = Convert.ToString(dataReader["Code"]);
            attributeCode.Status = Convert.ToBoolean(dataReader["Status"]);
            attributeCode.AttributeName = LookupInfo.GetAttributeNames()[attributeCode.AttributeId];

        }

        public void Insert(AttributeCodeInfo attributeCode)
        {
            try
            {
               using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("InsertAttributeCode_sp", con))
                    {
                        SetValuesInAttributeCode(command, attributeCode, "Insert");

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private SqlCommand SetValuesInAttributeCode(SqlCommand command, AttributeCodeInfo attributeCode, string mode)
        {
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(new SqlParameter("@AttributeId", attributeCode.AttributeId));
            command.Parameters.Add(new SqlParameter("@AttributeCodeName", attributeCode.AttributeCodeName));
            command.Parameters.Add(new SqlParameter("@Code", attributeCode.Code));
            command.Parameters.Add(new SqlParameter("@Status", attributeCode.Status));
        
            if (mode=="Update")
            {
                command.Parameters.Add(new SqlParameter("@AttributeCodeId", attributeCode.AttributeCodeId));
            }

            return command;
        }

        public List<AttributeCodeInfo> GetAttributeCodesByAttributeId(int attributeId)
        {
            List<AttributeCodeInfo> retVal = new List<AttributeCodeInfo>();

            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetAttributeCodeByAttributeName_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@AttributeId", attributeId));

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {

                                AttributeCodeInfo attributeCodeItem = new AttributeCodeInfo();

                                GetValuesFromDataReader(dataReader, attributeCodeItem);

                                retVal.Add(attributeCodeItem);
                            }
                        }

                        dataReader.Close();
                    }
                }
            }

            return retVal;
        }
       
        public AttributeCodeInfo GetAttributeCodeById(int attributeCodeId)
        {
            AttributeCodeInfo retVal = new AttributeCodeInfo();
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("GetAttributeCodeById_sp", con))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(new SqlParameter("@AttributeCodeId", attributeCodeId));

                        SqlDataReader dataReader = command.ExecuteReader();

                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                AttributeCodeInfo attributeCode= new AttributeCodeInfo();

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

        public void Update(AttributeCodeInfo attributeCode)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    con.Open();

                    using (SqlCommand command = new SqlCommand("UpdateAttributeCode_sp", con))
                    {
                        SetValuesInAttributeCode(command, attributeCode, "Update");

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
