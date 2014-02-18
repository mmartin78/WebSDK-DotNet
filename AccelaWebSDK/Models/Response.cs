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
        public string Code { get; set; }
        public string Message { get; set; }
        public PaginationInfo Page { get; set; }
        public Object Result { get; set; }
    }

    public class PaginationInfo
    {
        public int offset { get; set; }
        public int limit { get; set; }
        public bool hasmore { get; set; }
    }

    public class ResultPagedBase
    {
        public PaginationInfo PageInfo { get; set; }
    }

    public class ResultDataPaged<T> : ResultPagedBase
    {
        public IEnumerable<T> Data { get; set; }
    }

    public class Result
    {
        public List<string> failedIDs { get; set; }
        public int failedCount { get; set; }
        public int successCount { get; set; }
        public List<string> successIDs { get; set; }
    }
}
