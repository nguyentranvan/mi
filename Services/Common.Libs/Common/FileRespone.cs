using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MI.HttpResponses.Lib
{
    public class DefaultHttpResponseWithStatus<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool Success { get; set; }
        public string Message { get; set; }
        public string MessageCode { get; set; }
        public T Data { get; set; }

        public DefaultHttpResponseWithStatus()
        {
            Success = false;
        }
    }
    public class FileResponse
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public long Size { get; set; }
        public bool Status { get; set; }
        public string Message { get; set; }

        public string FileExt { get; set; }
        public string CreatedByUser { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string PhysicalPath { get; set; }
        public List<string> Others { get; set; } = new List<string>();
    }
}
