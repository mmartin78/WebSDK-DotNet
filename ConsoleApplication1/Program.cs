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
    // Update workflow tasks

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

            string token = "LU1VHKQwxMdYEckXOC8-n27-HtibNaOiIZju4VUmU4JByvCqkuvef-4RqpUb3nSdK_aCSYy_om9Oa1loC-OeH145ybxvXZv3pzEaZ8zoV6fLB-gwzkwQLmbnWrybYcvCtC1uWJZbw852FF9JB_4EiFuf3yFrR1PQXokaANo0xj_HvCh4T-2_ZIGDWkB5km-i8r30CJA0CJ9mjHuEX81WVqZsDfEA21roEc_tbEJhin-yOT3Cx1AHfL3BECTClr_awwEmcZhUST4Z_LYz558W6EhS34liDuIdvnWpZnBeEfSPMgz6CmsqrDfW7Ml4CeA2TDZdzpYG5lHuudfOBetFsb1dHtXj0JjFaWmpwdvtxrUFDh53VB9zjSFsF12cvKaurZCMHCAuXGjOOJUXw5P2SPx7oS9xZuKzNkhkY_VpHnf5Gbv7shbTu2rOtBSR_X4aCwxZAh2JByJJ6y2Y1t-n3vftjs8uCSPwQRP9qlgi9HPSarDR0Bj642Nlq9h4JVvz16UsjBHNU1PBzaPLr_OOqyLgGVNa_OwgTfpCTtvSF1wnrlpjY41KOq796W53_Iad0";
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
            //ResultDataPaged<Contact> cts = con.SearchContacts(token, new ContactFilter { lastName = "Turman" });

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
            ////List<State> s = ad.GetStates(token);

            // Records
            Record record = rec.GetRecord(recordId, token);
            //record.name = "Test Test";
            //record = rec.UpdateRecordDetail(record, token);
            //ResultDataPaged<Record> records = rec.SearchRecords(token, new RecordFilter { type = new RecordType { category = "License" }, contact = new Contact { firstName = "Igor" } }, null);
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
            ////doc.DownloadDocument("401", token);

            //FileInfo file = new FileInfo(@"C:\Swapnali\TestPurposes\Ducky.jpeg");
            //if (file != null)
            //{
            //    AttachmentInfo at = new AttachmentInfo { FileType = "image/jpeg", FileName = "Ducky.jpeg", ServiceProviderCode = "BPTMSTR", Description = "Test" };
            //    at.FileContent = new StreamContent(file.OpenRead());
            //    rec.CreateRecordDocument(at, recordId, token, "ooo");
            //}
            //rec.DeleteRecordDocument("746", recordId, token);
            //docs = rec.GetRecordDocuments(recordId, token);

            // Status
            //List<Status> s = rec.GetRecordStatuses("Licenses-Animal-Pig-Application", token);

            // Workflow
            //List<WorkflowTask> w2 = rec.GetWorkflowTasks(recordId, token);
            //WorkflowTask w = rec.GetWorkflowTask(recordId, taskId, token);
            //UpdateWorkflowTaskRequest uw = new UpdateWorkflowTaskRequest { comment = "testing", status = new Status { value = "Issued" } };
            //w = rec.UpdateWorkflowTask(recordId, taskId, uw, token);

            // Fees
            //List<RecordFees> fs = rec.GetRecordFees(recordId, token);

            // Custom Fields
            //List<Dictionary<string, string>> cf = rec.GetRecordCustomFields(recordId, token);
            //rec.UpdateRecordCustomFields(recordId, cf, token);
        }
    }
}
