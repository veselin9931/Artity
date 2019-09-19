namespace Artity.Services.Data.Artists
{
    using System.Collections.Generic;

    using System.Linq;

    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;

    using Artity.Data.Models;

    using Artity.Services.Mapping;

    using Artity.Services.Data.User;

    using Artity.Services.Messaging;

    using Artity.Services.ServiceModels;

    using Artity.Services.Data.Social;

    public class ArtistService : IArtistService
    {
        private readonly IRepository<Artist> artistContext;
        private readonly ISendGrid emailSender;
        private readonly IUserService userService;
        private readonly ISocialService socialService;

        public ArtistService(
            IRepository<Artist> artistContext,
            ISendGrid emailSender,
            IUserService userService,
            ISocialService socialService
            )
        {
            this.artistContext = artistContext;
            this.emailSender = emailSender;
            this.userService = userService;
            this.socialService = socialService;
            this.socialService = socialService;
        }

        public async Task<bool> SetSocial(string artistId, SocialServiceModel socialServiceModel)
        {
            var artist = this.GetArtistById(artistId);

            await this.socialService.AddSocial(socialServiceModel);
            artist.Social = this.socialService.MapTo<Social>(); // TODO: Test map

            this.artistContext.Update(artist);
            var result = await this.artistContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> ApprovedArtist(string id)
        {
            var approvedArtist = this.GetArtistById(id);
            approvedArtist.IsApproved = true;

            this.artistContext.Update(approvedArtist);
            var result = await this.artistContext.SaveChangesAsync();

            return result > 0;
        }

        public async Task<SocialServiceModel> EditSocial(string artistId, SocialServiceModel socialServiceModel)
        {
            var social = socialServiceModel.MapTo<Social>();
            var artist = this.GetArtistById(artistId).MapTo<Artist>();
            artist.Social = social;
            this.artistContext.Update(artist);
            var result = await this.artistContext.SaveChangesAsync();

            return socialServiceModel;
        }

        public IEnumerable<TViewModel> GetAllArtists<TViewModel>(bool isApproved)
        {
            return this.artistContext
                  .All()
                .Where(a => a.IsApproved == isApproved && a.IsDeleted != true)
                .OrderBy(a => a.CreatedOn)
                .To<TViewModel>().ToList();
        }

        public IEnumerable<TViewModel> GetAllArtists<TViewModel>()
        {
            return this.artistContext
                  .All()
                .Where(a => a.IsDeleted != true)
                .OrderBy(a => a.CreatedOn)
                .To<TViewModel>().ToList();
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
                  .Where(a => a.Id == id && a.IsDeleted == false);
        }

        public async Task<string> GetArtistIdByName(string name)
        {
            return this.artistContext
                  .All()?
                  .FirstOrDefault(a => a.Nikname == name).Id;
        }

        public async Task<SocialServiceModel> GetSocial(string artistId)
        {
            var social = this.GetArtistById(artistId).Social;

            if (social == null)
            {
                  return new SocialServiceModel() { Facebook = social.Facebook, WebSite = social.WebSite, Youtube = social.Youtube };
            }

            return new SocialServiceModel() { Facebook = social.Facebook, WebSite = social.WebSite, Youtube = social.Youtube };
        }

        public async Task<bool> RefuseArtist(string id, string message)
        {
            message = "sds";
            string email = await this.userService.GetArtistEmail(id);
            await this.emailSender.SendEmailAsync(email, message, message);

            var artist = this.GetArtistById(id);
            artist.IsDeleted = true;

            this.artistContext.Update(artist);
            var result = await this.artistContext.SaveChangesAsync();

            return result > 0;
        }

        private Artist GetArtistById(string artistId)
        {
            return this.artistContext
                  .All()?
                  .FirstOrDefault(a => a.Id == artistId && a.IsDeleted != true);
        }
    }
}
