using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK.Models
{
    public class RecordId
    {
        public string serviceProviderCode { get; set; }
        public string id { get; set; }
        public int trackingId { get; set; }
        public string customId { get; set; }
    }

    public class RecordType
    {
        public string group { get; set; }
        public string type { get; set; }
        public string subType { get; set; }
        public string category { get; set; }
        public string id { get; set; }
        public string value { get; set; }
        public string text { get; set; }
        public string module { get; set; }
        public string display { get; set; }
        public bool createable { get; set; }
        public bool accessable { get; set; }
        public bool editable { get; set; }
        public bool searchable { get; set; }
    }

    public class ConstructionType
    {
    }

    public class Priority
    {
    }

    public class Severity
    {
    }

    public class ReportedChannel
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class StatusReason
    {
    }

    public class ReportedType
    {
    }

    public class Status
    {
        public string value { get; set; }
        public string text { get; set; }
    }

    public class Record
    {
        public string serviceProviderCode { get; set; }
        public string id { get; set; }
        public string customId { get; set; }
        public int trackingId { get; set; }
        public string name { get; set; }
        public string module { get; set; }
        public RecordType type { get; set; }
        public string openedDate { get; set; }
        public bool isPublicOwned { get; set; }
        public ConstructionType constructionType { get; set; }
        public Priority priority { get; set; }
        public Severity severity { get; set; }
        public ReportedChannel reportedChannel { get; set; }
        public StatusReason statusReason { get; set; }
        public string statusDate { get; set; }
        public string createdBy { get; set; }
        public int totalJobCost { get; set; }
        public int undistributedCost { get; set; }
        public int totalFee { get; set; }
        public int totalPay { get; set; }
        public int balance { get; set; }
        public bool isBooking { get; set; }
        public bool isInfraction { get; set; }
        public bool isMisdemeanor { get; set; }
        public bool isOffenseWitnessed { get; set; }
        public bool isDefendantSignature { get; set; }
        public string initiatedProduct { get; set; }
        public ReportedType reportedType { get; set; }
        public Status status { get; set; }
        public string reportedDate { get; set; }
        public string recordClass { get; set; }
        public int? estimatedProductionUnit { get; set; }
        public int? actualProductionUnit { get; set; }
        public string description { get; set; }
    }
}

//{
//    "status": 200,
//    "result": [
//        {
//            "License Duration": null,
//            "Age": null,
//            "Service Dog": null,
//            "Spayed/Neutered": null,
//            "Dominant Color": null,
//            "Secondary Color": null,
//            "_Id_": "LIC_PET_LIC&GENERAL INFORMATION",
//            "Pet Name": null,
//            "Weight": null,
//            "Microchip Number": null,
//            "Breed": null,
//            "Gender": null,
//            "Birthdate": null,
//            "Pet License Tag Number": null,
//            "Species": null
//        },
//        {
//            "Vaccination Expiration Date": null,
//            "Rabies Tag Number": null,
//            "Rabies Vaccination Date": null,
//            "Vaccination Lot Number": null,
//            "_Id_": "LIC_PET_LIC&VACCINATION INFORMATION"
//        },
//        {
//            "Danger Level": null,
//            "Reason For Designation": null,
//            "_Id_": "LIC_PET_LIC&PET INFORMATION"
//        },
//        {
//            "Date Diagnosed": null,
//            "Documented Health Condition": null,
//            "Date of Onset Clinical Signs": null,
//            "_Id_": "LIC_PET_LIC&RABIES VACC EXEMPTION REQUESTS"
//        }
//    ]
//}
