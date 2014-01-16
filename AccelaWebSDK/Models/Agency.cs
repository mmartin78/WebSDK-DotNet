using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class Agency
    {
        public string name { get; set; }
        public string serviceProviderCode { get; set; }
        public bool enabled { get; set; }
        public string display { get; set; }
        public bool hostedACA { get; set; }
        public string iconName { get; set; }
    }
}
