using AutoPartsShop.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;



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
           var entity = await DbSet<T>().FindAsync(Id);

            if (entity != null)
            {
                DbSet<T>().Remove(entity);
                
            }

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


        public IQueryable<CartItem> AllCartItemsForUser(string userId)
        {
            return DbSet<CartItem>().Where(ci => ci.UserId == userId);
        }


    }

}
