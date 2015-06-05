using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDataAccess;
using KusumgarBusinessEntities.Common;

namespace KusumgarModel
{
    public class DefectTypeManager
    {
        public List<DefectTypeInfo> Get_Defect_Types(ref PaginationInfo pager)
        {
            List<DefectTypeInfo> defectTypes = new List<DefectTypeInfo>();
           
            DefectTypeRepo dRepo = new DefectTypeRepo();

            defectTypes = dRepo.Get_Defect_Types(ref pager);
            
            return defectTypes;

        }

        public void Insert(DefectTypeInfo defect)
        {
            DefectTypeRepo dRepo = new DefectTypeRepo();

            dRepo.Insert(defect);
        }

        public DefectTypeInfo Get_Defect_Type_By_Id(int Defect_Type_Id)
       {
           DefectTypeInfo defectInfo = new DefectTypeInfo();

           DefectTypeRepo dRepo = new DefectTypeRepo();

           defectInfo = dRepo.Get_Defects_Type_By_Id(Defect_Type_Id);

           return defectInfo;
       }
     
        public void Update(DefectTypeInfo defect)
        {
            DefectTypeRepo dRepo = new DefectTypeRepo();
           
            dRepo.Update(defect);
        }

        public List<AutocompleteInfo> Get_Defect_Type_AutoComplete(string defect_Type_Name)
        {
            DefectTypeRepo dRepo = new DefectTypeRepo();

            return dRepo.Get_Defect_Type_AutoComplete(defect_Type_Name);
        }

        public List<DefectTypeInfo> Get_Defect_Types_By_Id(int Defect_Type_Id, ref PaginationInfo pager)
        {
            List<DefectTypeInfo> defectTypes = new List<DefectTypeInfo>();

            DefectTypeRepo dRepo = new DefectTypeRepo();

            defectTypes = dRepo.Get_Defect_Types_By_Id(Defect_Type_Id, ref pager);

            return defectTypes;
        }
    }
}
