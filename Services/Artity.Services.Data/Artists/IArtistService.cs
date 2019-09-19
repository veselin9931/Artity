namespace Artity.Services.Data.Artists
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Models;

    using ServiceModels;

    public interface IArtistService
    {
        IEnumerable<TViewModel> GetAllArtists<TViewModel>();

        IEnumerable<TViewModel> GetAllArtists<TViewModel>(bool isApproved);

        IList<TViewModel> GetAllArtiststFrom<TViewModel>(int category);

        IQueryable GetArtist(string id);

        Task<string> GetArtistIdByName(string name);

        Task<bool> ApprovedArtist(string id);

        Task<bool> RefuseArtist(string id, string message);

        Task<bool> SetSocial(string artistId, SocialServiceModel socialServiceModel);

        Task<SocialServiceModel> GetSocial(string artistId);

        Task<SocialServiceModel> EditSocial(string artistId, SocialServiceModel socialServiceModel);

    }
}
