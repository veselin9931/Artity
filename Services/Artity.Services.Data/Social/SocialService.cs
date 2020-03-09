namespace Artity.Services.Data.Social
{
    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;
    using Artity.Services.Data.Artists;
    using Artity.Services.Mapping;
    using Artity.Services.ServiceModels;

    public class SocialService : ISocialService
    {
        private readonly IDeletableEntityRepository<Social> socialRepository;

        private readonly IArtistService artistService;

        public SocialService(IDeletableEntityRepository<Social> socialRepository, IArtistService artistService)
        {
            this.socialRepository = socialRepository;
            this.artistService = artistService;
        }

        public async Task<bool> AddSocial(SocialServiceModel socialServiceModel)
        {
            Social social = socialServiceModel.MapTo<Social>();

            await this.socialRepository.AddAsync(social);
            var result = await this.socialRepository.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> SetSocialAsync(string artistId, SocialServiceModel socialServiceModel)
        {
            var artist = await this.artistService.GetArtistAsync<ArtistSocialServiceModel>(artistId);

            await this.AddSocial(socialServiceModel);
            artist.Social = socialServiceModel.MapTo<Social>();

            var result = await this.artistService.UpdateSocialAsync(artist);

            return result;
        }
    }
}
