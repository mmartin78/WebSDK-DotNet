using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class BirthCity
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class BirthRegion
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class Relation
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class Primary
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class ContactType
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class Salutation
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class Gender
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class PreferredChannel
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class ContactAddress
    {
        public string city { get; set; }
        public string postalCode { get; set; }
        public Country country { get; set; }
        public State state { get; set; }
        public string addressLine2 { get; set; }
        public string addressLine3 { get; set; }
        public string addressLine1 { get; set; }
    }

    public class ContactFilter : Contact { }

    public class Contact
    {
        public string comment { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
        public string suffix { get; set; }
        public string isPrimary { get; set; }
        public string birthDate { get; set; }
        public string fax { get; set; }
        public string socialSecurityNumber { get; set; }
        public string individualOrOrganization { get; set; }
        public Salutation salutation { get; set; }
        public string federalEmployerId { get; set; }
        public string phone1 { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public RecordId recordId { get; set; }
        public string tradeName { get; set; }
        public ContactType type { get; set; }
        public string email { get; set; }
        public string postOfficeBox { get; set; }
        public string phone3CountryCode { get; set; }
        public string phone3 { get; set; }
        public string phone2 { get; set; }
        public string faxCountryCode { get; set; }
        public string businessName { get; set; }
        public string referenceContactId { get; set; }
        public string phone1CountryCode { get; set; }
        public string phone2CountryCode { get; set; }
        public ContactAddress address { get; set; }
        public string fullName { get; set; }
        public string firstName { get; set; }
        public Gender gender { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public Relation relation { get; set; }
        public PreferredChannel preferredChannel { get; set; }
        public BirthCity birthCity { get; set; }
        public BirthRegion birthRegion { get; set; }
    }
}
