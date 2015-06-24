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
   public class PArticleManager
    {

        public PArticleRepo _pArticleRepo;

        public PArticleManager()
        {
            _pArticleRepo = new PArticleRepo();
        }

       public List<QualityInfo> Get_Quality(ref PaginationInfo pager)
       {
           return _pArticleRepo.Get_Quality(ref pager);
          
       }

       public List<PArticleInfo> Get_PArticles(ref PaginationInfo pager)
       {
           return _pArticleRepo.Get_PArticles(ref pager);
       }

       public PArticleInfo Get_PArticles_By_Id(int pArticle_Id)
       {
           return _pArticleRepo.Get_PArticles_By_Id(pArticle_Id);
       }

       public int Insert_PArticle(PArticleInfo pArticle)
       {
           return _pArticleRepo.Insert_PArticle(pArticle);
       }

       public void Update_PArticle(PArticleInfo pArticle)
       {
           _pArticleRepo.Update_PArticle(pArticle);
       }

       public List<AutocompleteInfo> Get_PArticles_By_Full_Code(string full_Code)
       {
           return _pArticleRepo.Get_PArticles_By_Full_Code(full_Code);
       }
     
       public List<PArticleInfo> Get_PArticles_By_Id(int pArticle_Id, ref PaginationInfo pager)
       {
           return _pArticleRepo.Get_PArticles_By_Id(pArticle_Id,ref pager);
       }

       public List<PArticleInfo> Get_PArticles_By_Yarn_Type_Id(int yarn_Type_Id, ref PaginationInfo pager)
       {
           return _pArticleRepo.Get_PArticles_By_Yarn_Type_Id(yarn_Type_Id,ref  pager);
       }

       public List<PArticleInfo> Get_P_Articles_By_PArticle_Id_Yarn_Type(int pArticle_Id, int yarn_Type_Id, ref PaginationInfo pager)
       {

           return _pArticleRepo.Get_P_Articles_By_PArticle_Id_Yarn_Type(pArticle_Id,yarn_Type_Id,ref pager);
       }

    }
}
