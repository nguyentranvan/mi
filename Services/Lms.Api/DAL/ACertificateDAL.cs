using MI.DAL.Lib;
using MI.DBContext.Models;

namespace Lms.API.DAL
{
    public interface IACertificateDAL : IDALBase<ACertificate>
    {

    }
    public class ACertificateDAL : DALBase<ACertificate, DBContext>, IACertificateDAL
    {
        public ACertificateDAL(DBContext db) : base(db) { }
    }
}
