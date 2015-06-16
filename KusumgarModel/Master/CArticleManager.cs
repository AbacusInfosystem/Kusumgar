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
    public class CArticleManager
    {
        public CArticleRepo _cArticleRepo;

        public CArticleManager()
        {
            _cArticleRepo = new CArticleRepo();
        }

        public int Insert_CArticle(CArticleInfo cArticle)
        {
            return _cArticleRepo.Insert_CArticle(cArticle);
        }

        public void Update_CArticle(CArticleInfo cArticle)
        {
            _cArticleRepo.Update_CArticle(cArticle);
        }

        public List<CArticleInfo> Get_CArticles(ref PaginationInfo pager)
        {
            return _cArticleRepo.Get_CArticles(ref pager);
        }

        public CArticleInfo Get_CArticle_By_Id(int cArticle_Id)
        {
            return _cArticleRepo.Get_CArticle_By_Id(cArticle_Id);
        }

        public List<CArticleInfo> Get_CArticles_By_CArticle_Id(int cArticle_Id, ref PaginationInfo pager)
        {
            return _cArticleRepo.Get_CArticles_By_CArticle_Id(cArticle_Id, ref pager);
        }

        public List<CArticleInfo> Get_CArticles_By_Yarn_Type_Id(int yarn_Type_Id, ref PaginationInfo pager)
        {
            return _cArticleRepo.Get_CArticles_By_Yarn_Type_Id(yarn_Type_Id, ref pager);
        }

        public List<CArticleInfo> Get_C_Articles_By_CArticle_Id_Yarn_Type(int cArticle_Id, int yarn_Type_Id, ref PaginationInfo pager)
        {
            return _cArticleRepo.Get_C_Articles_By_CArticle_Id_Yarn_Type(cArticle_Id, yarn_Type_Id, ref pager);
        }

        public List<AutocompleteInfo> Get_CArticles_By_Full_Code(string full_Code)
        {
            return _cArticleRepo.Get_CArticles_By_Full_Code(full_Code);
        }

        public List<QualityInfo> Get_Quality(ref PaginationInfo pager)
        {
            return _cArticleRepo.Get_Quality(ref pager);
        }
    }
}
