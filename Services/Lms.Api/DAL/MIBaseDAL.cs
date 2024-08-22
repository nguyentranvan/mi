using MI.DataResponse.Lib;
using MI.DBContext.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace MI.DAL.Lib
{
    public interface IDALBase<TModel>
    {
        Task<TModel> Get(object id);
        Task<DataResponse<TModel>> GetAll();

        void Add(TModel obj);

        Task AddRange(List<TModel> list);

        void Delete(TModel obj);

        Task<int> SaveChangesAsync();


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

        public virtual async Task<DataResponse<TModel>> GetAll()
        {
            var data = new DataResponse<TModel>
            {
                TotalRows = await dbContext.Set<TModel>().CountAsync(),
                ListData = await dbContext.Set<TModel>().Select(c => c).ToListAsync()
            };
            return data;
        }

        public virtual void Add(TModel obj)
        {
            dbContext.Set<TModel>().AddAsync(obj);
        }

        public virtual async Task AddRange(List<TModel> list)
        {
            await dbContext.Set<TModel>().AddRangeAsync(list);
        }

        public virtual async Task<int> SaveChangesAsync()
        {
            var i = await dbContext.SaveChangesAsync();
            return i;
        }


        public virtual void Delete(TModel obj)
        {
            dbContext.Set<TModel>().Remove(obj);
        }
    }
}
