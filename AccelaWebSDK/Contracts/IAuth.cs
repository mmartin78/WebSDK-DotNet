using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK.Models;

namespace Accela.Web.SDK
{
    public interface IAuth
    {
        void Login(string redirectUrl, string scope, string agencyName, string agencyEnvironment);
        CurrentUserProfile GetCurrentUserProfile(string redirectUrl);
        UserProfile GetUserProfile(string token);
        Token GetToken(string redirectUrl, string code);
    }
}
