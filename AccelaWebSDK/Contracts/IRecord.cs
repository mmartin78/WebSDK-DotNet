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
        Record CreateRecord(Record record, string token);
        Record CreateRecordInitialize(Record record, string token, string isFeeEstimate = null);
        Record CreateRecordFinalize(Record record, string token);
        Record UpdateRecordDetail(Record record, string token);
        void DeleteRecord(string recordId, string token);
        ResultDataPaged<Record> SearchRecords(string token, RecordFilter filter, string fields = null, int offset = -1, int limit = -1);

        // Related Records
        List<RelatedRecord> GetRelatedRecords(string recordId, string token, string relationship = null, string fields = null);

        // Record Fees
        List<RecordFees> GetRecordFees(string recordId, string token, string fields = null, string status = null);
        List<RecordFees> GetRecordFeeSchedules(string recordId, string token);

        // Record Contacts
        ResultDataPaged<Contact> GetRecordContacts(string recordId, string token, string fields = null, int offset = -1, int limit = -1);
        List<Result> CreateRecordContact(List<Contact> contacts, string recordId, string token, string fields = null);
        Contact UpdateRecordContact(Contact contact, string recordId, string token, string fields = null);
        void DeleteRecordContact(string contactId, string recordId, string token, string fields = null);

        // Record Documents
        List<Document> GetRecordDocuments(string recordId, string token, string fields = null);
        string CreateRecordDocument(AttachmentInfo attachmentInfo, string recordId, string token, string group = null, string category = null, string password = null, string userId = null);
        void DeleteRecordDocument(string documentId, string recordId, string token, string password = null, string userId = null);
        List<DocumentType> GetRecordDocumentTypes(string recordId, string token);

        // Record Custom Fields
        List<Dictionary<string, string>> GetRecordCustomFields(string recordId, string token);
        List<Dictionary<string, string>> UpdateRecordCustomFields(string recordId, List<Dictionary<string, string>> customFieldList, string token);

        // Record Workflows
        List<WorkflowTask> GetWorkflowTasks(string recordId, string token, bool returnActiveOnly = false, string fields = null);
        WorkflowTask GetWorkflowTask(string recordId, string taskId, string token, string fields = null);
        WorkflowTask UpdateWorkflowTask(string recordId, string taskId, UpdateWorkflowTaskRequest workflowTask, string token, string fields = null);

        // Record Status
        List<Status> GetRecordStatuses(string recordTypeId, string token);
    }
}
