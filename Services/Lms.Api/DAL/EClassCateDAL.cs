using MI.DAL.Lib;
using MI.DataResponse.Lib;
using MI.DBContext.Models;
using Microsoft.EntityFrameworkCore;

namespace Lms.API.DAL
{
    public interface IEClassCateDAL : IDALBase<EClassCate>
    {
        Task<DataResponse<EClassCate>> Search(int offset, int limit, string keyword);
        Task<DataResponse<EClassCate>> SearchByParentId(Guid parentId);
    }
    public class EClassCateDAL : DALBase<EClassCate, DBContext>, IEClassCateDAL
    {
        public EClassCateDAL(DBContext db) : base(db) { }


        public async Task<DataResponse<EClassCate>> Search(int offset, int limit, string keyword)
        {
            var query = from m in dbContext.EClassCate
                        where m.Code.Contains(keyword)|| m.Name.Contains(keyword)
                        select m;
            var data = new DataResponse<EClassCate>
            {
                TotalRows = query.Any() ? await query.Select(s => 1).CountAsync() : 0,
                ListData = await query.Skip(offset).Take(limit).ToListAsync(),
            };
            return data;
        }
        public async Task<DataResponse<EClassCate>> SearchByParentId(Guid parentId)
        {
            var query = from m in dbContext.EClassCate
                        where m.ParentId == parentId
                        select m;
            var data = new DataResponse<EClassCate>
            {
                TotalRows = query.Any() ? await query.Select(s => 1).CountAsync() : 0,
                ListData = await query.ToListAsync(),
            };
            return data;
        }
    }
}
