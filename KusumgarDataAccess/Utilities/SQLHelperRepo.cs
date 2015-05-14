using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace KusumgarDataAccess
{
    public class SQLHelperRepo
    {
        private string _sqlCon = string.Empty;

        public SQLHelperRepo()
        {
            _sqlCon = ConfigurationManager.ConnectionStrings["KusumgarDB"].ToString();
        }

        public DataSet ExecuteDataSet(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType)
        {
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
                    {

                        //SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                        sqlCmd.CommandType = cmdType;
                        sqlCmd.CommandTimeout = 300;
                        if (sqlParams != null)
                        {
                            foreach (SqlParameter sqlPrm in sqlParams)
                            {
                                if (sqlPrm.Value == null)
                                    sqlPrm.Value = DBNull.Value;
                            }
                            sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                        }

                        SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
                        sqlDA.Fill(ds);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ds;
        }

        public DataTable ExecuteDataTable(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(_sqlCon))
                {
                    using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
                    {

                        //SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                        sqlCmd.CommandType = cmdType;
                        sqlCmd.CommandTimeout = 300;
                        if (sqlParams != null)
                        {
                            foreach (SqlParameter sqlPrm in sqlParams)
                            {
                                if (sqlPrm.Value == null)
                                    sqlPrm.Value = DBNull.Value;
                            }
                            sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                        }

                        SqlDataAdapter sqlDA = new SqlDataAdapter(sqlCmd);
                        sqlDA.Fill(dt);
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                throw sqlEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dt;
        }

        public SqlDataReader ExecuteDataReader(SqlConnection con, List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType)
        {
            SqlDataReader dr;
            
            try
            {
                using (con)
                {
                    //con.Open();
                    SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                    sqlCmd.CommandType = cmdType;
                    sqlCmd.CommandTimeout = 300;

                    if (sqlParams != null)
                    {
                        foreach (SqlParameter sqlPrm in sqlParams)
                        {
                            if (sqlPrm.Value == null)
                                sqlPrm.Value = DBNull.Value;
                        }
                        sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                    }

                    dr = sqlCmd.ExecuteReader();
                    //con.Close();
                }
            }
            catch (SqlException sqlEx)
            {
                if (con != null)
                    con.Close();

                throw sqlEx;
            }
            catch (Exception ex)
            {
                if (con != null)
                    con.Close();

                throw ex;
            }

            return dr;
        }

        public void ExecuteNonQuery(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                using (con = new SqlConnection(_sqlCon))
                {
                    con.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
                    {

                        //SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                        sqlCmd.CommandType = cmdType;

                        if (sqlParams != null)
                        {
                            foreach (SqlParameter sqlPrm in sqlParams)
                            {
                                if (sqlPrm.Value == null)
                                    sqlPrm.Value = DBNull.Value;
                            }
                            sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                        }

                        sqlCmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (con != null)
                    con.Close();

                throw sqlEx;
            }
            catch (Exception ex)
            {
                if (con != null)
                    con.Close();

                throw ex;
            }
        }

        public object ExecuteScalerObj(List<SqlParameter> sqlParams, string sqlQuery, CommandType cmdType)
        {
            SqlConnection con = new SqlConnection();

            object result = 0;
            try
            {
                using (con = new SqlConnection(_sqlCon))
                {
                    con.Open();
                    using (SqlCommand sqlCmd = new SqlCommand(sqlQuery, con))
                    {

                        //SqlCommand sqlCmd = new SqlCommand(sqlQuery, con);
                        sqlCmd.CommandType = cmdType;

                        if (sqlParams != null)
                        {
                            foreach (SqlParameter sqlPrm in sqlParams)
                            {
                                if (sqlPrm.Value == null)
                                    sqlPrm.Value = DBNull.Value;
                            }
                            sqlCmd.Parameters.AddRange(sqlParams.ToArray());
                        }

                        result = sqlCmd.ExecuteScalar();
                        con.Close();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                if (con != null)
                    con.Close();

                throw sqlEx;
            }
            catch (Exception ex)
            {
                if (con != null)
                    con.Close();

                throw ex;
            }
            return result;
        }
    }
}
