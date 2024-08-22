using MI.DAL.Lib;
using MI.DBContext.Models;

namespace Lms.API.DAL
{
    public interface IAProfileDAL : IDALBase<AProfile>
    {

    }
    public class AProfileDAL : DALBase<AProfile, DBContext>, IAProfileDAL
    {
        public AProfileDAL(DBContext db) : base(db) { }
    }
}
