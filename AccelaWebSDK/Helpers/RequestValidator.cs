using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Accela.Web.SDK.Models;

namespace Accela.Web.SDK
{
    public static class RequestValidator
    {
        public static void ValidateToken(string token)
        {
            if (string.IsNullOrEmpty(token))
                throw new Exception("Please provide an authentication token");
        }

        public static List<Contact> ValidateContactsForCreate(List<Contact> contacts, string recordId)
        {
            if (contacts == null)
            {
                throw new Exception("Null request provided");
            }
            else
            {
                foreach (Contact contact in contacts)
                {
                    if (contact == null)
                        throw new Exception("Null contact provided");
                    if (contact.type == null || string.IsNullOrEmpty(contact.type.value))
                        throw new Exception("A valid contact type is not provided");
                    if (contact.recordId == null)
                        contact.recordId = new RecordId { id = recordId };
                }
            }
            
            return contacts;
        }

        public static RecordType BuildRecordTypeFromTypeId(RecordType recordType, string recordTypeId)
        {
            if (string.IsNullOrEmpty(recordTypeId))
                return null;

            if (recordType == null)
                recordType = new RecordType();

            // Licenses-Animal-Dog-Application
            string[] recordTypeAttributes = recordTypeId.Split('-');
            if (recordTypeAttributes != null && recordTypeAttributes.Length == 4)
            {
                if (string.IsNullOrEmpty(recordType.group) && !string.IsNullOrEmpty(recordTypeAttributes[0]))
                {
                    recordType.group = recordTypeAttributes[0];
                    recordType.module = recordTypeAttributes[0];
                }
                if (string.IsNullOrEmpty(recordType.type) && !string.IsNullOrEmpty(recordTypeAttributes[1]))
                    recordType.type = recordTypeAttributes[1];
                if (string.IsNullOrEmpty(recordType.subType) && !string.IsNullOrEmpty(recordTypeAttributes[2]))
                    recordType.subType = recordTypeAttributes[2];
                if (string.IsNullOrEmpty(recordType.category) && !string.IsNullOrEmpty(recordTypeAttributes[3]))
                    recordType.category = recordTypeAttributes[3];
            }
            return recordType;
        }
    }
}
