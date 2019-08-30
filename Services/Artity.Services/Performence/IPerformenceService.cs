namespace Artity.Services.Performence
{
    using System.Collections.Generic;

    using System.Linq;

    using System.Threading.Tasks;

    using Artity.Data.Models;

    using Artity.Web.InputModels.Performence;

    public interface IPerformenceService
    {
        Task<bool> CreatePerformence(PerformenceCreateInputModel inputModel, ApplicationUser user);

        IEnumerable<TViewModel> GetAll<TViewModel>(bool approved);

        IEnumerable<TViewModel> GetAllFrom<TViewModel>(string category);

        IQueryable GetPerformence(string id);

        IEnumerable<TViewModel> GetAll<TViewModel>(string userId);

        string GetPerformenceByName(string name);

        Task<bool> ApprovedPerformence(string id);

        Task<bool> RefusePerformence(string id);
    }
}
