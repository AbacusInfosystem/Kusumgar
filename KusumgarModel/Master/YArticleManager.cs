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
    public class YArticleManager
    {
        public Y_ArticleRepo yArticleRepo;

        public YArticleManager()
        {
            yArticleRepo = new Y_ArticleRepo();
        }

        public List<YArticleInfo> Get_YArticles(ref PaginationInfo pager)
        {
            return yArticleRepo.Get_YArticles(ref pager);
        }

        public List<YArticleInfo> Get_YArticles_By_Id(int yArticle_Id, ref PaginationInfo pager)
        {
            return yArticleRepo.Get_YArticles_By_Id(yArticle_Id, ref pager);
        }

         public List<YArticleInfo> Get_YArticles_By_Yarn_Type_Id(int yarn_Type_Id, ref PaginationInfo pager)
         {
             return yArticleRepo.Get_YArticles_By_Yarn_Type_Id(yarn_Type_Id, ref pager);
         }

         public List<YArticleInfo> Get_Y_Articles_By_YArticle_Id_Yarn_Type(int yArticle_Id, int yarn_Type_Id, ref PaginationInfo pager)
         {
             return yArticleRepo.Get_Y_Articles_By_YArticle_Id_Yarn_Type(yArticle_Id, yarn_Type_Id, ref pager);
         }

         public YArticleInfo Get_YArticle_By_Id(int yArticleId)
         {
             return yArticleRepo.Get_YArticle_By_Id(yArticleId);
         }

        public int Insert_YArticle(YArticleInfo yArticle)
         {
             return yArticleRepo.Insert_YArticle(yArticle);
         }

         public void Update_YArticle(YArticleInfo yArticle)
        {
             yArticleRepo.Update_YArticle(yArticle);
        }

         public List<AutocompleteInfo> Get_YArticles_By_Full_Code(string full_Code)
         {
             return yArticleRepo.Get_YArticles_By_Full_Code(full_Code);
         }

         public List<AutocompleteInfo> Get_Work_Stations_By_Code_Purpose(string work_Station_Code)
         {
             return yArticleRepo.Get_Work_Stations_By_Code_Purpose(work_Station_Code);
         }

    }
}
