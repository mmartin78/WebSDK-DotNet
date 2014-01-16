using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class Category
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class GuidesheetItem
    {
    }

    public class Document
    {
        public string serviceProviderCode { get; set; }
        public string entityID { get; set; }
        public string entityType { get; set; }
        public string fileName { get; set; }
        public string source { get; set; }
        public Category category { get; set; }
        public Status status { get; set; }
        public string type { get; set; }
        public string modifiedBy { get; set; }
        public int id { get; set; }
        public string department { get; set; }
        public string uploadedDate { get; set; }
        public string uploadedBy { get; set; }
        public string statusDate { get; set; }
        public string modifiedDate { get; set; }
        public GuidesheetItem guidesheetItem { get; set; }
        public int size { get; set; }
    }

}
