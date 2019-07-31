namespace Artity.Services.Artists
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IArtistService
    {
        IEnumerable<TViewModel> GetAllArtists<TViewModel>();

        IList<TViewModel> GetAllArtistsFiltretBy<TViewModel>(string filter);

        IList<TViewModel> GetAllArtiststFrom<TViewModel>(int category);

        IQueryable GetArtist(string id);

        Task<string> GetArtistIdByName(string name);


    }
}
