using MI.DAL.Lib;
using MI.DBContext.Models;

namespace Lms.API.DAL
{
    public class WeatherForecastDAL : DALBase<Aprofile, DBContext>
    {
        public WeatherForecastDAL(DBContext db) : base(db) { }
    }
}
