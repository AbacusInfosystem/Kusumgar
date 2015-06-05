using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KusumgarBusinessEntities.Common
{
    public class AttachmentsInfo
    {
        public int Attachment_Id { get; set; }

        public int Attachment_Type_Id { get; set; }

        public int Ref_Id { get; set; }

        public bool Is_Active { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

    }
}
