namespace Artity.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;
    using Artity.Services.Data.ServiceModels;
    using Artity.Services.Mapping;

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

        public async Task<string> CreateNewArtist(string nickname, string workNumber, string description, string aboutMe, string categoryId, string profilePictureId)
        {
            var artist = new Artist()
            {
                Nikname = nickname,
                WorkNumber = workNumber,
                Description = description,
                AboutMe = aboutMe,
                CategoryId = categoryId,
                ProfilePictureId = profilePictureId,
            };

            var result = this.artistRepository.AddAsync(artist);
            await this.artistRepository.SaveChangesAsync();

            return artist.Id;
        }

        public Task<TViewModel> EditSocial<TViewModel>(string artistId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TViewModel> GetAllArtists<TViewModel>()
        {
            var allArtistsInServiceModel = this.artistRepository.All().To<ArtistServiceModel>();
            return allArtistsInServiceModel.To<TViewModel>();
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
