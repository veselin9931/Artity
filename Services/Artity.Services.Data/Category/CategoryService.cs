namespace Artity.Services.Data.Category
{
    using System.Collections.Generic;
    using System.Linq;

    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> categoryRepository;

        public CategoryService(IDeletableEntityRepository<Category> context)
        {
            this.categoryRepository = context;
        }

        public IList<string> GetAllCategories()
        {
            return this.categoryRepository.All().Select(a => a.Name).ToList();
        }

        public string GetCategoryId(string name)
        {
           var category = this.categoryRepository.All().FirstOrDefault(a => a.Name == name);
           return category.Id;
        }
    }
}
