namespace Artity.Services.File
{
    using System;

    using System.Collections.Generic;

    public class ArtistService : IArtistService
    {
        public IEnumerable<TViewModel> GetAllArtists<TViewModel>()
        {
            throw new NotImplementedException();
        }

        public IList<TViewModel> GetAllArtistsFiltretBy<TViewModel>(string filter)
        {
            throw new NotImplementedException();
        }
    }
}
