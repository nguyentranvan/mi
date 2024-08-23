using System;
using System.Collections.Generic;
using System.Text;

namespace MI.HttpResponses.Lib
{
    public class ApiResponse
    {
        public bool Status { get; set; } = true;
        public string Message { get; set; } 
        public string Code { get; set; } 
        public object Data { get; set; }
        public object Exception { get; set; }
        public ApiResponseMetaData MetaData { get; set; }
        public static ApiResponse WithData(List<object> list, string message = null)
        {
            return new ApiResponse
            {
                Data = list,
                Message = message,
                Status = true
            };
        }

    }

    public class ApiResponseMetaData
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalRecord { get; set; }
    }
}
