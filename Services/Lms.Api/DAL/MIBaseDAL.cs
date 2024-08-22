using MI.DBContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MI.DAL.Lib
{
    public interface IDALBase<TModel>
    {
        Task<TModel> Get(object id);
        IQueryable<TModel> GetAll();

        void Add(TModel obj);

        Task AddRange(List<TModel> list);

        void Delete(TModel obj);

    }

    public abstract class DALBase<TModel, TDbContext> : IDALBase<TModel>
       where TModel : class
       where TDbContext : DbContext
    {
        public readonly TDbContext dbContext;

        public DALBase(TDbContext db)
        {
            dbContext = db;
        }

        public virtual async Task<TModel> Get(object id)
        {
            return await dbContext.Set<TModel>().FindAsync(id);
        }

        public virtual IQueryable<TModel> GetAll()
        {
            return dbContext.Set<TModel>().Select(c => c).AsQueryable();
        }

        public virtual void Add(TModel obj)
        {
            dbContext.Set<TModel>().AddAsync(obj);
        }

        public virtual async Task AddRange(List<TModel> list)
        {
            await dbContext.Set<TModel>().AddRangeAsync(list);
        }

        public virtual async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }


        public virtual void Delete(TModel obj)
        {
            dbContext.Set<TModel>().Remove(obj);
        }
    }
}
