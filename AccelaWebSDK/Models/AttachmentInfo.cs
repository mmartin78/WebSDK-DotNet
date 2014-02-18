using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;

namespace Accela.Web.SDK.Models
{
    public class AttachmentInfo
    {
        public StreamContent FileContent { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string Description { get; set; }
        public string ServiceProviderCode { get; set; }
    }
}

