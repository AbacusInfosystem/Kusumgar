using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KusumgarBusinessEntities.Common
{
    public class AttachmentsInfo
    {
        public long Attachment_Id { get; set; }

        public int Ref_Id { get; set; }

        public int Ref_Type { get; set; }

        public string Document_Name { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        #region Additional Fields

        public string label 
        {
            get
            {
                return Document_Name;
            }
            set
            {
                label = value;
            }
        }

        public long key
        {
            get
            {
                return Attachment_Id;
            }
            set
            {
                key = value;    
            }
        }

        public string Ref_Type_Str
        {
            get
            {
                 return ((RefType)Ref_Type).ToString();
            }
            set
            {
                Ref_Type_Str = value;
            }
        }

        #endregion
    }
}
