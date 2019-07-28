namespace Artity.Services.Performence
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Models;
    using Artity.Web.ViewModels.Performence;

    public interface IPerformenceService
    {
        Task<bool> CreatePerformence(PerformenceCreateInputModel inputModel, ApplicationUser user);

        IEnumerable<TViewModel> GetAll<TViewModel>();

        IEnumerable<TViewModel> GetAllFrom<TViewModel>(string category);

        IQueryable GetPerformence(string id);

    }
}
