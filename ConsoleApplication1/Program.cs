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
            string recordId = "BPTMSTR-DUB14-00000-0002I";
            string documentId = "DUB13-00000-00005-401";
            string rId = "BPTMSTR-DUB14-00000-00023";
            string taskId = "4-12713";

            string token = "rCh5v80yUoKQNGwsUuaN3RmmId9KbQGqCflQ5lBJ0cZEn9YBQn5e7XI5PGQQR8UP_wGnSllXAwqTxyW242teExjHUmUsbj7xDgXpdVjJOk9AgNqFI9-Kc4fPL1z1U5KzI-zgbtC9yfdFWA0uHM4MwKMzcpOkwE6L7ZY-Xb4NbIDzSbSOIm8NJMAfbOn959xRJGVY8qTYQOX9I3ttFSNTF10CwBdfptgeGlOY89bCwlsF-wlpVgRJMbK74c8WL0C5H4Bsgf8WLkncFXx2ZTGn3NVonzJqBs4l7TA08zwbGdQv5h6N2eW8TkKo-KBBPVsvK-is1wZKf9EnU5lcoS213NO1gQS_aXl75U1mz4eC0Q-OG4VMmGStjQZqBIoT-bAnwG0urwRtHeEHtjTRNuiBCohHeqlvgxGQw-2MjZdnNyn_fYo10mfXEQLZcGWV4Qylb9iCckzCQQaEdDPHNXD0ZmB1ZGTK2ltKuOnH2bODLRoM1pt2XHLgJdX-GHC0cQ_iCpF3modra5YAVsy3CVUgyMIKz-_f21hkZE0Ja-5gz7Q1";

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
            RecordFilter f = new RecordFilter { customId = "PETA14-00095" };
            ResultDataPaged<Record> records = rec.SearchRecords(token, f);
            Record record = ((Record)records.Data.First());
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
           //ResultDataPaged<Contact> contacts = rec.GetRecordContacts(recordId, token);
           //List<Contact> cs = new List<Contact> { 
           //     new Contact { isPrimary = "N", businessName = "test",
           //         firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", 
           //         address = new ContactAddress { addressLine1 = "500 San Blvd", city = "San Ramon", state = new State { value = "CA" },
           //         postalCode = "94566" },
           //         type = new ContactType { value = "Pet Owner" } }};

           //rec.CreateRecordContact(cs, recordId, token);
           //contacts = rec.GetRecordContacts(recordId, token);
           //Contact c = ((List<Contact>)contacts.Data)[0];
           //c.type.text = null;
           //c.middleName = "tseting";
           //c = rec.UpdateRecordContact(c, recordId, token);
           //contacts = rec.GetRecordContacts(recordId, token);
           //rec.DeleteRecordContact(c.id, rId, token);
           //contacts = rec.GetRecordContacts(recordId, token);

            // Address
            //List<Country> cn = ad.GetCountries(token);
            //List<State> s = ad.GetStates(token);

            // Records
            //Record record = rec.GetRecord(recordId, token);
            //record.name = "Test Test";
            //record.description = "Test Test";
            //record = rec.UpdateRecordDetail(record, token);
            //record = rec.GetRecord(recordId, token);
            //records = rec.SearchRecords(token, new RecordFilter { type = new RecordType { category = "Application" }, contact = new Contact { firstName = "Sam" } }, null);
            //records = rec.GetRecords(token, null);
            //record = new Record { type = new RecordType { id = "Licenses-Animal-Pig-Application" } };
            //record.contacts = new List<Contact> { new Contact { firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet.cOwner" } } };
            //Record r1 = rec.CreateRecordInitialize(record, token);
            //record = rec.GetRecord(r1.id, token);
            //ResultDataPaged<Contact> contacts = rec.GetRecordContacts(record.id, token);
            //FileInfo file = new FileInfo(@"C:\Swapnali\TestPurposes\Ducky.jpeg");
            //if (file != null)
            //{
            //    AttachmentInfo at = new AttachmentInfo { FileType = "image/jpeg", FileName = "Ducky.jpeg", ServiceProviderCode = "BPTMSTR", Description = "Test" };
            //    at.FileContent = new StreamContent(file.OpenRead());
            //    rec.CreateRecordDocument(at, record.id, token, "ooo");
            //}
            //List<Document> docs = rec.GetRecordDocuments(record.id, token);
            //record.contacts = new List<Contact> { new Contact { id = "1234", firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet Owner" } } };
            //record = rec.CreateRecordFinalize(record, token);
            //contacts = rec.GetRecordContacts(record.id, token);
            //docs = rec.GetRecordDocuments(record.id, token);

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
            List<WorkflowTask> w2 = rec.GetWorkflowTasks(record.id, token);
            WorkflowTask w = rec.GetWorkflowTask(record.id, taskId, token);
            UpdateWorkflowTaskRequest uw = new UpdateWorkflowTaskRequest { comment = "testing", status = new Status { value = "Issued" } };
            w = rec.UpdateWorkflowTask(record.id, taskId, uw, token);

            // Fees
            //List<RecordFees> fs = rec.GetRecordFees(recordId, token);

            // Custom Fields
            List<Dictionary<string, string>> cf = rec.GetRecordCustomFields(recordId, token);
            Dictionary<string, string> temp = cf[0];
            temp["Pet Name"] = "Toffy";
            //List<Dictionary<string, string>> cfs = new List<Dictionary<string, string>>();
            //Dictionary<string, string> val = new Dictionary<string,string>();
            //val.Add("id", "LIC_DOG_LIC-GENERAL.cINFORMATION");
            //val.Add("Name", "Woofy");
            //cfs.Add(val);
            rec.UpdateRecordCustomFields(recordId, cf, token);
            cf = rec.GetRecordCustomFields(recordId, token);
        }
    }
}
