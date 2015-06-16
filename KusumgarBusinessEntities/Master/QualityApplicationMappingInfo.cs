using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;

namespace KusumgarBusinessEntities
{
    public class QualityApplicationMappingInfo
    {
        public int Quality_Application_Id { get; set; }

        public int Quality_Id { get; set; }

        public int Application_Name_Id { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        #region Additional Fields

        public string Application_Name { get; set; }

        #endregion
    }

 
}
