namespace Artity.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ICategoryService
    {
        Task<string> CreateCategory(string name, string pictureId);

        Task<IEnumerable<string>> GetAllCategoriesNamesAsync();

        Task<string> GetCategoryIdAsync(string name);
    }
}
