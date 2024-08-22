using System;
using System.Collections.Generic;
using System.Text;

namespace MI.DataResponse.Lib
{
    /// <summary>
    /// Có thể dùng để trả dữ liệu từ 1 service, chứa đủ 2 thông tin về list data và total rows
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataResponse<T>
    {
        public virtual int TotalRows { get; set; }
        public virtual IEnumerable<T> ListData { get; set; }
    }
   
}
