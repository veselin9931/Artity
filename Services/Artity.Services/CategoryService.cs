using Artity.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Artity.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext context;

        public CategoryService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<string> GetAllCategories()
        {
            return context.Categories.Select(a => a.Name).ToList();
        }

        public string GetCategoryId(string name)
        {
           var category = context.Categories.FirstOrDefault(a => a.Name == name);
           return category.Id;
        }
    }
}
