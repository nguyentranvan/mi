using MI.DAL.Lib;
using MI.DataResponse.Lib;
using MI.DBContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Lms.API.DAL
{
    public interface IACertificateDAL : IDALBase<ACertificate>
    {
        Task<DataResponse<ACertificate>> Search(int offset, int limit, string keyword);
    }
    public class ACertificateDAL : DALBase<ACertificate, DBContext>, IACertificateDAL
    {
        public ACertificateDAL(DBContext db) : base(db) { }


        public async Task<DataResponse<ACertificate>> Search(int offset, int limit, string keyword)
        {
            var query = from m in dbContext.ACertificate
                        where m.Name.Contains(keyword)
                        select m;
            var data = new DataResponse<ACertificate>
            {
                TotalRows = query.Any() ? await query.Select(s => 1).CountAsync() : 0,
                ListData = await query.Skip(offset).Take(limit).ToListAsync(),
            };
            return data;
        }
    }
}
