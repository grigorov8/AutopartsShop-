using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Infrastructure.Database.Common
{
    public interface IRepository : IDisposable
    {

        IQueryable<T> All<T>() where T : class;

        IQueryable<T> AllReadonly<T>() where T : class;

        Task<T?> GetByIdAsync<T>(object id) where T : class;


        Task AddAsync<T>(T entity) where T : class;

        Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class;

        Task DeleteAsync<T>(int Id) where T : class;

        Task<int> SaveChangesAsync<T>();







    }


}
