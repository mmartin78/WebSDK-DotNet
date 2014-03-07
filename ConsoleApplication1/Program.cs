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

            string token = "t9xWJgtflKXHTVtmby9duvYpSSC_DtV7wY1bS1FShta-JhwGlSElfvm0j_q-RZExHugqKPZcEpDJOmsQH_jHouF4hvfCzZPSdlGEK1xEPLKxhcN3T91lRhwtzYTE0pGS7m3Ddp7FOrFLBadap107zuFCiVkjRauY6EUC2BUHVm6rIGdQ2WAw7qJjU_Tl8NZqJXqkwR1QgtaDU30pSOMYM3aos3DpoAMjVwatMDU7uqW4EoPC8y8tzl97LXdxs-cRyQ_9xD_FujBhzGGuEJqh8WGKs5kd4cJ0i75Oip3XWgXdAx-j2Dd_xsXY9W460QFUAFwRbQe42JRpWwCuuc1Gl8VuJ3PEAeU4SHEyh4NK5feZyFTTaRICjhFIqZ-xUmyiVfQ53lHXFSJ_8mw-VbQlg7CpM5bu8P8JNk34pb_f08mK_DemzPKpS_gTfZ_dsiP-boQf5HP85TMgKW7pMpjTUq0bWs4zaVh0K9QQKeBgbi12SzRQjaEQqFs-39f63c8FJva5OwGR-bXuYGwQNYnSqgze4Y9Nrc6w9zJ26fOGkgQ1";

            //IRecord rec = new RecordHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);
            //IDocument doc = new DocumentHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);
            //IAgency a = new AgencyHandler("635210919794773261", "7863eb97bb8f4f4c8a87f45f7b033d9d", ApplicationType.Citizen);

            IRecord rec = new RecordHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            IDocument doc = new DocumentHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            IAgency a = new AgencyHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            IAddress ad = new AddressHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);
            IContact con = new ContactHandler("635210919579930886", "dcb5ed05e6974820aa661a9fb5307cc5", ApplicationType.Agency);

            // Contact
            //List<ContactType> ct = con.GetContactTypes(token, "Licenses");
            //ResultDataPaged<Contact> cts = con.SearchContacts(token, new ContactFilter { email = "sdembla@accela.com" });

            //// Agency
            //Agency ag = a.GetAgency(token, "BPTMSTR");
            //AttachmentInfo att = a.GetAgencyLogo(token, "BPTMSTR"); // 404 Not found

            // Record Contact
            ResultDataPaged<Contact> contacts = rec.GetRecordContacts(rId, token);
            List<Contact> cs = new List<Contact> { 
                new Contact { isPrimary = "N", businessName = "test",
                    firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", 
                    address = new ContactAddress { addressLine1 = "500 San Blvd", city = "San Ramon", state = new State { value = "CA" },
                    postalCode = "94566" },
                    type = new ContactType { value = "Pet Owner" } }};

            rec.CreateRecordContact(cs, rId, token);
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
            record.name = "Test Test";
            record.description = "Test";
            record = rec.UpdateRecordDetail(record, token);
            record = rec.GetRecord(recordId, token);
            //ResultDataPaged<Record> records = rec.SearchRecords(token, new RecordFilter { type = new RecordType { category = "Application" }, contact = new Contact { firstName = "Sam" } }, null);
            //records = rec.GetRecords(token, null);
            //record = new Record { type = new RecordType { id = "Licenses-Animal-Pig-Application" } };
            //record.contacts = new List<Contact> { new Contact { firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet.cOwner" } } };
            //Record r1 = rec.CreateRecordInitialize(record, token);
            //record = rec.GetRecord(r1.id, token);
            //record.contacts = new List<Contact> { new Contact { id = "1234", firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet Owner" } } };
            //record = rec.CreateRecordFinalize(record, token);

            // Documents
            //List<DocumentType> d = rec.GetRecordDocumentTypes(recordId, token);
            //List<Document> docs = rec.GetRecordDocuments(recordId, token);
            //doc.DownloadDocument("942", token);

            FileInfo file = new FileInfo(@"C:\Swapnali\TestPurposes\Ducky.jpeg");
            if (file != null)
            {
                AttachmentInfo at = new AttachmentInfo { FileType = "image/jpeg", FileName = "Ducky.jpeg", ServiceProviderCode = "BPTMSTR", Description = "Test" };
                at.FileContent = new StreamContent(file.OpenRead());
                rec.CreateRecordDocument(at, recordId, token, "ooo");
            }
            rec.DeleteRecordDocument("1012", recordId, token);
            List<Document> docs = rec.GetRecordDocuments(recordId, token);

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
            rec.UpdateRecordCustomFields(recordId, cf, token);
        }
    }
}
