using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class BankDetailsInfo
    {
        public BankDetailsInfo()
        {
            Bank_Details_Entity = new Bank_Details();
        }

        public Bank_Details Bank_Details_Entity { get; set; }
    }
}
