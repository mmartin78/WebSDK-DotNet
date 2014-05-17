using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK;
using Accela.Web.SDK.Models;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http;
using System.Configuration;

namespace ConsoleApplication1
{
    class Program
    {
        // Licenses-Animal-Dog-License, Licenses-Animal-Dog-Application
        // DUB13-00000-00006, DUB13-00000-00005
        // Active-LIC_PET, Issued-LIC_PET

        static void Main(string[] args)
        {
            PaginationInfo p = null;
            string filter = "module=Licenses";
            string redirectUrl = "http://localhost:49881/";
            string scope = "records contacts get_user_profile get_record_documents get_document create_record_document agencies get_agency_logo get_my_profile";
            //string recordId = "BPTMSTR-DUB13-00000-00005";
            string recordId = "BPTMSTR-14EST-00000-00277";
            string documentId = "DUB13-00000-00005-401";
            string rId = "BPTMSTR-DUB14-00000-00023";
            string taskId = "4-12713";

            string token = "hejTpTEaCiskuM76PiBgOa04Bjp0Yc6xDXEtNxhM5i1LTctfaAf5vxHCy0P4o8zVf2Ix9KRd5b4S_Oxf-SjvDTteS351G92fqRUkEdgC4vztCa1NugwuEyNmu40Z0moYqVu42LnAJr0bVApCGu2YIYrKm5JsmfcAMaX5TaUb2ZSYOVoGRopnO4LxQGC8pSLeRj-nDz3OozgsAduOZfYmN_Dh5C1phGpeAq-whkX8zCRTUNqHifjKtoA3MhzHwULwCT-BMHqpnRMRP7KSDR2Z-7126Lyw7_ZBjxTLAq_viPE1BeG6cuzRIURtxH_R8ARKq8sG2KMuevg3z6MOWwHj8xeL_4WiEsBpyDNzU2qE-xKiJnF2UMD_J_ixK_AZ8tQmzxqYS4QGP65gwkr0U0kn4TJc28DPKEJoJbC1N013NoYBvohetXRRCcz72cF-trzuhNQ5R6anZ_M0sxppXCjcQBMBzzKzwzZcg72-hi4PtNEgHNjSi875HFHJCkMfImW1UoljJ3grEC0KIaslu0vBDOCuOqKDmBmrJB7LdrUK7rI1";

            //IRecord rec = new RecordHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen, string.Empty, new AppConfigurationProvider());
            //IDocument doc = new DocumentHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);
            //IAgency a = new AgencyHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);

            IRecord rec = new RecordHandler("635339775442544632", "67159369a6984f20875e240c21720587", ApplicationType.Agency, string.Empty, new AppConfigurationProvider());
            IDocument doc = new DocumentHandler("635339775442544632", "67159369a6984f20875e240c21720587", ApplicationType.Agency, string.Empty, new AppConfigurationProvider());
            IAgency a = new AgencyHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency, string.Empty, new AppConfigurationProvider());
            IAddress ad = new AddressHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency, string.Empty, new AppConfigurationProvider());
            IContact con = new ContactHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency, string.Empty, new AppConfigurationProvider());
            IPayment pay = new PaymentHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency, string.Empty, new AppConfigurationProvider());

            // get a good record
            RecordFilter f = new RecordFilter { customId = "TP820-14-00002" };
            ResultDataPaged<Record> records = rec.SearchRecords(token, f, null, -1, 200);
            Record r = ((Record)records.Data.First());

            ResultDataPaged<Contact> cons = rec.GetRecordContacts(r.id, token);
            Contact cn = ((Contact)cons.Data.First());

            List<Dictionary<string, string>> cf = rec.GetRecordCustomFields(r.id, token);

            // address
            // custom table

            // create partial
            Record r1 = rec.CreateRecordInitialize(new Record
            {
                type = new RecordType
                {
                    id = "Licenses-Special.cEvents-Beer,.cWine,.cCider.c(Temporary)-Permit",
                    group = "Licenses",
                    type = "Special.cEvents",
                    subType = "Beer,.cWine,.cCider.c(Temporary)",
                    category = "Permit",
                    value = "Licenses/Special Events/Beer, Wine, Cider (Temporary)/Permit",
                    module = "Licenses"
                }
            }, token);

            // update record detail
            r1.description = "Bubba";
            r1 = rec.UpdateRecordDetail(r1, token);

            // create contact
            List<Contact> cs = new List<Contact>();
            cs.Add(cn);
            rec.CreateRecordContact(cs, r1.id, token);

            // get and update contact
            cons = rec.GetRecordContacts(r1.id, token);
            cn = ((Contact)cons.Data.First());
            cn.isPrimary = "N";
            cn = rec.UpdateRecordContact(cn, r1.id, token);
            
            // update custom forms
            rec.UpdateRecordCustomFields(r1.id, cf, token);

            // create and update address

            // update custom table

            // upload doc.
            FileInfo file = new FileInfo(@"C:\Swapnali\TestPurposes\Ducky.jpeg");
            if (file != null)
            {
                AttachmentInfo at = new AttachmentInfo { FileType = "image/jpeg", FileName = "Ducky.jpeg", ServiceProviderCode = "SLA", Description = "Test" };
                at.FileContent = new StreamContent(file.OpenRead());
                rec.CreateRecordDocument(at, r.id, token, "ooo");
            }

            // get  and download documents
            //List<Document> docs = rec.GetRecordDocuments(r.id, token);
            //Stream sr = doc.DownloadDocument("1132", token);
            //using (FileStream fs = new FileStream(@"C:\Swapnali\TestPurposes\photo.jpeg", FileMode.Create))
            //{
            //    sr.CopyTo(fs);
            //}

            // finalize
            Record record = rec.CreateRecordFinalize(new Record { id = r1.id, type = new RecordType { id = "Licenses-Special.cEvents-Beer,.cWine,.cCider.c(Temporary)-Permit" } }, token);
            

            //pay.GetFeeSchedule(token, "LIC_PET_GENERAL");
            //List<Agency> ags = a.GetAgencies(token);

            //Record r = rec.GetRecord(recordId, token);
            //ResultDataPaged<Contact> cons = rec.GetRecordContacts(recordId, token);
            //List<Dictionary<string, string>> cf = rec.GetRecordCustomFields(recordId, token);
            //List<Document> docs = rec.GetRecordDocuments(recordId, token);

            //RecordFilter f = new RecordFilter { module = "Licenses" };
            //ResultDataPaged<Record> records = rec.SearchRecords(token, f, null, -1, 200, "customId", "DESC");
            //Record record = ((Record)records.Data.First());

            //ResultDataPaged<Record> records = rec.SearchRecords(token, f, null, 0, 10);
            //ResultDataPaged<Record> records1 = rec.SearchRecords(token, f, null, 10, 10);
            //ResultDataPaged<Record> records2 = rec.SearchRecords(token, f, null, 20, 10);  

            //RecordFilter f = new RecordFilter { customId = "PET-00085" };
            //RecordFilter f = new RecordFilter { type = new RecordType { module = "Licenses", group = "Licenses", type = "Animal", category = "License" } };
            //ResultDataPaged<Record> records = rec.SearchRecords(token, f, null, -1, 200);
            //Record record = ((Record)records.Data.First());


            //ResultDataPaged<Contact> contacts = rec.GetRecordContacts(record.id, token);
            //List<Dictionary<string, string>> cf = rec.GetRecordCustomFields(record.id, token);
            //rec.GetRelatedRecords(record.id, token);

            //PaymentInfo pInfo = new PaymentInfo
            //{
            //    creditCard = new CreditCard
            //        {
            //            billingAddress = new BillingAddress { addressLine1 = "2633 Camino Ramon", city = "San Ramon", countryCode = "US", postalCode = "94583", state = "CA" },
            //            cardNumber = "4217651111111118",
            //            cardType = "Visa",
            //            expirationMonth = 1,
            //            expirationYear = 2014,
            //            holderName = "Wogo",
            //            securityCode = "456"
            //        },
            //    currency = "USD",
            //    amount = 50,
            //    entityId = record.id,
            //    entityType = "Record",
            //    message = "Test Payment",
            //    paymentMethod = "Credit Card"
            //};

            //PaymentResult pResult = pay.MakePayment(token, pInfo);

            //RecordFilter f = new RecordFilter { status = new Status { value = "In Review" }, type = new RecordType { module = "Licenses", group = "Licenses", type = "Animal", category = "Application" } };
            //RecordFilter f = new RecordFilter { type = new RecordType { module = "Licenses", group = "Licenses", type = "Animal", category = "License" }};
            //RecordFilter f = new RecordFilter { customId = "PETA14-00094" };
            //RecordFilter f = new RecordFilter { customId = "PETA14-00096" };
            //RecordFilter f = new RecordFilter { type = new RecordType { module = "Licenses", group = "Licenses", type = "Animal" }, recordClass = "COMPLETE", contact = new Contact { lastName = "Liu" } };
            //ResultDataPaged<Record> records = rec.SearchRecords(token, f, null, -1, 200);
            //Record record = ((Record)records.Data.First());
            //record.name = "Bubba";
            //record.description = "Bubba";
            //record = rec.UpdateRecordDetail(record, token);
            //List<RecordFees> fee = rec.GetRecordFees(record.id, token);
            //List<RelatedRecord> rr = rec.GetRelatedRecords(record.id, token);

            // Contact
            //List<ContactType> ct = con.GetContactTypes(token, "Licenses");
            //ResultDataPaged<Contact> cts = con.SearchContacts(token, new ContactFilter { email = "sdembla@accela.com" });

            //// Agency
            //Agency ag = a.GetAgency(token, "SOLNDEV-ENG");
            //Stream sr = a.GetAgencyLogo(token, "SOLNDEV-ENG");
            //using (FileStream fs = new FileStream(@"C:\Swapnali\TestPurposes\logo.png", FileMode.Create))
            //{
            //    sr.CopyTo(fs);
            //}

            // Record Contact
            //ResultDataPaged<Contact> contacts = rec.GetRecordContacts(recordId, token);
            //List<Contact> cs = new List<Contact> { 
            //    new Contact { isPrimary = "N", businessName = "test",
            //        firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", 
            //        address = new ContactAddress { addressLine1 = "500 San Blvd", city = "San Ramon", state = new State { value = "CA" },
            //        postalCode = "94566" },
            //        type = new ContactType { value = "Pet Owner" } }};

            //rec.CreateRecordContact(cs, recordId, token);
            //contacts = rec.GetRecordContacts(recordId, token);
            //Contact c = ((List<Contact>)contacts.Data)[0];
            //c.type.text = null;
            //c.middleName = "test for Oscar";
            //c = rec.UpdateRecordContact(c, recordId, token);
            //contacts = rec.GetRecordContacts(recordId, token);
            ////rec.DeleteRecordContact(c.id, rId, token);
            //contacts = rec.GetRecordContacts(recordId, token);

            // Address
           //List<Country> cn = ad.GetCountries(token);
           //List<State> s = ad.GetStates(token);

            // Records
           //Record record = rec.GetRecord(recordId, token);
           //record.name = "Test Again & Again";

            //List<Dictionary<string, string>> cf = rec.GetRecordCustomFields(record.id, token);


           //record.description = "Test Again & Again";
           //record = rec.UpdateRecordDetail(record, token);
           //record = rec.GetRecord(recordId, token);
           //records = rec.SearchRecords(token, new RecordFilter { type = new RecordType { category = "Application" }, contact = new Contact { firstName = "Sam" } }, null);
           //records = rec.GetRecords(token, null);
            //Record record = new Record { type = new RecordType { id = "Licenses-Animal-Dog-Application" } };
            List<Contact> contactList = new List<Contact> { new Contact { type = new ContactType { value = "Pet Owner" }, firstName = "Swapnali", lastName = "Dutta", email = "sethaxthelm@gmail.com" } };
            //Record r1 = rec.CreateRecordInitialize(new Record { type = new RecordType { id = "Licenses-Animal-Dog-Application" } }, token);

            //Record r1 = rec.CreateRecordInitialize(new Record { type = new RecordType { id = "Licenses-Special Events-Beer, Wine, Cider (Temporary)-Permit" } }, token);
            ////Record r1 = record;
            //r1.name = "Test Renewal";
            //r1.description = "Test Renewal";
            //r1 = rec.UpdateRecordDetail(r1, token);
            //Record record = rec.GetRecord(r1.id, token);
            //rec.CreateRecordContact(contactList, r1.id, token);
            //ResultDataPaged<Contact> cons = rec.GetRecordContacts(r1.id, token);
            //Contact cn = ((Contact)cons.Data.First());
            //cn.lastName = "Dembla";
            //cn = rec.UpdateRecordContact(cn, r1.id, token);
            //List<Dictionary<string, string>> cf = rec.GetRecordCustomFields(r1.id, token);
            //Dictionary<string, string> temp = cf[1];
            //temp["Pet Name"] = "Goof";
            //rec.UpdateRecordCustomFields(r1.id, cf, token);
            //record = rec.CreateRecordFinalize(r1, token);
            //cf = rec.GetRecordCustomFields(r1.id, token);
            //cons = rec.GetRecordContacts(r1.id, token);

            //FileInfo file = new FileInfo(@"C:\Swapnali\TestPurposes\Ducky.jpeg");
            //if (file != null)
            //{
            //    AttachmentInfo at = new AttachmentInfo { FileType = "image/jpeg", FileName = "Ducky.jpeg", ServiceProviderCode = "BPTMSTR", Description = "Test" };
            //    at.FileContent = new StreamContent(file.OpenRead());
            //    rec.CreateRecordDocument(at, r1.id, token, "ooo");
            //}
            //List<Document> docs = rec.GetRecordDocuments(r1.id, token);
            //record.contacts = new List<Contact> { new Contact { id = "1234", firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet Owner" } } };
            //record = rec.CreateRecordFinalize(new Record { id = "BPTMSTR-14EST-00000-00257", type = new RecordType { id = "Licenses-Animal-Dog-Application" } }, token);
            //record = rec.CreateRecordFinalize(r1, token);
            //record = rec.GetRecord(record.id, token);
            //cons = rec.GetRecordContacts(record.id, token);
            //cf = rec.GetRecordCustomFields(record.id, token);
            ////docs = rec.GetRecordDocuments(record.id, token);

            // Documents
            //List<DocumentType> d = rec.GetRecordDocumentTypes(recordId, token);
            //List<Document> docs = rec.GetRecordDocuments(recordId, token);
            //Stream sr = doc.DownloadDocument("1132", token);
            //using (FileStream fs = new FileStream(@"C:\Swapnali\TestPurposes\photo.jpeg", FileMode.Create)) 
            //{
            //    sr.CopyTo(fs);
            //}

            //FileInfo file = new FileInfo(@"C:\Swapnali\TestPurposes\Ducky.jpeg");
            //if (file != null)
            //{
            //    AttachmentInfo at = new AttachmentInfo { FileType = "image/jpeg", FileName = "Ducky.jpeg", ServiceProviderCode = "BPTMSTR", Description = "Test" };
            //    at.FileContent = new StreamContent(file.OpenRead());
            //    rec.CreateRecordDocument(at, recordId, token, "ooo");
            //}
            //rec.DeleteRecordDocument("1012", recordId, token);
            //docs = rec.GetRecordDocuments(recordId, token);

            // Status
            //List<Status> s = rec.GetRecordStatuses("Licenses-Animal-Pig-Application", token);

            //// Workflow
           //List<WorkflowTask> w2 = rec.GetWorkflowTasks(record.id, token);
           //WorkflowTask w = rec.GetWorkflowTask(record.id, taskId, token);
           //UpdateWorkflowTaskRequest uw = new UpdateWorkflowTaskRequest { comment = "testing", status = new Status { value = "In Review" } };
           //w = rec.UpdateWorkflowTask("BPTMSTR-DUB14-00000-00059", taskId, uw, token);

            // Fees
            //List<RecordFees> fs = rec.GetRecordFees(recordId, token);

            // Custom Fields
            //cf = rec.GetRecordCustomFields(recordId, token);
            //temp = cf[0];
            //temp["Pet Name"] = "Toffy";
            ////List<Dictionary<string, string>> cfs = new List<Dictionary<string, string>>();
            ////Dictionary<string, string> val = new Dictionary<string,string>();
            ////val.Add("id", "LIC_DOG_LIC-GENERAL.cINFORMATION");
            ////val.Add("Name", "Woofy");
            ////cfs.Add(val);
            //rec.UpdateRecordCustomFields(recordId, cf, token);
            //cf = rec.GetRecordCustomFields(recordId, token);
        }
    }
}



//{
//    "result": [
//        {
//            "addressLine1": "abc rd",
//            "id": 1726,
//            "postalCode": "11946",
//            "city": "brooklyn",
//            "county": "Suffolk",
//            "serviceProviderCode": "SLA",
//            "isPrimary": "Y",
//            "recordId": {
//                "id": "SLA-14CAP-00000-00002",
//                "customId": "TP820-14-00002",
//                "trackingId": 1579578406,
//                "serviceProviderCode": "SLA",
//                "value": "14CAP-00000-00002"
//            },
//            "country": {
//                "value": "US",
//                "text": "United States"
//            },
//            "state": {
//                "value": "NY",
//                "text": "NY"
//            }
//        }
//    ],
//    "status": 200
//}


//{
//    "status": 200,
//    "result": [
//        {
//            "id": "SPECIALEVENT-BACKEND.cDATA",
//            "rows": []
//        },
//        {
//            "id": "SPECIALEVENT-AUTHORIZATION",
//            "rows": []
//        },
//        {
//            "id": "SPECIALEVENT-SCHEDULE",
//            "rows": [
//                {
//                    "id": "1",
//                    "fields": {
//                        "Number of bars or stands serving alcoholic beverages": "1",
//                        "Date of Event": "06/18/2014",
//                        "Start Time of Event": "6:30 PM",
//                        "Rain Date": "06/27/2014",
//                        "End Time of Event": "7:00 PM"
//                    }
//                }
//            ]
//        },
//        {
//            "id": "SPECIALEVENT-ISSUE.cDATE",
//            "rows": []
//        }
//    ]
//}
