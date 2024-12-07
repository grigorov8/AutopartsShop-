using AutoPartsShop.Core.Contracts;
using AutoPartsShop.Core.Models;
using AutoPartsShop.Infrastructure.Database.Common;
using AutoPartsShop.Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoPartsShop.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly IRepository _repository;

        public CategoryService(IRepository repository)
        {
            _repository = repository;
        }

       
        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            
            return await _repository.AllReadOnly<Category>().ToListAsync();

        }


        public async Task<IEnumerable<Part>> GetPartsByCategoryIdAsync(int categoryId)
        {
            var category = await _repository
                .AllReadOnly<Category>()
                .Include(c => c.Parts) 
                .FirstOrDefaultAsync(c => c.Id == categoryId);

            if (category == null)
            {
                return Enumerable.Empty<Part>();
            }

            return category.Parts ?? Enumerable.Empty<Part>();
        }




    }
}
