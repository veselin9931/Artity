namespace Artity.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;

    public class ArtistService : IArtistService
    {

        private readonly IDeletableEntityRepository<Artist> artistRepository;

        public ArtistService(IDeletableEntityRepository<Artist> artistRepository)
        {
            this.artistRepository = artistRepository;
        }

        public Task<bool> AddSocial(string artistId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ApprovedArtist(string artistId)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateNewArtist(string nickname, string workNumber, string description, string aboutMe, string categoryId, string profilePictureId)
        {
            throw new NotImplementedException();
        }

        public Task<TViewModel> EditSocial<TViewModel>(string artistId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TViewModel> GetAllArtists<TViewModel>()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TViewModel> GetAllArtists<TViewModel>(bool isApproved)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TViewModel> GetAllArtistsFiltretBy<TViewModel>(string filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TViewModel> GetAllArtiststFrom<TViewModel>(int category)
        {
            throw new NotImplementedException();
        }

        public TViewModel GetArtistById<TViewModel>(string artistId)
        {
            throw new NotImplementedException();
        }

        public TViewModel GetArtistByUserId<TViewModel>(string userId)
        {
            throw new NotImplementedException();
        }

        public string GetArtistIdByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task<TViewModel> GetSocial<TViewModel>(string artistId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RefuseArtist(string artistId, string message)
        {
            throw new NotImplementedException();
        }
    }
}
