﻿using System;
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
        Record GetRecord(string recordId, string token, string expand = null);
        ResultDataPaged<Record> GetRecords(string token, string filter, int offset = -1, int limit = -1);
        ResultDataPaged<Record> GetMyRecords(string token, string filter, int offset = -1, int limit = -1);
        Record CreateRecord(Record record, string token);
        Record CreateRecordInitialize(Record record, string token, string isFeeEstimate = null);
        Record CreateRecordFinalize(Record record, string token);
        Record UpdateRecordDetail(Record record, string token);
        void DeleteRecord(string recordId, string token);
        ResultDataPaged<Record> SearchRecords(string token, RecordFilter filter, string fields = null, int offset = -1, int limit = -1, string sortField = null, string sortOrder = null, string expand = null);

        // Related Records
        List<RelatedRecord> GetRelatedRecords(string recordId, string token, string relationship = null, string fields = null);

        // Record Fees
        List<RecordFees> GetRecordFees(string recordId, string token, string fields = null, string status = null);
        List<FeeSchedule> GetFeeScheduleForRecordType(string recordTypeId, string token);

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

        // Record Addresses
        List<Address> GetRecordAddresses(string recordId, string token, string isPrimary = null, string fields = null);
        List<Result> CreateRecordAddresses(List<Address> addresses, string recordId, string token);
        Address UpdateRecordAddress(Address address, string recordId, string token);
        void DeleteRecordAddresses(string addressIds, string recordId, string token);

        // Record CustomTables
        List<CustomTables> GetRecordCustomTables(string recordId, string token);
        List<CustomTables> UpdateRecordCustomTables(string recordId, List<CustomTables> customTableList, string token);

        // Record Type Custom Fields
        List<CustomForm> GetRecordTypeCustomForms(string recordTypeId, string token);
        List<FeeSchedule> GetRecordTypeFeeSchedules(string recordTypeId, string token);
        List<RecordType> GetRecordTypes(string module, string token);
        RecordTypeRequirements GetRecordTypeRequirements(string recordTypeId, string token);
    }
}
