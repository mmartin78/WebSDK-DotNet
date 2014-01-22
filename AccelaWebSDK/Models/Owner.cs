using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class Owner
    {
        public string primary { get; set; }
        public double refOwnerId { get; set; }
        public int id { get; set; }
        public string city { get; set; }
        public string title { get; set; }
        public RecordId recordId { get; set; }
        public string mailPostalCode { get; set; }
        public State state { get; set; }
        public MailCountry mailCountry { get; set; }
        public string postalCode { get; set; }
        public string email { get; set; }
        public string status { get; set; }
        public MailState mailState { get; set; }
        public string fax { get; set; }
        public string faxCountryCode { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string taxId { get; set; }
        public string phone { get; set; }
        public Address address { get; set; }
        public string fullName { get; set; }
        public MailAddress mailAddress { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string mailCity { get; set; }
        public string phoneCountryCode { get; set; }
        public Country country { get; set; }
        public string mailAddress1 { get; set; }
        public string mailAddress3 { get; set; }
        public string mailAddress2 { get; set; }
    }

    public class MailCountry
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class MailState
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class MailAddress
    {
        public string city { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public State state { get; set; }
        public Country country { get; set; }
        public string postalCode { get; set; }
    }
}
