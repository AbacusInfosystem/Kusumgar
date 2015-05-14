using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDataAccess;

namespace KusumgarModel
{
 public  class DefectManager
    {

     public List<DefectInfo> GetDefects()
        {
             List<DefectInfo> defectTypes = new List<DefectInfo>();
             DefectRepo dRepo = new DefectRepo();
             defectTypes = dRepo.GetDefects();
             return defectTypes;
         }

        public void Insert(DefectInfo defect)
        {
            DefectRepo dRepo = new DefectRepo();
            dRepo.Insert(defect);
        }

        public DefectInfo GetDefectById(int defectId)
        {
            DefectInfo defect = new DefectInfo();
            DefectRepo dRepo = new DefectRepo();
            defect = dRepo.GetDefectById(defectId);
            return defect;
        }

        public void Update(DefectInfo defect)
        {
            DefectRepo dRepo = new DefectRepo();
            dRepo.Update(defect);
        }

        public List<DefectTypeInfo> GetDefectTypes()
        {
            List<DefectTypeInfo> defectTypes = new List<DefectTypeInfo>();
            DefectRepo dRepo = new DefectRepo();
            defectTypes = dRepo.GetDefectTypes();
            return defectTypes;
        }

        public List<DefectInfo> GetDefectByName(string defectName)
        {
            List<DefectInfo> defectNames = new List<DefectInfo>();
            DefectRepo dRepo = new DefectRepo();
            defectNames = dRepo.GetDefectByName(defectName);
            return defectNames;
         }

        public List<DefectInfo> GetDefectByType(int defectType)
        {
             List<DefectInfo> defectTypes = new List<DefectInfo>();
             DefectRepo dRepo = new DefectRepo();
             defectTypes = dRepo.GetDefectByType(defectType);
            return defectTypes;
         }

        public List<DefectInfo> GetDefectByTypeByName(int defectType, string defectName)
        {
            List<DefectInfo> defectTypes = new List<DefectInfo>();
            DefectRepo dRepo = new DefectRepo();
            defectTypes = dRepo.GetDefectByTypeByName(defectType, defectName);
            return defectTypes;
        }

    }
}
