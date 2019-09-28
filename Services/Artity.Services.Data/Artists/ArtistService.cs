namespace Artity.Services.Data.Artists
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;
    using Artity.Services.Data.Social;
    using Artity.Services.Data.User;
    using Artity.Services.Mapping;
    using Artity.Services.Messaging;
    using Artity.Services.ServiceModels;

    using Microsoft.EntityFrameworkCore;

    public class ArtistService : IArtistService
    {
        private readonly IDeletableEntityRepository<Artist> artistRepository;
        private readonly ISendGrid emailSender;
        private readonly IUserService userService;
        private readonly ISocialService socialService;

        public ArtistService(
            IDeletableEntityRepository<Artist> artistRepository,
            ISendGrid emailSender,
            IUserService userService,
            ISocialService socialService
            )
        {
            this.artistRepository = artistRepository;
            this.emailSender = emailSender;
            this.userService = userService;
            this.socialService = socialService;
            this.socialService = socialService;
        }

        public async Task<bool> SetSocialAsync(string artistId, SocialServiceModel socialServiceModel)
        {
            var artist = this.GetArtistById(artistId);

            await this.socialService.AddSocial(socialServiceModel);
            artist.Social = this.socialService.MapTo<Social>(); // TODO: Test map

            this.artistRepository.Update(artist);
            var result = await this.artistRepository.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> ApprovedArtistAsync(string id)
        {
            var approvedArtist = this.GetArtistById(id);
            approvedArtist.IsApproved = true;

            this.artistRepository.Update(approvedArtist);
            var result = await this.artistRepository.SaveChangesAsync();

            return result > 0;
        }

        public async Task<SocialServiceModel> EditSocialAsync(string artistId, SocialServiceModel socialServiceModel)
        {
            var social = socialServiceModel.MapTo<Social>();
            var artist = this.GetArtistById(artistId).MapTo<Artist>();
            artist.Social = social;
            this.artistRepository.Update(artist);
            var result = await this.artistRepository.SaveChangesAsync();

            return socialServiceModel;
        }

        public async Task<IEnumerable<TViewModel>> GetAllArtistsAsync<TViewModel>(bool isApproved)
            => await this.artistRepository
                       .All()
                       .Where(a => a.IsApproved == isApproved && a.IsDeleted != true)
                       .OrderBy(a => a.CreatedOn)
                       .To<TViewModel>().ToListAsync();

        public async Task<IEnumerable<TViewModel>> GetAllArtistsAsync<TViewModel>()
            => await this.artistRepository
                  .All()
                .Where(a => a.IsDeleted != true)
                .OrderBy(a => a.CreatedOn)
                .To<TViewModel>().ToListAsync();

        public async Task<IList<TViewModel>> GetAllArtistsFromAsync<TViewModel>(int category)
            => await this.artistRepository
                         .All()
                         .Where(a => (int)a.Category.CategoryType == (int)category)
                         .OrderBy(a => a.CreatedOn)
                         .To<TViewModel>()
                         .ToListAsync();

        public async Task<TViewModel> GetArtistAsync<TViewModel>(string id)
            => await this.artistRepository
                  .All()
                  .Where(a => a.Id == id && a.IsDeleted == false)
                  .To<TViewModel>()
                  .FirstOrDefaultAsync();

        public async Task<string> GetArtistIdByNameAsync(string name)
        {
            var artist = await this.artistRepository
                  .All()
                  .FirstOrDefaultAsync(a => a.Nikname == name);

            // TODO : if null throw exception
            return artist?.Id;
        }

        public async Task<SocialServiceModel> GetSocialAsync(string artistId)
        {
            var social = this.GetArtistById(artistId).Social;

            if (social == null)
            {
                return new SocialServiceModel() { Facebook = social.Facebook, WebSite = social.WebSite, Youtube = social.Youtube };
            }

            return new SocialServiceModel() { Facebook = social.Facebook, WebSite = social.WebSite, Youtube = social.Youtube };
        }

        public async Task<bool> RefuseArtistAsync(string id, string message)
        {
            // TODO : Fix ?
            message = "sds";
            string email = await this.userService.GetArtistEmail(id);
            await this.emailSender.SendEmailAsync(email, message, message);

            var artist = this.GetArtistById(id);
            artist.IsDeleted = true;

            this.artistRepository.Update(artist);
            var result = await this.artistRepository.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> SetPerformenceAsync(string artistId, Performence performence)
        {
            var artist = this.GetArtistById(artistId);
            artist.Performences.Add(performence);

            this.artistRepository.Update(artist);
            var result = await this.artistRepository.SaveChangesAsync();

            return result > 0;
        }

        public IEnumerable<TViewModel> GetAllPerformence<TViewModel>(string artistId)
        {
            return this.artistRepository
              .All()
              .FirstOrDefault(a => a.Id == artistId)
              .Performences
              .AsQueryable()
              .To<TViewModel>().ToList();
        }

        private Artist GetArtistById(string artistId)
        {
            return this.artistRepository
                  .All()?
                  .FirstOrDefault(a => a.Id == artistId && a.IsDeleted != true);
        }
    }
}