using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDataAccess;
using KusumgarBusinessEntities.Common;

namespace KusumgarModel
{
    public class YArticleManager
    {
       public YArticleRepo _yArticleRepo { get; set; }

       public YArticleManager()
        {
            _yArticleRepo = new RoleRepo();
        }

         public List<YArticleInfo> Get_YArticles(ref PaginationInfo pager)
        {

        }
    }
}
