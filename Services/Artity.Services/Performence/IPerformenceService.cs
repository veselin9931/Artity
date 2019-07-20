namespace Artity.Services.Performence
{
    using System.Threading.Tasks;

    using Artity.Data.Models;
    using Artity.Web.ViewModels.Performence;

    public interface IPerformenceService
    {
        Task<bool> CreatePerformence(PerformenceCreateInputModel inputModel, ApplicationUser user);

    }
}
