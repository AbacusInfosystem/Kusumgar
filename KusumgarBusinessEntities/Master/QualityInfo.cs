using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;

namespace KusumgarBusinessEntities
{
  public  class QualityInfo:M_Quality
    {
      
        public QualityInfo()
        {
            
        }
        public string Yarn_Type_Name { get; set; }
    }
}

