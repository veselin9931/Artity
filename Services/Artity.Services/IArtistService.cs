using Artity.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Services
{
    public interface IArtistService
    {
        IList<ArtistDto> GetAllArtists();

        IList<ArtistDto> GetAllArtistsFiltretBy(string filter);
    }
}
