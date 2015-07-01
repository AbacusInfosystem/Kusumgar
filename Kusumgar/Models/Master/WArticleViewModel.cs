using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;

using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class WArticleViewModel
    {
        public WArticleInfo WArticle { get; set; }
        public List<WArticleInfo> WArticles { get; set; }
        public List<QualityInfo> Quality_List { get; set; }
        public List<AttributeCodeInfo> Attribute_Codes { get; set; }
        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
        public PaginationInfo Pager { get; set; }
        public WArticle_Filter Filter { get; set; }
        public bool Is_Primary { get; set; }

        public WArticleViewModel()
        {
            WArticle = new WArticleInfo();
            WArticles = new List<WArticleInfo>();
            Quality_List = new List<QualityInfo>();
            Attribute_Codes = new List<AttributeCodeInfo>();
            Friendly_Message = new List<FriendlyMessageInfo>();
            Pager = new PaginationInfo();
            Filter = new WArticle_Filter();
        }
    }

    public class WArticle_Filter
    {
        public string Full_Code { get; set; }
        public int Yarn_Type_Id { get; set; }
        public int WArticle_Id { get; set; }
    }
}