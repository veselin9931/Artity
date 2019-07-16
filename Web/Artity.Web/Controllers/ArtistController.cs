namespace Artity.Web.Controllers
{
    using Artity.Services.File;

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

            return this.View();
        }
    }
}