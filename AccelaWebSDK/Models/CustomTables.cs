using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class Rows
    {
        public string id { get; set; }
        public string action { get; set; }
        public Dictionary<string, string> fields { get; set; }
    }

    public class CustomTables
    {
        public string id { get; set; }
        public List<Rows> rows { get; set; }
    }
}
