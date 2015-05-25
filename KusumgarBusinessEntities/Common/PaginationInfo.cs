using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KusumgarBusinessEntities.Common
{
  public class PaginationInfo
    {


        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalRecords { get; set; }

        public bool IsPagingRequired { get; set; }

        public string PageHtmlString { get; set; }
   
        public PaginationInfo()
        {
            IsPagingRequired = true;

            PageSize =10;

            CurrentPage = 0;
        }
    }
}
