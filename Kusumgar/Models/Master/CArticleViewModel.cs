using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;

using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class CArticleViewModel
    {
        public CArticleInfo CArticle { get; set; }
        public List<CArticleInfo> CArticles { get; set; }
        public List<QualityInfo> Quality_List { get; set; }
        public List<AttributeCodeInfo> Attribute_Codes { get; set; }
        public List<FriendlyMessageInfo> Friendly_Message { get; set; }
        public PaginationInfo Pager { get; set; }
        public CArticle_Filter Filter { get; set; }
        public bool Is_Primary { get; set; }

        public CArticleViewModel()
        {
            CArticle = new CArticleInfo();
            CArticles = new List<CArticleInfo>();
            Quality_List = new List<QualityInfo>();
            Attribute_Codes = new List<AttributeCodeInfo>();
            Friendly_Message = new List<FriendlyMessageInfo>();
            Pager = new PaginationInfo();
            Filter = new CArticle_Filter();
        }
    }

    public class CArticle_Filter
    {
        public string Full_Code { get; set; }
        public int Yarn_Type_Id { get; set; }
        public int CArticle_Id { get; set; }
    }
}