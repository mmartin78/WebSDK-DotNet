using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK.Models;

namespace Accela.Web.SDK
{
    public interface IContact
    {
        ResultDataPaged<Contact> SearchContacts(string token, ContactFilter filter, int offset = -1, int limit = -1);
        List<ContactType> GetContactTypes(string token, string module);
    }
}
