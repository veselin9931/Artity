namespace Artity.Services.File
{
    using System.Collections.Generic;

    public interface IArtistService
    {
        IEnumerable<TViewModel> GetAllArtists<TViewModel>();

        IList<TViewModel> GetAllArtistsFiltretBy<TViewModel>(string filter);

        IList<TViewModel> GetAllArtiststFrom<TViewModel>(int category);
    }
}
