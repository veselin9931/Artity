namespace Artity.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IArtistService
    {
        Task<string> CreateNewArtist(string nickname, string workNumber, string description, string aboutMe, string categoryId, string profilePictureId);

        IEnumerable<TViewModel> GetAllArtists<TViewModel>();

        IEnumerable<TViewModel> GetAllArtists<TViewModel>(bool isApproved);

        IEnumerable<TViewModel> GetAllArtistsFiltretBy<TViewModel>(string filter);

        IEnumerable<TViewModel> GetAllArtiststFrom<TViewModel>(int category);

        TViewModel GetArtistByUserId<TViewModel>(string userId);

        TViewModel GetArtistById<TViewModel>(string artistId);

        string GetArtistIdByName(string name);

        Task<bool> ApprovedArtist(string artistId);

        Task<bool> RefuseArtist(string artistId, string message);
    }
}
