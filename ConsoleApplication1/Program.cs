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
            string recordId = "BPTMSTR-DUB14-00000-0002E";
            string documentId = "DUB13-00000-00005-401";
            string rId = "BPTMSTR-DUB14-00000-00023";
            string taskId = "4-12713";

            string token = "Uy9PqyeYnTGh4LuRsCt3EAxqF8n318u9uCOOmHVr45Qpw9izS4UxTpBiqmr2Pdyk7pu-1zLT6wqJTYlghK0Tx6V5NBjsn_bk5l8ue8ce1uS25JJcVQHus4aJEWsXn4FW07k-3e9w2QMN3YU692mOgKkRfUGdbSSnx1g8PpFyqNzYJEmg8yaHu9cOqEsbAt5I1e0gSNazkWG9L13o96-rZz81wiWr4kbVqXd7o4mJHtyGB22uDvPMiNhHdQs_745tFFlcQK8eJ5QsttgaEx6MxZpShwmoMk6e8L9c8AZylaDsqWRYCkR0kHVS3pEeBwOiut0BOTIofrJR4B_KpDEyWv-cRb3AS7vQpAIwVUoo7Isav3qMS3CejOU0AoFCg2ujqQgWSSpCxAj8YUGivXfSDUHwBBnGEDAUlcLKSjQNCS0kbZCZ_fRXMY_uh0Ly6nLb7WdBgTAiWb9va_3BrGLJvkMfwxHWllZ-j5-UQZqfapxj6auG_-3XQfKLFVXwa7qoj0bGNE5pirPnlqOPaS6s9iMmYOt9w8V5iSPnpXUrFKFavN1iuXIjH__MgcvZlHel0";

            //IRecord rec = new RecordHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);
            //IDocument doc = new DocumentHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);
            //IAgency a = new AgencyHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);

            IRecord rec = new RecordHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency, string.Empty, new AppConfigurationProvider());
            IDocument doc = new DocumentHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency, string.Empty, new AppConfigurationProvider());
            IAgency a = new AgencyHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency, string.Empty, new AppConfigurationProvider());
            IAddress ad = new AddressHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency, string.Empty, new AppConfigurationProvider());
            IContact con = new ContactHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency, string.Empty, new AppConfigurationProvider());

            RecordFilter f = new RecordFilter { status = new Status { value = "In Review" }, type = new RecordType { module = "Licenses", group = "Licenses", type = "Animal", category = "Application" } };
            //RecordFilter f = new RecordFilter { type = new RecordType { module = "Licenses", group = "Licenses", type = "Animal", category = "License" }};
            //RecordFilter f = new RecordFilter { customId = "PET-00028" };
            //RecordFilter f = new RecordFilter { type = new RecordType { module = "Licenses", group = "Licenses", type = "Animal" }, recordClass = "COMPLETE", contact = new Contact { lastName = "Liu" } };
            ResultDataPaged<Record> records = rec.SearchRecords(token, f, null, -1, 200);
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
           //Dictionary<string, string> temp = cf[0];
           //temp["Pet Name"] = "Fluff";

           //record.description = "Test Again & Again";
           //record = rec.UpdateRecordDetail(record, token);
           //record = rec.GetRecord(recordId, token);
           //records = rec.SearchRecords(token, new RecordFilter { type = new RecordType { category = "Application" }, contact = new Contact { firstName = "Sam" } }, null);
           //records = rec.GetRecords(token, null);
           //Record record = new Record { type = new RecordType { id = "Licenses-Animal-Dog-Application" } };
            List<Contact> contactList = new List<Contact> { new Contact { type = new ContactType { value = "Pet Owner" } } };
            Record r1 = rec.CreateRecordInitialize(record, token);
            record = rec.GetRecord(r1.id, token);
            rec.CreateRecordContact(contactList, r1.id, token);
            ResultDataPaged<Contact> cons = rec.GetRecordContacts(r1.id, token);
            Contact cn = ((Contact)cons.Data.First());
            cn.lastName = "Raval";
            cn = rec.UpdateRecordContact(cn, r1.id, token);
            //rec.UpdateRecordCustomFields(r1.id, cf, token);
            //cf = rec.GetRecordCustomFields(r1.id, token);
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
            //record = rec.CreateRecordFinalize(new Record { id = "BPTMSTR-14EST-00000-00257", type = new RecordType { id = "Licenses-Animal-Dog-Application" } }, token);
            record = rec.CreateRecordFinalize(r1, token);
            record = rec.GetRecord(record.id, token);
            cons = rec.GetRecordContacts(record.id, token);
            //cf = rec.GetRecordCustomFields(record.id, token);
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
           List<WorkflowTask> w2 = rec.GetWorkflowTasks(record.id, token);
           WorkflowTask w = rec.GetWorkflowTask(record.id, taskId, token);
           UpdateWorkflowTaskRequest uw = new UpdateWorkflowTaskRequest { comment = "testing", status = new Status { value = "Issued" } };
           w = rec.UpdateWorkflowTask("BPTMSTR-DUB14-00000-00059", taskId, uw, token);

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
