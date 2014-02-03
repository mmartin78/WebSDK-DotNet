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
    // search record - done
    // create record - done
    // create contacts - done
    // update custom fields - done
    // upload doc - bug
    // download doc - bug
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
            string rId = "BPTMSTR-14EST-00000-00017";

            string token = "ZQZmZCmHyhIH94CXgLIY-Xb6UxhTwh4sYixKaFXYP0YIVbgFc24XJht7ALCNrM08YpAXmcaygMPBtvZfhnuBFkXV5K0kyJCsOfN1SdaKpcS3hEHRh9ORzuqFOOt-RgX71Cgfwveae7GZasJnWbqt0wC8QfGFTTV0leUCkysJpVmsDCBTEGC2fp0Yy5flCI45J5lJfRIxScmw2n5SStYfZMniv1MHTUDobDtQzHjM_O4_NSuY7qVDV2U2gOUJfUbtHDgaX6rnhkKeXsEy7y3kqJr3R5dHQ5A10dG6bAZ1iUj8EgXsBmeiOlh3D4TO4acbt4vvsR4sikMDAE9w_2oZpiaKd7iGkNcuqMdW1MApnTH2fmpXgV786zLQ6esXcD6u_ot0NJFLSgikSyuKfbGWUNGWRXv4umgHjIdbJ_JVipQoKTS1a3sfv-MmU6BwcEH3t05d7z-7PZJe7tOIlMwqy2YAAxz3SIl2e2-3hRULvTgArUKJh948MMXWUSiZeUNXV3kkIoj149Y65jK1MLkBue34xR71PJetxg-6Ze1TyC41";
            //Citizen string token = "vSKHIfBzwX-hBJ8NFdwOs3nvYjQ-iOLrsRH2fuIGGmpFThTxvargTjj1o7uE7E4wuQvoLGEOzu-FDbcTi9ArkIGz1fiCGH9i-1ibgFYH3sj6o3ItpFwBZyScWc1uHmvk5pT55S1ep-ABxJjZbj7L76s0PfTeT__XasMgZWeCHMPNjfN2fRU2ljLV6Q-3RGN4urt0To07tyqZIbKPOPoWw00xwzKu_xulXZdkSy-AVtPxu8iAZlXQrtX9c9F3k3uDRC9VFXc8OlWwVWfncsrb7U5jOLQ8B-Me8X-LsUoVXo9F3vb-FlDwTBFQC5eda4jiGMD_e0RkuRWFK2n9ksqAiqUIGoUjPYwQCzFXxIN6lTU2xmCuv3dhMGPKOkKg9A4QYYS5ag78HrvQY_1dmCdarDhJ6Xu7zulCQu8w-HStoEe9i8fSEuq0RCCpRmG73sDen2VVoUNjzSkVk_El5U-rY5KtA3eQOr_T-ZheLc2O8UZcfZh82Zs9zXUnQcLHGLr51I3zUckKa_pNoUZRsDJFwqThCv5i9RclK-6Xy8MxYBc1";

            IRecord rec = new RecordHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            IDocument doc = new DocumentHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);

            //doc.DownloadDocument(@"C:\Swapnali\TestPurposes\test.jpeg", documentId, token);
            //rec.CreateRecordDocument(@"C:\Swapnali\TestPurposes\Accela.doc", "test document", recordId, token);
            //List<Dictionary<string, string>> s = rec.GetRecordCustomFields(recordId, token);
            //rec.UpdateRecordCustomFields(recordId, s, token);
            //List<Record> records = rec.GetRecords(token, filter, ref p, -1, 50);

            //List<Record> records = rec.SearchRecords(token, new RecordFilter { module = "Licenses" }, null, ref p);
            Record record = rec.GetRecord(recordId, token);
            //rec.UpdateRecordDetail(record, token);
            //List<Document> docs = rec.GetRecordDocuments(recordId, token);
            List<Contact> contacts = rec.GetRecordContacts(recordId, token, ref p);

            record = new Record { type = new RecordType { id = "Licenses-Animal-Dog-Application" } };
            record.contacts = contacts;
            //record = rec.GetRecord(rId, token);
            RecordId r1 = rec.CreateRecordInitialize(record, token);
            record = rec.GetRecord(r1.id, token);
            RecordId r2 = rec.CreateRecordFinalize(record, token);
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
