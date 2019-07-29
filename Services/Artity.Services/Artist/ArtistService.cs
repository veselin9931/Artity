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
        private readonly IRepository<Artist> artistContext;

        public ArtistService(IRepository<Artist> artistContext)
        {
            this.artistContext = artistContext;
        }



        public IEnumerable<TViewModel> GetAllArtists<TViewModel>()
        {
          return this.artistContext
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
            return this.artistContext
                 .All()
                 .Where(a => (int)a.Category.CategoryType == (int)category)
                 .OrderBy(a => a.CreatedOn)
                 .To<TViewModel>().ToList();
        }

        public IQueryable GetArtist(string id)
        {
            return this.artistContext
                  .All()
                  .Where(a => a.Id == id);
        }

    }
}
