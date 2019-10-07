namespace Artity.Services.Data.Category
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoryService(IDeletableEntityRepository<Category> context)
        {
            this.categoryRepository = context;
        }

        public async Task<IList<string>> GetAllCategoriesNamesAsync()
            => await this.categoryRepository.All().Select(a => a.Name).ToListAsync();

        public async Task<string> GetCategoryIdAsync(string name)
        {
           var category = await this.categoryRepository
                                    .All()
                                    .FirstOrDefaultAsync(a => a.Name == name);
           return category?.Id;
        }
    }
}
