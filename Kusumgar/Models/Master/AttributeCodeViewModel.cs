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
                AttributeCode = new AttributeCodeInfo();

                AttributeCodeGrid = new List<AttributeCodeInfo>();
               
                EditMode = new AttributeCodeEditMode();

                Filter = new AttributeCodeFilter();

                Pager = new PaginationInfo();

                Pager.PageSize = 5;

                Pager.IsPagingRequired = true;

            }

         public AttributeCodeInfo AttributeCode { get; set; }

         public List<AttributeCodeInfo> AttributeCodeGrid { get; set; }

          
            public PaginationInfo Pager { get; set; }

            public AttributeCodeEditMode EditMode { get; set; }

            public AttributeCodeFilter Filter { get; set; }

            public class AttributeCodeEditMode
            {
                public int AttributeCodeId { get; set; }

            }

            public class AttributeCodeFilter
            {
                public int AttributeId{ get; set; }
               

            }

        }
    }
