using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class Professional
    {
        public string comment { get; set; }
        public ProfessionnalLicenseType licenseType { get; set; }
        public string licenseNumber { get; set; }
        public string suffix { get; set; }
        public string primary { get; set; }
        public string businessName2 { get; set; }
        public string expirationDate { get; set; }
        public Salutation salutation { get; set; }
        public string federalEmployerId { get; set; }
        public string originalIssueDate { get; set; }
        public string id { get; set; }
        public string licenseBoard { get; set; }
        public string city { get; set; }
        public EntityPK entityPK { get; set; }
        public string title { get; set; }
        public RecordId recordId { get; set; }
        public string referenceLicenseId { get; set; }
        public string middleName { get; set; }
        public State state { get; set; }
        public Template template { get; set; }
        public string phone3 { get; set; }
        public string postalCode { get; set; }
        public string email { get; set; }
        public string postOfficeBox { get; set; }
        public string fax { get; set; }
        public string address3 { get; set; }
        public string phone2 { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string phone1 { get; set; }
        public string birthDate { get; set; }
        public string fullName { get; set; }
        public string maskedSsn { get; set; }
        public string serviceProviderCode { get; set; }
        public string firstName { get; set; }
        public Gender gender { get; set; }
        public LicensingBoard licensingBoard { get; set; }
        public string lastName { get; set; }
        public string businessLicense { get; set; }
        public string businessName { get; set; }
        public Country country { get; set; }
    }

    public class ProfessionnalLicenseType
    {
        public string text { get; set; }
        public string value { get; set; }
    }

    public class EntityPK
    {
        public int entityId { get; set; }
        public string entityKey { get; set; }
    }

    public class LicensingBoard
    {
        public string text { get; set; }
        public string value { get; set; }
    }
}
