using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class StreetSuffix
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class State
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class Country
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class Address
    {
        public string serviceProviderCode { get; set; }
        public string streetName { get; set; }
        public StreetSuffix streetSuffix { get; set; }
        public string city { get; set; }
        public Country country { get; set; }
        public int houseNumberStart { get; set; }
        public RecordId recordId { get; set; }
        public string primary { get; set; }
        public string postalCode { get; set; }
        public int id { get; set; }
    }

}
