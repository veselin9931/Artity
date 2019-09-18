namespace Artity.Services.Data.Category
{
    using System.Collections.Generic;

    public interface ICategoryService
    {
        IList<string> GetAllCategories();

        string GetCategoryId(string name);
    }
}
