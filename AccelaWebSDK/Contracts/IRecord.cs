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
        ResultDataPaged<Record> GetRecords(string token, string filter, int offset = -1, int limit = -1);
        RecordId CreateRecord(Record record, string token);
        RecordId CreateRecordInitialize(Record record, string token);
        RecordId CreateRecordFinalize(Record record, string token);
        Record UpdateRecordDetail(Record record, string token);
        void DeleteRecord(string recordId, string token);
        ResultDataPaged<Record> SearchRecords(string token, RecordFilter filter, string fields, int offset = -1, int limit = -1);

        // Related Records
        List<Record> GetRelatedRecords(string recordId, string token);

        // Record Fees
        List<RecordFees> GetRecordFees(string recordId, string token);

        // Record Contacts
        ResultDataPaged<Contact> GetRecordContacts(string recordId, string token, int offset = -1, int limit = -1);
        ResultDataPaged<Contact> SearchRecordContacts(string token, string filter, int offset = -1, int limit = -1);
        List<ContactType> GetContactTypes(string token);
        Result CreateRecordContact(List<Contact> contacts, string recordId, string token);
        Contact UpdateRecordContact(Contact contact, string recordId, string token);
        void DeleteRecordContact(string contactId, string recordId, string token);

        // Record Documents
        List<Document> GetRecordDocuments(string recordId, string token);
        void CreateRecordDocument(string documentPath, string documentDescription, string recordId, string token);
        void DeleteRecordDocuments(string recordId, string token);
        void DeleteRecordDocument(string documentId, string recordId, string token);
        List<DocumentType> GetRecordDocumentTypes(string recordId, string token);

        // Record Custom Fields
        // Response DescribeRecordCustomFields(string recordTypeId, string token);
        List<Dictionary<string, string>> GetRecordCustomFields(string recordId, string token);
        List<Dictionary<string, string>> UpdateRecordCustomFields(string recordId, List<Dictionary<string, string>> customFieldList, string token);

        // Record Workflows
        List<WorkflowTask> GetWorkflowTasks(string recordId, string token, bool returnActiveOnly = false);
        WorkflowTask GetWorkflowTask(string recordId, string taskId, string token);
        WorkflowTask UpdateWorkflowTask(string recordId, string taskId, UpdateWorkflowTaskRequest workflowTask, string token);

        // Record Status
        List<Status> GetRecordStatuses(string recordTypeId, string token);
    }
}
