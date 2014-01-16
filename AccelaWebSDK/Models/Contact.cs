using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class Relation
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class ContactAddress
    {
        public State state { get; set; }
        public string city { get; set; }
    }

    public class ContactType
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class Contact
    {
        public string startDate { get; set; }
        public string email { get; set; }
        public string lastName { get; set; }
        public Relation relation { get; set; }
        public string firstName { get; set; }
        public RecordId recordId { get; set; }
        public string typeFlag { get; set; }
        public string phoneNumber1 { get; set; }
        public Address address { get; set; }
        public ContactType type { get; set; }
        public string primary { get; set; }
        public string id { get; set; }
    }
}
