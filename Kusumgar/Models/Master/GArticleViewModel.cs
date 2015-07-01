using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using KusumgarBusinessEntities;

using KusumgarBusinessEntities.Common;

namespace Kusumgar.Models
{
    public class GArticleViewModel
    {
        public GArticleViewModel()
        {
            Friendly_Message = new List<FriendlyMessageInfo>();

            Pager = new PaginationInfo();

            G_Article = new GArticleInfo();

            G_Articles = new List<GArticleInfo>();

            Attribute_Codes = new List<AttributeCodeInfo>();

            Filter = new G_Article_Filter();
        }

        public List<FriendlyMessageInfo> Friendly_Message { get; set; }

        public PaginationInfo Pager { get; set; }

        public GArticleInfo G_Article { get; set; }

        public List<GArticleInfo> G_Articles { get; set; }

        public List<AttributeCodeInfo> Attribute_Codes { get; set; }

        public G_Article_Filter Filter { get; set; }
    }

    public class G_Article_Filter
    {
        public string Full_Code { get; set; }

        public int Yarn_Type_Id { get; set; }

        public int G_Article_Id { get; set; }
    }

}