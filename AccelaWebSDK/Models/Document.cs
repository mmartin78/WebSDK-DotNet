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

    public class Comment
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class CheckListItem
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class GuidesheetItem
    {
        public Status status { get; set; }
        public Comment comment { get; set; }
        public string isMajorViolation { get; set; }
        public string serviceProviderCode { get; set; }
        public string checklist { get; set; }
        public int score { get; set; }
        public int checkListId { get; set; }
        public CheckListItem checkListItem { get; set; }
        public string isCritical { get; set; }
        public string customId { get; set; }
        public int id { get; set; }
        public int displayOrder { get; set; }
    }

    public class Document
    {
        public Status status { get; set; }
        public Category category { get; set; }
        public string description { get; set; }
        public string serviceProviderCode { get; set; }
        public string source { get; set; }
        public string uploadedDate { get; set; }
        public string entityType { get; set; }
        public int id { get; set; }
        public string statusDate { get; set; }
        public string virtualFolders { get; set; }
        public GuidesheetItem guidesheetItem { get; set; }
        public string modifiedBy { get; set; }
        public string modifiedDate { get; set; }
        public string department { get; set; }
        public string entityID { get; set; }
        public string fileName { get; set; }
        public string type { get; set; }
        public string uploadedBy { get; set; }
        public double size { get; set; }
    }

}
