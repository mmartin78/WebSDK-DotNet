using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class Department
    {
        public string id { get; set; }
        public string serviceProviderCode { get; set; }
        public string office { get; set; }
        public string section { get; set; }
        public string bureau { get; set; }
        public string division { get; set; }
        public string value { get; set; }
        public string group { get; set; }
        public string agency { get; set; }
        public string text { get; set; }
    }

    public class UserProfile
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string serviceProviderCode { get; set; }
        public Department department { get; set; }
        public string fullName { get; set; }
        public string id { get; set; }
        public string value { get; set; }
    }
}
