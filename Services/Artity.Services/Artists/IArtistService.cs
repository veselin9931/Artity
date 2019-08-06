namespace Artity.Services.Artists
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IArtistService
    {
        IEnumerable<TViewModel> GetAllArtists<TViewModel>(bool isApproved);

        IList<TViewModel> GetAllArtistsFiltretBy<TViewModel>(string filter);

        IList<TViewModel> GetAllArtiststFrom<TViewModel>(int category);

        IQueryable GetArtist(string id);

        Task<string> GetArtistIdByName(string name);

        Task<bool> ApprovedArtist(string id);

        Task<bool> RefuseArtist(string id, string message);

    }
}
