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
 public  class DefectManager
    {
        public List<DefectInfo> Get_Defects(ref PaginationInfo pager)
        {
             List<DefectInfo> defectTypes = new List<DefectInfo>();
             
             DefectRepo dRepo = new DefectRepo();
             
             defectTypes = dRepo.Get_Defects(ref pager);
             
             return defectTypes;
         }

        public void Insert(DefectInfo defect)
        {
            DefectRepo dRepo = new DefectRepo();
            
            dRepo.Insert(defect);
        }

        public DefectInfo Get_Defect_By_Id(int Defect_Id)
        {
            DefectInfo defects = new DefectInfo();
            
            DefectRepo dRepo = new DefectRepo();
            
            defects = dRepo.Get_Defects_By_Id(Defect_Id);
            
            return defects;
        }

        public void Update(DefectInfo defect)
        {
            DefectRepo dRepo = new DefectRepo();
            
            dRepo.Update(defect);
        }

        public List<DefectInfo> Get_Defect_By_Name(int Defect_Id, ref PaginationInfo pager)
        {
            List<DefectInfo> defectTypes = new List<DefectInfo>();
            
            DefectRepo dRepo = new DefectRepo();

            defectTypes = dRepo.Get_Defects_By_Name(Defect_Id, ref pager);
            
            return defectTypes;
         }

        public List<DefectInfo> Get_Defect_By_Type(int Defect_Type_Id, ref PaginationInfo pager)
        {
             List<DefectInfo> defectTypes = new List<DefectInfo>();
             
             DefectRepo dRepo = new DefectRepo();
             
             defectTypes = dRepo.Get_Defect_By_Type(Defect_Type_Id,ref pager);
            
             return defectTypes;
         }

        public List<DefectInfo> Get_Defect_By_Type_By_Name(int Defect_Type_Id, int Defect_Id,ref PaginationInfo pager)
        {
            List<DefectInfo> defectTypes = new List<DefectInfo>();
            
            DefectRepo dRepo = new DefectRepo();
            
            defectTypes = dRepo.Get_Defect_By_Type_By_Name(Defect_Type_Id, Defect_Id,ref pager);
            
            return defectTypes;
        }

        public List<DefectTypeInfo> Get_Defect_Types()
        {
            List<DefectTypeInfo> defectTypes = new List<DefectTypeInfo>();
            
            DefectRepo dRepo = new DefectRepo();
            
            defectTypes = dRepo.Get_Defect_Type();
            
            return defectTypes;
        }

        public List<DefectInfo> Get_Grid_By_Defect_Type(int Defect_Type_Id)
        {
            List<DefectInfo> defectTypes = new List<DefectInfo>();

             DefectRepo dRepo = new DefectRepo();
            
            defectTypes=dRepo.Get_Grid_By_Defect_Type(Defect_Type_Id);
   
            return defectTypes;
        }

        public List<AutocompleteInfo> Get_Defect_AutoComplete(string defect_Name)
        {
            DefectRepo dRepo = new DefectRepo();

            return dRepo.Get_Defect_AutoComplete(defect_Name);
        }
    }
}
 