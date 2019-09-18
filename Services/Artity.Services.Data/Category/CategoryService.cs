namespace Artity.Services.Data.Category
{
    using System.Collections.Generic;
    using System.Linq;

    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;

    public class CategoryService : ICategoryService
    {
        private readonly IDeletableEntityRepository<Category> context;

        public CategoryService(IDeletableEntityRepository<Category> context)
        {
            this.context = context;
        }

        public IList<string> GetAllCategories()
        {
            return this.context.All().Select(a => a.Name).ToList();
        }

        public string GetCategoryId(string name)
        {
           var category = this.context.All().FirstOrDefault(a => a.Name == name);
           return category.Id;
        }
    }
}
