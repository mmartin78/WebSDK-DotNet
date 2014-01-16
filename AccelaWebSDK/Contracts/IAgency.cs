using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK.Models;

namespace Accela.Web.SDK
{
    public interface IAgency
    {
        Response GetRecordTypesForAgency(string module, string token, int limit = -1, int offset = -1);
        Agency GetAgency(string token);
        void GetAgencyLogo(string filePath, string token, string agencyId);

        // get agencies
        // update agency
        // update supported license types for agency
        // update license type info.
    }
}
