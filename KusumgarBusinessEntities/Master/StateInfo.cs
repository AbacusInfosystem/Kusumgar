using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;


namespace KusumgarBusinessEntities
{
    public class StateInfo
    {
        public StateInfo()
        {
            State_Entity = new M_State();
        }

        public M_State State_Entity { get; set; }

        public string Nation_Name { get; set; }
    }
}
