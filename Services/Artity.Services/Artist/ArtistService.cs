namespace Artity.Services.File
{
    using System;

    using System.Collections.Generic;

    using System.Linq;

    using Artity.Data.Common.Repositories;

    using Artity.Data.Models;

    using Artity.Services.Mapping;

    public class ArtistService : IArtistService
    {
        public ArtistService(IRepository<Artist> artistContext)
        {
            this.ArtistContext = artistContext;
        }

        public IRepository<Artist> ArtistContext { get; }

        public IEnumerable<TViewModel> GetAllArtists<TViewModel>()
        {
          return this.ArtistContext
                .All()
                .OrderBy(a => a.CreatedOn)
                .To<TViewModel>().ToList();
        }

        public IList<TViewModel> GetAllArtistsFiltretBy<TViewModel>(string filter)
        {
            throw new NotImplementedException();
        }

        public IList<TViewModel> GetAllArtiststFrom<TViewModel>(int category)
        {
            return this.ArtistContext
                 .All()
                 .Where(a => (int)a.Category.CategoryType == (int)category)
                 .OrderBy(a => a.CreatedOn)
                 .To<TViewModel>().ToList();
        }
    }
}
