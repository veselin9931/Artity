using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Services
{
    public interface ICategoryService
    {
        IList<string> GetAllCategories();

        string GetCategoryId(string name);
    }
}
