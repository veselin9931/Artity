namespace Artity.Services.Data.Category
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task<IList<string>> GetAllCategoriesNamesAsync();

        Task<string> GetCategoryIdAsync(string name);
    }
}
