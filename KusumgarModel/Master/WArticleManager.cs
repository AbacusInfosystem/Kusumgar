using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities;
using KusumgarDataAccess;
using KusumgarBusinessEntities.Common;

namespace KusumgarModel
{
    public class WArticleManager
    {
        public WArticleRepo _wArticleRepo;

        public WArticleManager()
        {
            _wArticleRepo = new WArticleRepo();
        }

        public int Insert_WArticle(WArticleInfo wArticle)
        {
            return _wArticleRepo.Insert_WArticle(wArticle);
        }

        public void Update_WArticle(WArticleInfo wArticle)
        {
            _wArticleRepo.Update_WArticle(wArticle);
        }

        public List<WArticleInfo> Get_WArticles(ref PaginationInfo pager)
        {
            return _wArticleRepo.Get_WArticles(ref pager);
        }

        public WArticleInfo Get_WArticle_By_Id(int wArticle_Id)
        {
            return _wArticleRepo.Get_WArticle_By_Id(wArticle_Id);
        }

        public List<WArticleInfo> Get_WArticles_By_WArticle_Id(int wArticle_Id, ref PaginationInfo pager)
        {
            return _wArticleRepo.Get_WArticles_By_WArticle_Id(wArticle_Id, ref pager);
        }

        public List<WArticleInfo> Get_WArticles_By_Yarn_Type_Id(int yarn_Type_Id, ref PaginationInfo pager)
        {
            return _wArticleRepo.Get_WArticles_By_Yarn_Type_Id(yarn_Type_Id, ref pager);
        }

        public List<WArticleInfo> Get_W_Articles_By_WArticle_Id_Yarn_Type(int wArticle_Id, int yarn_Type_Id, ref PaginationInfo pager)
        {
            return _wArticleRepo.Get_W_Articles_By_WArticle_Id_Yarn_Type(wArticle_Id, yarn_Type_Id, ref pager);
        }

        public List<AutocompleteInfo> Get_WArticles_By_Full_Code(string full_Code)
        {
            return _wArticleRepo.Get_WArticles_By_Full_Code(full_Code);
        }

        public List<QualityInfo> Get_Quality(ref PaginationInfo pager)
        {
            return _wArticleRepo.Get_Quality(ref pager);
        }
    }
}
