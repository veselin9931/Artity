namespace Artity.Services.Artists
{
    using System;

    using System.Collections.Generic;

    using System.Linq;
    using System.Threading.Tasks;
    using Artity.Data.Common.Repositories;

    using Artity.Data.Models;

    using Artity.Services.Mapping;
    using Artity.Services.Messaging;

    public class ArtistService : IArtistService
    {
        private readonly IRepository<Artist> artistContext;
        private readonly ISendGrid emailSender;
        private readonly IUserService userService;

        public ArtistService(
            IRepository<Artist> artistContext,
            ISendGrid emailSender,
            IUserService userService
            )
        {
            this.artistContext = artistContext;
            this.emailSender = emailSender;
            this.userService = userService;
        }

        public async Task<bool> ApprovedArtist(string id)
        {
            var approvedArtist = this.artistContext.All()
                .FirstOrDefault(a => a.Id == id);
            approvedArtist.IsApproved = true;

            this.artistContext.Update(approvedArtist);
            var result = await this.artistContext.SaveChangesAsync();

            return result > 0;
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
                  .Where(a => a.Id == id && a.IsDeleted == false);
        }

        public async Task<string> GetArtistIdByName(string name)
        {
            return this.artistContext
                  .All()?
                  .FirstOrDefault(a => a.Nikname == name).Id;
        }


        public async Task<bool> RefuseArtist(string id, string message)
        {
            string email = await this.userService.GetArtistEmail(id);

           await this.emailSender.SendEmailAsync(email,
                         "You ",
                         $"Sorry, the art team is delighted to have your access to a platform for playing your account," +
                         $" please contact < a href='support@artity.com.>support@artity.com.</a>."
                         +$"<h4>POSSIBLE CAUSES:</h4>"
                         + "1.Unlawful content"
                         + "2. Security issues"
                         + message
                         );

            this.artistContext.All()
                .FirstOrDefault(a => a.Id == id)
                .IsDeleted = true;

            var result = await this.artistContext.SaveChangesAsync();

            return result > 0;
        }
    }
}
