using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class CurrentUserProfile
    {
        public UserProfile UserProfile { get; set; }
        public Token Token { get; set; }
        public string AgencyName { get; set; }
        public string AgencyEnvironment { get; set; }
    }
}
