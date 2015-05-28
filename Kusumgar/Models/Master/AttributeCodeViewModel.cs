using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class AttributeCodeViewModel
    {
         public AttributeCodeViewModel()
            {
                Attribute_Code = new AttributeCodeInfo();

                Attribute_Code_Grid = new List<AttributeCodeInfo>();
               
                Edit_Mode = new Attribute_Code_Edit_Mode();

                Filter = new Attribute_Code_Filter();

                Pager = new PaginationInfo();

                Friendly_Message = new List<FriendlyMessageInfo>();

            }

         public AttributeCodeInfo Attribute_Code { get; set; }

         public List<AttributeCodeInfo> Attribute_Code_Grid { get; set; }

         public PaginationInfo Pager { get; set; }

         public Attribute_Code_Edit_Mode Edit_Mode { get; set; }

         public Attribute_Code_Filter Filter { get; set; }

         public List<FriendlyMessageInfo> Friendly_Message { get; set; }

         public class Attribute_Code_Edit_Mode
            {
                public int Attribute_Code_Id { get; set; }
            
            }

         public class Attribute_Code_Filter
           {
                public int Attribute_Id{ get; set; }
             
           }

        }
    }
