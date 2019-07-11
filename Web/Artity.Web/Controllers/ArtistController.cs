namespace Artity.Web.Controllers
{

    using Artity.Services;
    using Microsoft.AspNetCore.Mvc;

    public class ArtistController : Controller
    {
        private readonly IArtistService artistService;

        public ArtistController(IArtistService artistService)
        {
            this.artistService = artistService;
        }

        public IActionResult All()
        {
            var artist = this.artistService.GetAllArtists();
            ;
            return this.View(artist);
        }
    }
}