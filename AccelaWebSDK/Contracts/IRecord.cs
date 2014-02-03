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
        List<Record> GetRecords(string token, string filter, ref PaginationInfo paginationInfo, int offset = -1, int limit = -1);
        RecordId CreateRecord(Record record, string token);
        RecordId CreateRecordInitialize(Record record, string token);
        RecordId CreateRecordFinalize(Record record, string token);
        Record UpdateRecordDetail(Record record, string token);
        void DeleteRecord(string recordId, string token);
        List<Record> SearchRecords(string token, RecordFilter filter, string fields, ref PaginationInfo paginationInfo, int offset = -1, int limit = -1);

        // Related Records
        List<Record> GetRelatedRecords(string recordId, string token);

        // Record Fees
        List<RecordFees> GetRecordFees(string recordId, string token);

        // Record Contacts
        List<Contact> GetRecordContacts(string recordId, string token, ref PaginationInfo paginationInfo, int offset = -1, int limit = -1);
        List<Contact> SearchRecordContacts(string token, string filter, ref PaginationInfo paginationInfo, int offset = -1, int limit = -1);
        List<ContactType> GetContactTypes(string token);
        Result CreateRecordContact(List<Contact> contacts, string recordId, string token);
        Contact UpdateRecordContact(Contact contact, string recordId, string token);
        void DeleteRecordContact(string contactId, string recordId, string token);

        // Record Documents
        List<Document> GetRecordDocuments(string recordId, string token);
        Document CreateRecordDocument(string documentPath, string documentDescription, string recordId, string token);
        void DeleteRecordDocuments(string recordId, string token);
        void DeleteRecordDocument(string documentId, string recordId, string token);

        // Record Custom Fields
        // Response DescribeRecordCustomFields(string recordTypeId, string token);
        List<Dictionary<string, string>> GetRecordCustomFields(string recordId, string token);
        List<Dictionary<string, string>> UpdateRecordCustomFields(string recordId, List<Dictionary<string, string>> customFieldList, string token);

        // Record Workflows
        //Response GetWorkflowTasks(string recordId, string token, bool returnActiveOnly = false);
        //void UpdateWorkflowTask(string recordId, WorkflowTask workflowTask, string token);
    }
}
