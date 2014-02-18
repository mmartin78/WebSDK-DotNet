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
        Agency GetAgency(string token, string agencyName);
        AttachmentInfo GetAgencyLogo(string token, string agencyName);
    }

    // get agencies
    // update agency info: - logo, text
    // enable/disable supported record types for agency
    // get supported record types for agency
    // get staff for agency
    // update staff for agency
    // get fees for record type
    // update fees for record type
}
