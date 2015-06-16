using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDataAccess;
using KusumgarDatabaseEntities;
using KusumgarBusinessEntities.Common;

namespace KusumgarModel
{
    public class GArticleManager
    {
        public GArticleRepo _garticleRepo;

        public GArticleManager()
        {
            _garticleRepo = new GArticleRepo();
        }

        public List<QualityInfo> Get_Qualities(ref PaginationInfo pager)
        {
            return _garticleRepo.Get_Qualities(ref pager);
        }

        public List<VendorInfo> Get_Vendors(ref PaginationInfo pager)
        {
            return _garticleRepo.Get_Vendors(ref pager);
        }

        public int Insert_G_Article(GArticleInfo gArticle)
        {
            return _garticleRepo.Insert_G_Article(gArticle);
        }

        public void Update_G_Article(GArticleInfo gArticle)
        {
            _garticleRepo.Update_G_Article(gArticle);
        }

        public List<GArticleInfo> Get_G_Articles(ref PaginationInfo pager)
        {
            return _garticleRepo.Get_G_Articles(ref pager);
        }

        public List<GArticleInfo> Get_G_Articles_By_G_Article_Id_By_Yarn_Type_Id(int g_Article_Id, int yarn_Type_Id, ref PaginationInfo pager)
        {
            return _garticleRepo.Get_G_Articles_By_G_Article_Id_By_Yarn_Type_Id(g_Article_Id, yarn_Type_Id, ref pager);
        }

        public List<GArticleInfo> Get_G_Articles_By_G_Article_Id(int g_Article_Id, ref PaginationInfo pager)
        {
            return _garticleRepo.Get_G_Articles_By_G_Article_Id(g_Article_Id, ref pager);
        }

        public List<GArticleInfo> Get_G_Articles_By_Yarn_Type_Id(int yarn_Type_Id, ref PaginationInfo pager)
        {
            return _garticleRepo.Get_G_Articles_By_Yarn_Type_Id(yarn_Type_Id, ref pager);
        }

        public GArticleInfo Get_G_Article_By_Id(int g_Article_Id)
        {
            return _garticleRepo.Get_G_Article_By_Id(g_Article_Id);
        }

        public List<AutocompleteInfo> Get_G_Articles_By_Full_Code(string full_Code)
        {
            return _garticleRepo.Get_G_Articles_By_Full_Code(full_Code);
        }

    }
}
