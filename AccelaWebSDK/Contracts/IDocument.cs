using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK.Models;

namespace Accela.Web.SDK
{
    public interface IDocument
    {
        Document GetDocument(string documentId, string token, string fields = null);
        AttachmentInfo DownloadDocument(string documentId, string token, string password = null, string userId = null);
    }
}
