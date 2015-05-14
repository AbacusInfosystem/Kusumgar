using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDataAccess;

namespace KusumgarModel
{
   public class AttributeCodeManager
    {

       public List<AttributeCodeInfo> GetAttributeCodes()
        {
            List<AttributeCodeInfo> attributeCodes = new List<AttributeCodeInfo>();

            AttributeCodeRepo dRepo = new AttributeCodeRepo();

            attributeCodes = dRepo.GetAttributeCodes();

            return attributeCodes;

        }

       public List<AttributeCodeInfo> GetAttributeCodesByAttributeId(int attributeId)
        {
            List<AttributeCodeInfo> attributeCodes = new List<AttributeCodeInfo>();

            AttributeCodeRepo dRepo = new AttributeCodeRepo();

            attributeCodes = dRepo.GetAttributeCodesByAttributeId(attributeId);

            return attributeCodes;
        }

        public void Insert(AttributeCodeInfo attributeCode)
        {
            AttributeCodeRepo dRepo = new AttributeCodeRepo();
            dRepo.Insert(attributeCode);
        }

        public AttributeCodeInfo GetAttributeCodeById(int attributeCodeId)
        {
            AttributeCodeInfo attributeCodeInfo = new AttributeCodeInfo();

            AttributeCodeRepo dRepo = new AttributeCodeRepo();

            attributeCodeInfo = dRepo.GetAttributeCodeById(attributeCodeId);

            return attributeCodeInfo;
        }

        public void Update(AttributeCodeInfo attributeCode)
        {
            AttributeCodeRepo dRepo = new AttributeCodeRepo();

            dRepo.Update(attributeCode);
        }

    }
}
