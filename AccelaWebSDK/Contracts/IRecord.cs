using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK.Models;

namespace Accela.Web.SDK
{
    public interface IRecord
    {
        // Records
        Record GetRecord(string recordId, string token);
        Response GetRecords(string token, int offset = -1, int limit = -1, string filter = null);
        string CreateRecord(Record record, string token);
        void UpdateRecord(Record record, string token);
        //void DeleteRecord(string recordId, string token);

        // Related Records
        Response GetRelatedRecords(string recordId, string token);

        // Record Fees
        Response GetRecordFees(string recordId, string token);

        // Record Contacts
        List<Contact> GetRecordContacts(string recordId, string token, int offset = -1, int limit = -1, string filter = null);
        Response SearchRecordContacts(string fullName, string contactTypeId, string token, int offset = -1, int limit = -1);
        Response GetContactTypes(string token);

        // Record Documents
        Response GetRecordDocuments(string recordId, string token);
        Document GetRecordDocument(string documentId, string recordId, string token);
        Document CreateRecordDocument(string documentPath, string documentDescription, string recordId, string token);
        void DeleteRecordDocuments(string recordId, string token);
        void DeleteRecordDocument(string documentId, string recordId, string token);
        void DownloadRecordDocument(string filePath, string documentId, string recordId, string token);

        // Record Custom Fields
        // Response DescribeRecordCustomFields(string recordTypeId, string token);
        //Response GetRecordCustomFields(string recordId, string token);

        // Record Workflows
        //Response GetWorkflowTasks(string recordId, string token, bool returnActiveOnly = false);
        //void UpdateWorkflowTask(string recordId, WorkflowTask workflowTask, string token);
    }
}
