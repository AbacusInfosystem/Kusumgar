using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class YArticleViewModel
    {
        public YArticleViewModel()
        {
            YArticles = new List<YArticleInfo>();

            YArticle = new YArticleInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Pager = new PaginationInfo();

            Filter = new YArticle_Filter();

            Attribute_Codes = new List<AttributeCodeInfo>();

            Is_Primary = false;
        }

        public bool Is_Primary { get; set; }

        public List<YArticleInfo> YArticles { get; set; }

        public YArticleInfo YArticle { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public YArticle_Filter Filter { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<AttributeCodeInfo> Attribute_Codes { get; set; }
    }

    public class YArticle_Filter
    {
        public string Full_Code { get; set; }

        public int Yarn_Type_Id { get; set; }

        public int YArticle_Id { get; set; }
    }
}
