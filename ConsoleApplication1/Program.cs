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
            string recordId = "BPTMSTR-DUB14-00000-0002E";
            string documentId = "DUB13-00000-00005-401";
            string rId = "BPTMSTR-DUB14-00000-00023";
            string taskId = "4-12713";

            string token = " hrNHVi9MPuQogOt_Kif7av9KoJt42s4BJpMIqEDAjJfroU-cmc5GDnW2XiBcU1zNC3eeYg0pWdCNabeMLZgIkEvgw4JUYeDGXAA0Qi5KcaPkr_d328tJUzYV7EZ6HBAwFtDasCMQUqyprUjwJrEseOOVCmD2GZ8PyshiRi7BCbS53vPoTvl8jCxAeXDNJ6nRKsGo4a0_LmrfWFTJ6RAbZzitXPLGIKbjqIiqBDxnvTZ8H1_SnsPqIGG0pI1Z9bKnCzT4A3Wi4pZLFb8uYWiUXGNAdyJr4pjmG67RiPL5KnyuP53ajjfniiGzyp_TyqMy1cbALga8wyhIZO0TfW0lAJdjyjkde7lMPm3zdiNaAwg2USF-s4LSUOPrWDM5M_08lMda70zZeqMhMJLAKtW9l3xX6q2mAx-BI9L2zcyHhZKUd91_Ols5PaNGs_3op5yAe0-P4hkId11rgZst481QmSmSLBEhBTnDTmYeW0OS2Aga1nvlb_bioPM7DWgMZ1lLxNWxwDQt2q5QJoENf0qUB5MM9goltulXl_M85LRx8N96dtlsp4tLqdGIiZPGZdye0";

            //IRecord rec = new RecordHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);
            //IDocument doc = new DocumentHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);
            //IAgency a = new AgencyHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);

            IRecord rec = new RecordHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            IDocument doc = new DocumentHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            IAgency a = new AgencyHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            IAddress ad = new AddressHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            IContact con = new ContactHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);

            //RecordFilter f = new RecordFilter { status = new Status { value = "In Review" }, type = new RecordType { module = "Licenses", group = "Licenses", type = "Animal", category = "Application" }, openedDate = "02/27/2014", endOpenedDate = "03/10/2014" };
            //RecordFilter f = new RecordFilter { type = new RecordType { module = "Licenses", group = "Licenses", type = "Animal", category = "License" }};
            //RecordFilter f = new RecordFilter { customId = "PET-00028" };
            RecordFilter f = new RecordFilter { type = new RecordType { module = "Licenses", group = "Licenses", type = "Animal" }, recordClass = "COMPLETE", contact = new Contact { lastName = "Liu" } };
            ResultDataPaged<Record> records = rec.SearchRecords(token, f, null, -1, 200);
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
            //Agency ag = a.GetAgency(token, "BPTMSTR");
            //AttachmentInfo att = a.GetAgencyLogo(token, "BPTMSTR"); // 404 Not found

            // Record Contact
           // ResultDataPaged<Contact> contacts = rec.GetRecordContacts(recordId, token);
           // List<Contact> cs = new List<Contact> { 
           //     new Contact { isPrimary = "N", businessName = "test",
           //         firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", 
           //         address = new ContactAddress { addressLine1 = "500 San Blvd", city = "San Ramon", state = new State { value = "CA" },
           //         postalCode = "94566" },
           //         type = new ContactType { value = "Pet Owner" } }};

           // rec.CreateRecordContact(cs, recordId, token);
           // contacts = rec.GetRecordContacts(recordId, token);
           // Contact c = ((List<Contact>)contacts.Data)[0];
           // c.type.text = null;
           // c.middleName = "tseting";
           // c = rec.UpdateRecordContact(c, recordId, token);
           //contacts = rec.GetRecordContacts(recordId, token);
           //rec.DeleteRecordContact(c.id, rId, token);
           //contacts = rec.GetRecordContacts(recordId, token);

            // Address
           //List<Country> cn = ad.GetCountries(token);
           //List<State> s = ad.GetStates(token);

            // Records
           Record record = rec.GetRecord(recordId, token);
           record.name = "Test Again & Again";

           List<Dictionary<string, string>> cf = rec.GetRecordCustomFields(record.id, token);
           Dictionary<string, string> temp = cf[0];
           temp["Pet Name"] = "Fluff";

           record.description = "Test Again & Again";
           record = rec.UpdateRecordDetail(record, token);
           record = rec.GetRecord(recordId, token);
           //records = rec.SearchRecords(token, new RecordFilter { type = new RecordType { category = "Application" }, contact = new Contact { firstName = "Sam" } }, null);
           //records = rec.GetRecords(token, null);
           //record = new Record { type = new RecordType { id = "Licenses-Animal-Pig-Application" } };
           List<Contact> contactList = new List<Contact> { new Contact { firstName = "Swapnali", lastName = "Dutta", email = "sdembla@accela.com", type = new ContactType { value = "Pet.cOwner" } } };
           Record r1 = rec.CreateRecordInitialize(record, token);
           record = rec.GetRecord(r1.id, token);
           rec.CreateRecordContact(contactList, r1.id, token);
           ResultDataPaged<Contact> cons = rec.GetRecordContacts(r1.id, token);
           Contact cn = ((Contact)cons.Data.First());
           cn.lastName = "Raval";
           cn = rec.UpdateRecordContact(cn, r1.id, token);
           rec.UpdateRecordCustomFields(r1.id, cf, token);
           cf = rec.GetRecordCustomFields(r1.id, token);
           cons = rec.GetRecordContacts(r1.id, token);

           FileInfo file = new FileInfo(@"C:\Swapnali\TestPurposes\Ducky.jpeg");
           if (file != null)
           {
               AttachmentInfo at = new AttachmentInfo { FileType = "image/jpeg", FileName = "Ducky.jpeg", ServiceProviderCode = "BPTMSTR", Description = "Test" };
               at.FileContent = new StreamContent(file.OpenRead());
               rec.CreateRecordDocument(at, r1.id, token, "ooo");
           }
           List<Document> docs = rec.GetRecordDocuments(r1.id, token);
           //record.contacts = new List<Contact> { new Contact { id = "1234", firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet Owner" } } };
           record = rec.CreateRecordFinalize(r1, token);
           cons = rec.GetRecordContacts(record.id, token);
           cf = rec.GetRecordCustomFields(record.id, token);
           docs = rec.GetRecordDocuments(record.id, token);

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
            //UpdateWorkflowTaskRequest uw = new UpdateWorkflowTaskRequest { comment = "testing", status = new Status { value = "Issued" } };
            //w = rec.UpdateWorkflowTask(record.id, taskId, uw, token);

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
