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
        Document GetDocument(string documentId, string token);
        void DownloadDocument(string filePath, string documentId, string token);
    }
}
