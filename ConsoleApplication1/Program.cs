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
    // create record - done
    // create contacts - done
    // update custom fields - waiting for upgrade
    // upload doc
    // update contact
    // delete doc
    // get record - done
    // get records - done
    // get custom fields - done
    // get contacts - done
    // get docs - done
    // get doc - done

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

            string token = "7E6c7MEoX95peiy4SgMDa3UaTHOmq8F_uxJHqwsBZHXw1UeHQ_JDenzJYsYsQjWCda-tTSVTNxSGdwlTL1qRSHr7q5P3p5xwKc1wf7Re85F-v2nT9ofAA37rD68aNKT3e4JPZ1U3KE8RpIAhrY5aLTfn8PbYGSE-UdM22xHjZB0bsO84D6E4Om1C6ZKeN--6wtzDItXyT0oI0TSEiSyIA8OXewqCbHZLjKOOm83UJxImc1ISixmwlPS9j8GYFlnQquus79jefKnDXDjUK6Ei8mOKrAQDOmDnjDLKGNPK1ticNF9r3NBF9O0aYcGWmc-hNP58F0LcNpSXR-2gaV6n9goPduzyTc84MhhOZDDMnoZmHbxCg8ZL0Ojw0HTXfTqzVdCQFXtkwkh_1s4z8nkQD-Uvabz8S1OWJoah9Q-CnGHLFtr7-d8HR-wps_mhMAyj775ziTsZsAtzpKzVhH9FH3HJbmcVUm3ENreNfGxDD9MD4DtZa19rCdvRwq_fQjP0Ozyhup6h3LRKqpqaCBDFlrIiBfjWiKWwgdSxT1tZD8Q1";
            //Citizen string token = "vSKHIfBzwX-hBJ8NFdwOs3nvYjQ-iOLrsRH2fuIGGmpFThTxvargTjj1o7uE7E4wuQvoLGEOzu-FDbcTi9ArkIGz1fiCGH9i-1ibgFYH3sj6o3ItpFwBZyScWc1uHmvk5pT55S1ep-ABxJjZbj7L76s0PfTeT__XasMgZWeCHMPNjfN2fRU2ljLV6Q-3RGN4urt0To07tyqZIbKPOPoWw00xwzKu_xulXZdkSy-AVtPxu8iAZlXQrtX9c9F3k3uDRC9VFXc8OlWwVWfncsrb7U5jOLQ8B-Me8X-LsUoVXo9F3vb-FlDwTBFQC5eda4jiGMD_e0RkuRWFK2n9ksqAiqUIGoUjPYwQCzFXxIN6lTU2xmCuv3dhMGPKOkKg9A4QYYS5ag78HrvQY_1dmCdarDhJ6Xu7zulCQu8w-HStoEe9i8fSEuq0RCCpRmG73sDen2VVoUNjzSkVk_El5U-rY5KtA3eQOr_T-ZheLc2O8UZcfZh82Zs9zXUnQcLHGLr51I3zUckKa_pNoUZRsDJFwqThCv5i9RclK-6Xy8MxYBc1";

            IRecord rec = new RecordHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            IDocument doc = new DocumentHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);

            List<Dictionary<string, string>> s = rec.GetRecordCustomFields(recordId, token);
            List<Record> records = rec.GetRecords(token, filter, ref p);
            Record record = rec.GetRecord(recordId, token);
            List<Document> docs = rec.GetRecordDocuments(recordId, token);
            List<Contact> contacts = rec.GetRecordContacts(recordId, token, ref p);

            RecordId r = rec.CreateRecord(record, token);
            if (r != null)
            {
                List<Contact> cs = new List<Contact>();
                Contact c = new Contact();
                c.firstName = "Rose";
                c.type = new ContactType { value = "Pet Owner" };
                c.email = "Rose@accela.com";
                cs.Add(c);
                c.recordId = new RecordId { id = r.id };
                Result res = rec.CreateRecordContact(cs, r.id, token);

                record = rec.GetRecord(r.id, token);
                contacts = rec.GetRecordContacts(r.id, token, ref p);
            }


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
