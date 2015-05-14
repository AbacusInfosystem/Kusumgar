using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDataAccess;

namespace KusumgarModel
{
    public class DefectTypeManager
    {

        public List<DefectTypeInfo> GetDefectTypes()
        {
            List<DefectTypeInfo> defectTypes = new List<DefectTypeInfo>();
           
            DefectTypeRepo dRepo = new DefectTypeRepo();
            
            defectTypes = dRepo.GetDefectTypes();
            
            return defectTypes;

        }

        public List<DefectTypeInfo> GetDefectTypeByName(string defectType)
        {
            List<DefectTypeInfo> defectTypes = new List<DefectTypeInfo>();
           
            DefectTypeRepo dRepo = new DefectTypeRepo();
           
            defectTypes = dRepo.GetDefectTypeByName(defectType);
            
            return defectTypes;
        }

       public void Insert(DefectTypeInfo defect)
        {
            DefectTypeRepo dRepo = new DefectTypeRepo();

            dRepo.Insert(defect);
        }

       public DefectTypeInfo GetDefectTypeById(int defectTypeId)
       {
           DefectTypeInfo defectInfo = new DefectTypeInfo();

           DefectTypeRepo dRepo = new DefectTypeRepo();

           defectInfo = dRepo.GetDefectTypeById(defectTypeId);

           return defectInfo;
       }
     
        public void Update(DefectTypeInfo defect)
        {
            DefectTypeRepo dRepo = new DefectTypeRepo();
           
            dRepo.Update(defect);
        }

    }
}
