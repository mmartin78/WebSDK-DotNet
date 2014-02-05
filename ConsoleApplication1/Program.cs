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

            string token = "ha4BkHZp7RML_70ZN84ijzic4zHmVnIGWIiuQ9vVtbirnW7VahYCSqZQ6An8CRcP3Ar6zPn8NBWYT7PfiZrKcqvEqjmMi-Yso56sZ4Cno4HG9TuBzwGIZgt93TV5k_IFG9F8ToLStFZL9ex1cJKf5Q6Gq17Qqw1zEl2zxO6xqLaoqUjripltsT_0qXKVKnvBorAsXIy34doouBhSEQ1KjyhZxAAtemc92vb94rZptStnaCPDJKNr4WnvuQwCAYXMf44cVy0TKAkTGkklhWzFfpy8cfoZsdidPi96mPFzbl8SbIIK0Kb2K0xfvYdIM2ugZVLLQbwHitL8v8TipBjDDKG2IRCUoI3TD8lUfXO52xYbVRWkQy_Z5GVCOfKrntPlFHOLdMByxOjmI4RQX1mtaMG3mBlZbpRNnSqrblvc9GhY7vRocJyS1yjTigZV56wHPkuhAVyvsdLs2CY5A798Foth2ewLesscNMnvMeEe9SfCEa7dZKqIdz1Q3yBQJz28-kn6OPS3OTKId31Qyx8fRBZPQscXpjcv_5hIxgu0gVkEdY-f5uXQ7rFkQ9QoNBDr0";
            // citizen string token = "gKUREWXm1DkIMO702NZNS-NtaZpVJpA4lKcewZD3CCvtAa9bN2k4_0CdzSTKaFkFJKzXiJihvNFJ8oPAgWLfbM-WGsprx5ZnB-UQYt6v3fzbrnpaAdlTDWoX9s3FElNpO5f79aBoKYpvkozYL3PpvniKFj2SL181PDqAH77di4nOX5F9q1N3UTCfVLyKUBYANfyPVDByYukHdCDhG_6DLlB9vc_kw2gwB4EQKHGMkCAyywTSA6nwBXwvmCh064tc_36bms6l_7aemoe0tH9xVUsy61VLQcw0gHcf723Ru2yb-lfZEA6WK4z7UnpGUQoD50HxSEduSx5hOmsVQCdCuheZ0JjlXE44ln3xAq6ZxlhQvzIxleIOA8Mq2tVE3pSNz9727QZiiSPATkNYYve0lYKTwdCS9qsk6IkjOgiaxRQxfQLR4vzXkyXqDElp5RKcKqLca64jap70EmDtgkXtAsOZw1NPDesjB214VObov90yDAAKSqMkpJrT1CqhggHaXnCmDj--BqOXt1z-QwTb3g2";

            IRecord rec = new RecordHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);
            IDocument doc = new DocumentHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);
            IAgency a = new AgencyHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);


            //Record record = new Record { type = new RecordType { id = "Licenses-Animal-Pig-Application" } };
            //record.contacts = new List<Contact> { new Contact { firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet.cOwner" }}};
            //RecordId r1 = rec.CreateRecordInitialize(record, token);
            Record record = rec.GetRecord("BPTMSTR-14EST-00000-00032", token);
            record.contacts = new List<Contact> { new Contact { firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet.cOwner" } } };
            RecordId r2 = rec.CreateRecordFinalize(record, token);

            //IRecord rec = new RecordHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            //IDocument doc = new DocumentHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            //IAgency a = new AgencyHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);

            //doc.DownloadDocument(@"C:\Swapnali\TestPurposes\test.jpeg", "401", token);
            //rec.CreateRecordDocument(@"C:\Swapnali\TestPurposes\Accela.doc", "test document", recordId, token);
            //List<Dictionary<string, string>> s = rec.GetRecordCustomFields(recordId, token);
            //rec.UpdateRecordCustomFields(recordId, s, token);
            List<Record> records = rec.GetRecords(token, filter, ref p, -1, 50);

            records = rec.SearchRecords(token, new RecordFilter { module = "Licenses" }, null, ref p);
            //Agency agency = a.GetAgency(token, "BPTMSTR");
            //a.GetAgencyLogo(@"c:\swapnali\", token, "BPTMSTR");
            record = rec.GetRecord(recordId, token);
            //rec.UpdateRecordDetail(record, token);
            List<Document> docs = rec.GetRecordDocuments(recordId, token);
            List<Contact> contacts = rec.GetRecordContacts(recordId, token, ref p);

            record = new Record { type = new RecordType { id = "Licenses-Animal-Dog-Application" } };
            record.contacts = contacts;
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
