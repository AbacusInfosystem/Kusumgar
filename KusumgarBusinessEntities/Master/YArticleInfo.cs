using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarBusinessEntities
{
    public class YArticleInfo
    {
        public YArticleInfo()
        {
            YArticle_Entity = new M_Y_Article();
        }

        public M_Y_Article YArticle_Entity { get; set; }
       
    }
}
