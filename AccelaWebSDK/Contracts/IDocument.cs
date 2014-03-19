using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK.Models;
using System.IO;

namespace Accela.Web.SDK
{
    public interface IDocument
    {
        Document GetDocument(string documentId, string token, string fields = null);
        Stream DownloadDocument(string documentId, string token, string password = null, string userId = null);
        Task<Stream> DownloadDocumentAsync(string documentId, string token, string password = null, string userId = null);
    }
}
