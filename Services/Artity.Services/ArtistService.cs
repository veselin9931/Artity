namespace Artity.Services
{

    using Artity.Data;
    using Artity.Services.ServiceModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Artity.Services.Mapping;


    public class ArtistService : IArtistService
    {
        private readonly ApplicationDbContext context;

        public ArtistService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IList<ArtistDto> GetAllArtists()
        {
            var all = context.Artists;

            var mapArtist = all.To<ArtistDto>();

            return mapArtist.ToList();
        }

        public IList<ArtistDto> GetAllArtistsFiltretBy(string filter)
        {
            //TODO: Implement logic about search filter
            throw new NotImplementedException();
        }
    }
}
