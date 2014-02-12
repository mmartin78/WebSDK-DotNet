using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK;
using Accela.Web.SDK.Models;
using Newtonsoft.Json;

namespace ConsoleApplication1
{
    // search record - done, bug
    // create record - done
    // create contacts - done
    // update custom fields - done, bug
    // upload doc - bug
    // download doc - bug
    // delete doc
    // get record - done, bug for citizen
    // get records - done, bug for citizen
    // get custom fields - done, bug for citizen
    // get contacts - done, bug for citizen
    // get docs - done, bug for citizen
    // get doc - done, bug for citizen

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
            string recordId = "BPTMSTR-DUB13-00000-00005";
            string documentId = "DUB13-00000-00005-401";
            string rId = "BPTMSTR-14EST-00000-00017";
            string taskId = "3-12713";

            string token = "Fa7nMwQB-ScOc5-kUqoL-QXBpDs0FRyaSg5DDeW8S0GIl1e3v2tmvNRT0DBUv4vgTWW4F57po4_G6yIGEvj7-aK4mYLAYb6fAXFypDQJ7v39r8kV4tIB7fBKmDUtbOeSTzRBz34splSuZbdeSF5WFzrU1UsKKzi5CJ8PKw0-Nvnl3cjq0scdaEKW-qadK0owJgTIdiLfx0kbh7ePn74S-UcUHtTIDd3DOdVr-LWkFUEP8hmF8QB6TbC2G4pXzK1ePGE-ChFVoh7zUc6Kv-LaZNP4bcR6H3Ku-7eSKa1JxCqEpoaxfgbDhjnDuXQgFdlckFNNPKhASaB4IFoQrNrmO4iTqGhqQijGgTFfC1lOiHue5H5hvuyRobwX48N_M-765RMN_7U9rP-LJ7NfYRV58Z9SzJVFPJ3lCjP-ARQYh1VcrNEv4NQC_S_K1tC-a5P1u2qZacOcPOhb9RygyykeIIByHOMhIxhHLmgBYZZboBUqxMVYsjxgWvXNAFvVWjvyhptReEZEYRh_9KcbKskb6TPRUB0_IPwBlQFN-BMB8sc1";

            //IRecord rec = new RecordHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);
            //IDocument doc = new DocumentHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);
            //IAgency a = new AgencyHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);

            IRecord rec = new RecordHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            IDocument doc = new DocumentHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            IAgency a = new AgencyHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            IAddress ad = new AddressHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);

            List<Country> c = ad.GetCountries(token);
            ResultDataPaged<Record> records = rec.SearchRecords(token, new RecordFilter { type = new RecordType { category = "License" } }, null);
            doc.DownloadDocument("C:\\Swapnali\\TestPurposes\\test.jpeg", "401", token);
            List<Document> docs = rec.GetRecordDocuments(recordId, token);
            rec.CreateRecordDocument(@"C:\Swapnali\TestPurposes\Ducky.jpeg", "test document", recordId, token);


            List<Contact> cs = new List<Contact> { new Contact { firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet Owner" } } };
            rec.CreateRecordContact(cs, recordId, token);
            ResultDataPaged<Contact> contacts = rec.GetRecordContacts(recordId, token);
            cs = contacts.Data as List<Contact>;
            cs[0].middleName = "tseting";
            cs[0] = rec.UpdateRecordContact(cs[0], recordId, token);
            contacts = rec.GetRecordContacts(recordId, token);

            //List<ContactType> ct = rec.GetContactTypes(token);
            //List<DocumentType> d = rec.GetRecordDocumentTypes(recordId, token);
            //List<Status> s = rec.GetRecordStatuses("Licenses-Animal-Pig-Application", token);
            //List<Country> c = ad.GetCountries(token);
            //List<State> st = ad.GetStates(token);
            //ResultDataPaged<Record> records = rec.GetRecords(token, filter);
            //List<WorkflowTask> w1 = rec.GetWorkflowTasks("BPTMSTR-DUB14-00000-0001Y", token);
            //List<WorkflowTask> w2 = rec.GetWorkflowTasks(recordId, token, true);
            //WorkflowTask w = rec.GetWorkflowTask(recordId, taskId, token);

            //UpdateWorkflowTaskRequest uw = new UpdateWorkflowTaskRequest { comment = "testing", status = new Status { value = "About to Expire" } };
            //w = rec.UpdateWorkflowTask("BPTMSTR-DUB14-00000-0001Y", "1-12714", uw, token);

            //Record record = new Record { type = new RecordType { id = "Licenses-Animal-Pig-Application" } };
            //record.contacts = new List<Contact> { new Contact { firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet.cOwner" }}};
            //RecordId r1 = rec.CreateRecordInitialize(record, token);
            Record record = rec.GetRecord(recordId, token);
            record.contacts = new List<Contact> { new Contact { firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet Owner" } } };
            RecordId r2 = rec.CreateRecordFinalize(record, token);

            //IRecord rec = new RecordHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            //IDocument doc = new DocumentHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            //IAgency a = new AgencyHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);

            //doc.DownloadDocument(@"C:\Swapnali\TestPurposes\test.jpeg", "401", token);
            //rec.CreateRecordDocument(@"C:\Swapnali\TestPurposes\Accela.doc", "test document", recordId, token);
            //List<Dictionary<string, string>> s = rec.GetRecordCustomFields(recordId, token);
            //rec.UpdateRecordCustomFields(recordId, s, token);
            
            
            ////List<Record> records = rec.GetRecords(token, filter, ref p, -1, 50);

            ////records = rec.SearchRecords(token, new RecordFilter { module = "Licenses" }, null, ref p);
            //////Agency agency = a.GetAgency(token, "BPTMSTR");
            //////a.GetAgencyLogo(@"c:\swapnali\", token, "BPTMSTR");
            ////record = rec.GetRecord(recordId, token);
            //////rec.UpdateRecordDetail(record, token);
            ////List<Document> docs = rec.GetRecordDocuments(recordId, token);
            ////List<Contact> contacts = rec.GetRecordContacts(recordId, token, ref p);

            ////record = new Record { type = new RecordType { id = "Licenses-Animal-Dog-Application" } };
            ////record.contacts = contacts;


            //record = rec.GetRecord(rId, token);
            //RecordId r1 = rec.CreateRecordInitialize(record, token);
            //record = rec.GetRecord(r1.id, token);
            //RecordId r2 = rec.CreateRecordFinalize(record, token);
            //if (r != null)
            //{
            //    List<Contact> cs = new List<Contact>();
            //    Contact c = new Contact();
            //    c.firstName = "Rose";
            //    c.type = new ContactType { value = "Pet Owner" };
            //    c.email = "Rose@accela.com";
            //    cs.Add(c);
            //    c.recordId = new RecordId { id = r.id };
            //    Result res = rec.CreateRecordContact(cs, r.id, token);

            //    record = rec.GetRecord(r.id, token);
            //    contacts = rec.GetRecordContacts(r.id, token, ref p);
            //}


            //rec.UpdateRecordContact(contacts[1], recordId, token);
            //rec.DeleteRecordContact(contacts[1].id, recordId, token);
            //List<RecordFees> fs = rec.GetRecordFees(recordId, token);

            //rec.CreateRecordDocument(@"C:\Swapnali\TestPurposes\Accela.doc", "test document", recordId, token);
            //Document d = doc.GetDocument("401", token);
            //doc.DownloadDocument("C:\\Swapnali\\TestPurposes\\test.jpeg", "401", token);

            //foreach (Dictionary<string, string> str in s)
            //{
            //    if (str != null && str.ContainsKey("Pet Name"))
            //    {
            //        str["Pet Name"] = "SDK Test";
            //        break;
            //    }
            //}
            //rec.UpdateRecordDetail(record, token);
            //rec.UpdateRecordCustomFields(recordId, s, token);

            //rec.CreateRecord(record, token);

            IAuth auth = new AuthHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            //auth.Login(RedirectUrl, Scope, "BPTMSTRV4", "PROD");
            //UserProfile user = auth.GetUserProfile(token);

            //contacts = rec.SearchRecordContacts(token, null, ref p);
            //List<ContactType> cts = rec.GetContactTypes(token);
        }
    }
}
