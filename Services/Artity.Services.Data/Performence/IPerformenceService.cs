namespace Artity.Services.Data.Performence
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Models;

    using Web.InputModels.Performence;

    public interface IPerformenceService
    {
        Task<bool> CreatePerformence(PerformenceCreateInputModel inputModel, ApplicationUser user);

        IEnumerable<TViewModel> GetAll<TViewModel>(bool approved);

        IEnumerable<TViewModel> GetAllFrom<TViewModel>(string category);

        IEnumerable<TViewModel> GetAllByArtistId<TViewModel>(string id);

        IQueryable GetPerformence(string id);

        string GetPerformenceByName(string name);

        Task<bool> ApprovedPerformence(string id);

        Task<bool> RefusePerformence(string id);
    }
}
