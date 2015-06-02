using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KusumgarBusinessEntities;
using KusumgarDataAccess;

namespace KusumgarModel
{
    public class LoginManager
    {
        public UserInfo AuthenticateUser(string userName, string password)
        {
            LoginRepo loginRepo = new LoginRepo();

            return loginRepo.AuthenticateUser(userName, password);
        }

        public UserInfo SetSession(string username, string password)
        {
            LoginRepo loginRepo = new LoginRepo();

            UserInfo retVal = new UserInfo();

            retVal = loginRepo.SetSession(username, password);

            return retVal;
        }
    }
}
