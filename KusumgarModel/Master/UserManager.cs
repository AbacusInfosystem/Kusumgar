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

        public List<UserInfo> Get_Users(ref PaginationInfo pager)
        {
            return _userRepo.Get_Users(ref pager);
        }

        public List<UserInfo> Get_Users_By_Name(ref PaginationInfo pager, string first_Name)
        {
            return _userRepo.Get_Users_By_Name(pager, first_Name);
        }

        public UserInfo Get_User_By_User_Id(int user_Id)
        {
            return _userRepo.Get_User_By_User_Id(user_Id);
        }

        public void Insert_User(UserInfo user)
        {
            _userRepo.Insert_User(user);
        }

        public void Update_User(UserInfo user)
        {
            _userRepo.Update_User(user);
        }

         public bool Check_Existing_User( string user_Name)
         {
             return _userRepo.Check_Existing_User(user_Name);
         }
    }
}
