using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;
using KusumgarDatabaseEntities;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace KusumgarDataAccess
{
   public class AttributeCodeRepo
    {
        SQLHelperRepo _sqlRepo;

        public AttributeCodeRepo()
        {
            _sqlRepo = new SQLHelperRepo();
        }

        public List<AttributeCodeInfo> Get_Attribute_Codes(ref PaginationInfo pager)
        {
            List<AttributeCodeInfo> retVal = new List<AttributeCodeInfo>();
            
            DataTable dt = _sqlRepo.ExecuteDataTable(null, StoredProcedures.Get_Attribute_Codes_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                retVal.Add(Get_Attribute_Code_Values(dr));
            }
          
            return retVal;
        }

        public void Insert(AttributeCodeInfo attributeCode)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Attribute_Code(attributeCode), StoredProcedures.Insert_Attribute_Code_sp.ToString(), CommandType.StoredProcedure);
        }

        public List<AttributeCodeInfo> Get_Attribute_Codes_By_Attribute_Name(int attributeId,ref PaginationInfo pager)
        {
            List<AttributeCodeInfo> retVal = new List<AttributeCodeInfo>();
            
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Attribute_Id", attributeId));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Attribute_Code_By_Attribute_Name_sp.ToString(), CommandType.StoredProcedure);

            foreach (DataRow dr in CommonMethods.GetRows(dt, ref pager))
            {
                retVal.Add(Get_Attribute_Code_Values(dr));
            }
            
            return retVal;
        }
       
        public AttributeCodeInfo Get_Attribute_Code_By_Id(int attributeCodeId)
        {
            AttributeCodeInfo retVal = new AttributeCodeInfo();
           
            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Attribute_Code_Id", attributeCodeId));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Attribute_Code_By_Id_sp.ToString(), CommandType.StoredProcedure);

            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;
                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    retVal=(Get_Attribute_Code_Values(dr));
                }
            }

            return retVal;
        }

        public void Update(AttributeCodeInfo attributeCode)
        {
            _sqlRepo.ExecuteNonQuery(Set_Values_In_Attribute_Code(attributeCode), StoredProcedures.Update_Attribute_Code_sp.ToString(), CommandType.StoredProcedure);

        }

        private List<SqlParameter> Set_Values_In_Attribute_Code(AttributeCodeInfo attributeCodes)
        {
            List<SqlParameter> sqlParamList = new List<SqlParameter>();

            sqlParamList.Add(new SqlParameter("@Status", attributeCodes.Status));
            
            sqlParamList.Add(new SqlParameter("@Attribute_Id", attributeCodes.Attribute_Id));

            sqlParamList.Add(new SqlParameter("@Attribute_Code_Name", attributeCodes.Attribute_Code_Name));

            sqlParamList.Add(new SqlParameter("@Code", attributeCodes.Code));

            sqlParamList.Add(new SqlParameter("@UpdatedBy", attributeCodes.UpdatedBy));

            if (attributeCodes.Attribute_Code_Id == 0)
            {
                sqlParamList.Add(new SqlParameter("@CreatedBy", attributeCodes.CreatedBy));
            }
            if (attributeCodes.Attribute_Code_Id != 0)
            {
                sqlParamList.Add(new SqlParameter("@Attribute_Code_Id", attributeCodes.Attribute_Code_Id));
            }

            return sqlParamList;
        }

        private AttributeCodeInfo Get_Attribute_Code_Values(DataRow dr)
        {
            AttributeCodeInfo attributeCodes = new AttributeCodeInfo();

            attributeCodes.Attribute_Code_Id = Convert.ToInt32(dr["Attribute_Code_Id"]);

            attributeCodes.Attribute_Id = Convert.ToInt32(dr["Attribute_Id"]);

            attributeCodes.Attribute_Code_Name = Convert.ToString(dr["Attribute_Code_Name"]);

            attributeCodes.Code = Convert.ToString(dr["Code"]);

            attributeCodes.Status = Convert.ToBoolean(dr["Status"]);

            attributeCodes.Attribute_Name = LookupInfo.GetAttributeNames()[attributeCodes.Attribute_Id];

            return attributeCodes;
        }

        public List<AttributeCodeInfo> Get_Grid_By_Attrinute_Code_Name(int attributeId)
        {
            List<AttributeCodeInfo> retVal = new List<AttributeCodeInfo>();

            List<SqlParameter> sqlParams = new List<SqlParameter>();

            sqlParams.Add(new SqlParameter("@Attribute_Id", attributeId));

            DataTable dt = _sqlRepo.ExecuteDataTable(sqlParams, StoredProcedures.Get_Attribute_Code_By_Attribute_Name_sp.ToString(), CommandType.StoredProcedure);


            if (dt != null && dt.Rows.Count > 0)
            {
                int count = 0;

                List<DataRow> drList = new List<DataRow>();

                drList = dt.AsEnumerable().ToList();

                count = drList.Count();

                foreach (DataRow dr in drList)
                {
                    retVal.Add(Get_Attribute_Code_Values(dr));
                }
            }
            return retVal;

        }
   }
}
