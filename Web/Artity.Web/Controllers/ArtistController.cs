namespace Artity.Web.Controllers
{
    using Artity.Services.File;
    using Artity.Services.Messaging;
    using Artity.Web.ViewModels.Artist;
    using Microsoft.AspNetCore.Identity.UI.Services;
    using Microsoft.AspNetCore.Mvc;

    public class ArtistController : BaseController
    {
        private readonly IArtistService artistService;
        private readonly ISendGrid emailSender;

        public ArtistController(IArtistService artistService, ISendGrid emailSender)
        {
            this.artistService = artistService;
            this.emailSender = emailSender;
        }

     
        public IActionResult All()
        {
            var artists = this.artistService
                .GetAllArtists<ArtistAllViewModel>();

            var email = this.emailSender;
            return this.View(artists);
        }
    }
}