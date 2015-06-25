using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KusumgarBusinessEntities.Common;


namespace KusumgarBusinessEntities
{
    public class StateInfo
    {
        public StateInfo()
        {
          //  State_Entity = new M_State();
        }

       // public M_State State_Entity { get; set; }

        public int StateId { get; set; }

        public int NationId { get; set; }

        public string StateName { get; set; }

        public bool Is_Active { get; set; }

        public DateTime CreatedOn { get; set; }

        public int CreatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public int UpdatedBy { get; set; }

        #region Additional Fields

        public string Nation_Name { get; set; }

        #endregion
    }
}
