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
    // Create/Update/Get/delete Contact
    // Update custom attributes
    // Update Record Detail
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
            string recordId = "BPTMSTR-DUB13-00000-00005";
            string documentId = "DUB13-00000-00005-401";
            string rId = "BPTMSTR-DUB14-00000-00023";
            string taskId = "3-12713";

            string token = "jatObRB4QJUnPcrCbTfSB_dPMd6kJYp1uwpRrARewTniaZgEl8pyeGlSCatOpWEdbTnx26duD40FkQzYjDJsPSuIw88wnK6UBvjrqaUs1yc9ACFfVZ_-kN-l7rdR58y1b6bhXjcTE8caD5qGpe7mzHe9bDZ3eHihB6_1p_mEg-d3v5O3gFDBG696rrcD4yDR3riyBO9nsboyocgdjfHGWWgbo2ZGhLzZtWm7TjsPeozs4lAzwkPqB3q4bR-gq61xHUY7URMgCbs71cy79Vly3atyBVH6PlrhZb0G4lp5PtU2UcrdVVQHADDFJGvo9iGRbZrT72qiPnGwB_2PCyR6riWShoN0V_lC3meJop1NiNmljNl4eU7zxYInxzSJtPa0qhe1nXVpcuxxU7vsu47NKqoKOm8PoucBxFyzUUN03DEb7mHZ87qka7s7zDKmL3T9jcfyTm5ddecZbgrhvR5I462vgt9FkoF7jFxFvBWFki9V0I_e9iU95EJjqxw4lzATI1wBRmEKJLbSCvpRDdMDMiUxImpzNP2zN5SeBpDnZSPNA49dSjhBQ5uQX8ZYXnmRGKZ6cWTG6BgmCpoR_WV1_Q2";
            
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
           // ResultDataPaged<Contact> cts = con.SearchContacts(token, new ContactFilter { lastName = "Turman" });

            //// Agency
            //Agency ag = a.GetAgency(token, "BPTMSTR");
            //AttachmentInfo att = a.GetAgencyLogo(token, "BPTMSTR"); // 404 Not found

            // Record Contact
            //ResultDataPaged<Contact> contacts = rec.GetRecordContacts(rId, token);
            //List<Contact> cs = new List<Contact> { new Contact { firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet Owner" } } };
            //rec.CreateRecordContact(cs, rId, token);
            //contacts = rec.GetRecordContacts(rId, token);
            //Contact c = ((List<Contact>)contacts.Data)[0];
            //rec.DeleteRecordContact(c.id, recordId, token);
            //c.middleName = "tseting";
            //c = rec.UpdateRecordContact(c, rId, token);
            //contacts = rec.GetRecordContacts(recordId, token);

            // Address
            //List<Country> c = ad.GetCountries(token);
            //List<State> s = ad.GetStates(token);

            // Records
            //Record record = rec.GetRecord(recordId, token);
            //record.name = "Test Test";
            //record = rec.UpdateRecordDetail(record, token);
            //ResultDataPaged<Record> records = rec.SearchRecords(token, new RecordFilter { type = new RecordType { category = "License" } }, null);
            //records = rec.GetRecords(token, null);
            //Record record = new Record { type = new RecordType { id = "Licenses-Animal-Pig-Application" } };
            //record.contacts = new List<Contact> { new Contact { firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet.cOwner" }}};
            //Record r1 = rec.CreateRecordInitialize(record, token);
            //record = rec.GetRecord(r1.id, token);
            //record.contacts = new List<Contact> { new Contact { id = "1234", firstName = "Swapnali", lastName = "Dembla", email = "sdembla@accela.com", type = new ContactType { value = "Pet Owner" } } };
            //record = rec.CreateRecordFinalize(record, token);

            // Documents
            //List<DocumentType> d = rec.GetRecordDocumentTypes(recordId, token);
            //List<Document> docs = rec.GetRecordDocuments(recordId, token);
            //doc.DownloadDocument("401", token);

            //FileInfo file = new FileInfo(@"C:\Swapnali\TestPurposes\Ducky.jpeg");
            //if (file != null)
            //{
            //    AttachmentInfo at = new AttachmentInfo { FileType = "image/jpeg", FileName = "Ducky.jpeg", ServiceProviderCode = "BPTMSTR", Description = "Test" };
            //    at.FileContent = new StreamContent(file.OpenRead());
            //    rec.CreateRecordDocument(at, recordId, token, "ooo");
            //}
            //rec.DeleteRecordDocument("746", recordId, token);
            //List<Document> docs = rec.GetRecordDocuments(recordId, token);

            // Status
            //List<Status> s = rec.GetRecordStatuses("Licenses-Animal-Pig-Application", token);

            // Workflow
            //List<WorkflowTask> w2 = rec.GetWorkflowTasks(recordId, token, true);
            //WorkflowTask w = rec.GetWorkflowTask(recordId, taskId, token);
            //UpdateWorkflowTaskRequest uw = new UpdateWorkflowTaskRequest { comment = "testing", status = new Status { value = "About to Expire" } };
            //w = rec.UpdateWorkflowTask("BPTMSTR-DUB14-00000-0001Y", "1-12714", uw, token);

            // Fees
            //List<RecordFees> fs = rec.GetRecordFees(recordId, token);

            // Custom Fields
            //List<Dictionary<string, string>> cf = rec.GetRecordCustomFields(recordId, token);    
            //rec.UpdateRecordCustomFields(recordId, cf, token);
        }
    }
}
