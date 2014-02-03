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
    }
}
