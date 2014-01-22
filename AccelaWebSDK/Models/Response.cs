using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Accela.Web.SDK.Models
{
    public class RESTResponse
    {
        public int Status { get; set; }
        public PaginationInfo Page { get; set; }
        public Object Result { get; set; }
    }

    public class PaginationInfo
    {
        public int offset { get; set; }
        public int limit { get; set; }
        public bool hasmore { get; set; }
    }

    public class Response { } // todo remove
}
