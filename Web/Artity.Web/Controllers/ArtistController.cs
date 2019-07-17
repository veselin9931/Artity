namespace Artity.Web.Controllers
{
    using Artity.Services.File;
    using Artity.Web.ViewModels.Artist;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class ArtistController : Controller
    {
        private readonly IArtistService artistService;

        public ArtistController(IArtistService artistService)
        {
            this.artistService = artistService;
        }

        public IActionResult All()
        {
            var artists = this.artistService
                .GetAllArtists<ArtistAllViewModel>();

            return this.View(artists);
        }
    }
}