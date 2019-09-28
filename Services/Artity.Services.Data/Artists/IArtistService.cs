namespace Artity.Services.Data.Artists
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Models;

    using ServiceModels;

    public interface IArtistService
    {
        Task<IEnumerable<TViewModel>> GetAllArtistsAsync<TViewModel>();

        Task<IEnumerable<TViewModel>> GetAllArtistsAsync<TViewModel>(bool isApproved);

        Task<IList<TViewModel>> GetAllArtistsFromAsync<TViewModel>(int category);

        Task<TViewModel> GetArtistAsync<TViewModel>(string id);

        Task<string> GetArtistIdByNameAsync(string name);

        // TODO : Approve Artist ?
        Task<bool> ApprovedArtistAsync(string id);

        Task<bool> RefuseArtistAsync(string id, string message);

        Task<bool> SetSocialAsync(string artistId, SocialServiceModel socialServiceModel);

        Task<SocialServiceModel> GetSocialAsync(string artistId);

        Task<SocialServiceModel> EditSocialAsync(string artistId, SocialServiceModel socialServiceModel);

        Task<bool> SetPerformenceAsync(string artistId, Performence performence);

        IEnumerable<TViewModel> GetAllPerformence<TViewModel>(string artistId);
    }
}
