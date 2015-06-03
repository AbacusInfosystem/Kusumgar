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
        public List<DefectTypeInfo> Get_Defect_Types(PaginationInfo Pager)
        {
            List<DefectTypeInfo> defectTypes = new List<DefectTypeInfo>();
           
            DefectTypeRepo dRepo = new DefectTypeRepo();

            defectTypes = dRepo.Get_Defect_Types(Pager);
            
            return defectTypes;

        }

        public List<DefectTypeInfo> Get_Defect_Type_By_Name(string Defect_Type_Name,PaginationInfo Pager)
        {
            List<DefectTypeInfo> defectTypes = new List<DefectTypeInfo>();
           
            DefectTypeRepo dRepo = new DefectTypeRepo();

            defectTypes = dRepo.Get_Defect_Type_By_Name(Defect_Type_Name, Pager);
            
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

        public List<DefectTypeInfo> Get_Defect_Types_By_Id(int Defect_Type_Id, PaginationInfo pager)
        {
            List<DefectTypeInfo> defectTypes = new List<DefectTypeInfo>();

            DefectTypeRepo dRepo = new DefectTypeRepo();

            defectTypes = dRepo.Get_Defect_Types_By_Id(Defect_Type_Id, pager);

            return defectTypes;
        }
    }
}
