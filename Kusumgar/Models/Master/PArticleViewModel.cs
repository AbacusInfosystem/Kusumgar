using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class PArticleViewModel
    {
        public PArticleViewModel()
        {
            PArticles = new List<PArticleInfo>();

            PArticle = new PArticleInfo();

            Friendly_Message = new List<FriendlyMessageInfo>();

            Pager = new PaginationInfo();

            Filter = new PArticle_Filter();

            Attribute_Codes = new List<AttributeCodeInfo>();

            Quality_Nos = new List<QualityInfo>();

          
        }

        public List<PArticleInfo> PArticles { get; set; }

        public PArticleInfo PArticle { get; set; }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public PArticle_Filter Filter { get; set; }

        public PaginationInfo Pager { get; set; }

        public List<AttributeCodeInfo> Attribute_Codes { get; set; }

        public List<QualityInfo> Quality_Nos { get; set; }
    }
    public class PArticle_Filter
    {
        public string Full_Code { get; set; }

        public int Yarn_Type_Id { get; set; }

        public int PArticle_Id { get; set; }

       
    }


}