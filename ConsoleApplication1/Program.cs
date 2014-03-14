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
    // Update custom attributes
    // download doc

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
            string taskId = "1-12714";

            //string token = "_3m1WrctvYBv3HrA-AQHaH1ObNf-cQBfBOY7__ILN74qN-i4A_QosCExLd4ep7sNC2hFuxI8yVXk0GXZHG8SV5awV2RIospjJLJqjJym-KrYBJPSNqalcZ_gouu_MfM5j2YvqAg7QDnLGPH6wKFx11Wnj7OHjAA57eZC8Uk4vqwXJtQsbfiew8oakkZJm6lt6RC8YZWBVbrK-0m-JnMpo3ofumXgGjXMIQAtr9AmTUGLy9dInLHq1kcDScQG95gEcYw_oZB7nzM-kRdqMfOEfmX3dD_63dELM0gDfgl470HychHv0B5Np77dGU56wHZE1wbf4QmBjVkSEh7xho12gCaSThnsDiAgaYkNltrqnXpUx_2LLbvcFW1Hs_bDSyil7uVqGQsxlc7Lvh2gs2_fGdzDZYhehXYKsP51PpdzTxjBplQLdLwOW60WxpzoActmo9aJQ7B76BaFIWzR7Q3-zz9PuNrC2xlnj0RSgjN-zkWBK94UF__-NxNKZfCvHZ1-tZghy7urt4f_2EgMIVoUjUOrJoEM26wBC_rOllWsSz41";

            string token = "_3m1WrctvYBv3HrA-AQHaDI6YsrPUws2DlqBuUwDISsQeS4CUyEEX8wqKJPoQbjEavivgOuU7JWwTNePLHG4zQ068MhfgXHscZktHlBnP-zs5ho0VqEIg-hgKlTDVsKZP0LJWpiYEWCVrKsuQpN2LVeiWVOVbGtzmFBknvq0rKGoqmScyAgMkLAKsQ9FyaFY8LFUxJqwfRu2Fmn5JHS72rECKg8gG-KGQpy1GbDmXhjqNCQwWwuT2BSVUyD0e8GxhN4hCvBRUFcZ_VmZmDGKjY6GYgHT5P59VPAa6SfZqhnzguZIUTfmcsH1gjqy4DMHiKmnhPn4eKo9b1W_1zx2ybayg6eLlkfnR18VWk4k8v2AlH1cEI28j6wEmgDwZb0onSh9kXYB7rSSGleGa-9n1rldGBD61vLbtjCjwJCT758HKsf9hD9NqITNPbwF2WnW0";
            
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
            RecordFilter f = new RecordFilter { module = "Licenses" };
            ResultDataPaged<Record> records = rec.SearchRecords(token, f);

            // Contact
            //List<ContactType> ct = con.GetContactTypes(token, "Licenses");
            //ResultDataPaged<Contact> cts = con.SearchContacts(token, new ContactFilter { email = "sdembla@accela.com" });

            //// Agency
            //Agency ag = a.GetAgency(token, "BPTMSTR");
            //AttachmentInfo att = a.GetAgencyLogo(token, "BPTMSTR"); // 404 Not found

            // Record Contact
            //ResultDataPaged<Contact> contacts = rec.GetRecordContacts(rId, token);
            //List<Contact> cs = new List<Contact> { 
            //    new Contact { isPrimary = "N", businessName = "test",
            //        firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", 
            //        address = new ContactAddress { addressLine1 = "500 San Blvd", city = "San Ramon", state = new State { value = "CA" },
            //        postalCode = "94566" },
            //        type = new ContactType { value = "Pet Owner" } },
            //new Contact()};

            //rec.CreateRecordContact(cs, rId, token);
            //contacts = rec.GetRecordContacts(rId, token);
            //Contact c = ((List<Contact>)contacts.Data)[0];
            //c.type.text = null;
            //rec.DeleteRecordContact(c.id, rId, token);
            //c.middleName = "tseting";
            //c = rec.UpdateRecordContact(c, rId, token);
            //contacts = rec.GetRecordContacts(rId, token);

            // Address
            //List<Country> cn = ad.GetCountries(token);
            //List<State> s = ad.GetStates(token);

            // Records
            Record record = rec.GetRecord(recordId, token);
            //record.name = "Test Test";
            //record.description = "Test Test";
            //record = rec.UpdateRecordDetail(record, token);
            //record = rec.GetRecord(recordId, token);
            //ResultDataPaged<Record> records = rec.SearchRecords(token, new RecordFilter { type = new RecordType { category = "Application" }, contact = new Contact { firstName = "Sam" } }, null);
            //records = rec.GetRecords(token, null);
            //record = new Record { type = new RecordType { id = "Licenses-Animal-Pig-Application" } };
            record.contacts = new List<Contact> { new Contact { firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet.cOwner" } } };
            Record r1 = rec.CreateRecordInitialize(record, token);
            record = rec.GetRecord(r1.id, token);
            ResultDataPaged<Contact> contacts = rec.GetRecordContacts(record.id, token);
            FileInfo file = new FileInfo(@"C:\Swapnali\TestPurposes\Ducky.jpeg");
            if (file != null)
            {
                AttachmentInfo at = new AttachmentInfo { FileType = "image/jpeg", FileName = "Ducky.jpeg", ServiceProviderCode = "BPTMSTR", Description = "Test" };
                at.FileContent = new StreamContent(file.OpenRead());
                rec.CreateRecordDocument(at, record.id, token, "ooo");
            }
            List<Document> docs = rec.GetRecordDocuments(record.id, token);
            //record.contacts = new List<Contact> { new Contact { id = "1234", firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet Owner" } } };
            record = rec.CreateRecordFinalize(record, token);
            contacts = rec.GetRecordContacts(record.id, token);
            docs = rec.GetRecordDocuments(record.id, token);

            // Documents
            //List<DocumentType> d = rec.GetRecordDocumentTypes(recordId, token);
            //List<Document> docs = rec.GetRecordDocuments(recordId, token);
            //doc.DownloadDocument("942", token);

            //FileInfo file = new FileInfo(@"C:\Swapnali\TestPurposes\Ducky.jpeg");
            //if (file != null)
            //{
            //    AttachmentInfo at = new AttachmentInfo { FileType = "image/jpeg", FileName = "Ducky.jpeg", ServiceProviderCode = "BPTMSTR", Description = "Test" };
            //    at.FileContent = new StreamContent(file.OpenRead());
            //    rec.CreateRecordDocument(at, recordId, token, "ooo");
            //}
            //rec.DeleteRecordDocument("1012", recordId, token);
            //List<Document> docs = rec.GetRecordDocuments(recordId, token);

            // Status
            //List<Status> s = rec.GetRecordStatuses("Licenses-Animal-Pig-Application", token);

            //// Workflow
            //List<WorkflowTask> w2 = rec.GetWorkflowTasks(recordId, token);
            //WorkflowTask w = rec.GetWorkflowTask(recordId, taskId, token);
            //UpdateWorkflowTaskRequest uw = new UpdateWorkflowTaskRequest { comment = "testing", status = new Status { value = "Issued" } };
            //w = rec.UpdateWorkflowTask(recordId, taskId, uw, token);

            // Fees
            //List<RecordFees> fs = rec.GetRecordFees(recordId, token);

            // Custom Fields
            List<Dictionary<string, string>> cf = rec.GetRecordCustomFields(recordId, token);
            List<Dictionary<string, string>> cfs = new List<Dictionary<string, string>>();
            Dictionary<string, string> val = new Dictionary<string,string>();
            val.Add("id", "LIC_DOG_LIC-GENERAL.cINFORMATION");
            val.Add("Name", "Woofy");
            cfs.Add(val);
            rec.UpdateRecordCustomFields(recordId, cfs, token);
        }
    }
}
