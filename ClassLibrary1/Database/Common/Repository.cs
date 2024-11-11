using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoPartsShop.Infrastructure.Database.Common
{
    public class Repository : IRepository
    {

        private readonly AutoShopDbContext context;

        public Repository(AutoShopDbContext  _context) 
        { 

            context = _context;

        }

        protected DbSet<T> DbSet<T>() where T : class
        {

            return context.Set<T>();

        }


        public async Task AddAsync<T>(T entity) where T : class
        {
            await DbSet<T>().AddAsync(entity);
        }


        public async Task AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await DbSet<T>().AddRangeAsync(entities);
        }

        public IQueryable<T> All<T>() where T : class
        {
            return DbSet<T>();
        }

        public IQueryable<T> AllReadOnly<T>() where T : class
        {
            return DbSet<T>().AsNoTracking();
        }


        public async Task DeleteAsync<T>(int Id) where T : class
        {
           T? entity = await DbSet<T>().FindAsync(Id);
            DbSet<T>().Remove(DbSet<T>().Find(Id));


        }


        public void Dispose()
        {
            context.Dispose();
        }

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
        {
                
            return await DbSet<T>().FindAsync(id);

        }

        public async Task<int> SaveChangesAsync<T>()
        {

          return await context.SaveChangesAsync();

        }
    }

}
