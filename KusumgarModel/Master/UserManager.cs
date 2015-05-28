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
    public class UserManager
    {
        public UserRepo _userRepo { get; set; }

        public UserManager()
        {
            _userRepo = new UserRepo();
        }

        public List<UserInfo> Get_Users(ref PaginationInfo Pager)
        {
            return _userRepo.Get_Users(ref Pager);
        }
        //public List<UserInfo> Get_User_List(PaginationInfo Pager)
        //{
        //    //return _userRepo.Get_User_List(Pager);
        //    return _userRepo.Get_User_List(new PaginationInfo());
        //}

        public List<UserInfo> Get_Users_By_Name(ref PaginationInfo Pager, string FirstName)
        {
            return _userRepo.Get_Users_By_Name(ref Pager, FirstName);
        }

        public UserInfo Get_User_By_User_Id(int UserId)
        {
            return _userRepo.Get_User_By_User_Id(UserId);
        }

        public void Insert_User(UserInfo userInfo)
        {
            _userRepo.Insert_User(userInfo);
        }

        public void Update_User(UserInfo userInfo)
        {
            _userRepo.Update_User(userInfo);
        }

         public bool Check_Existing_User( string User_Name)
         {
            return _userRepo.Check_Existing_User( User_Name);
         }

         public List<AutocompleteInfo> Get_Users_By_Name(string first_Name)
         {
             return _userRepo.Get_Users_By_Name(first_Name);
         }

    }
}
