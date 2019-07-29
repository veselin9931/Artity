namespace Artity.Web.Controllers
{
    using Artity.Services;
    using Artity.Services.File;
    using Artity.Services.Messaging;
    using Artity.Web.ViewModels.Artist;
    using Artity.Services.Mapping;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using System.Linq;

    public class ArtistController : BaseController
    {
        private readonly IArtistService artistService;
        private readonly ISendGrid emailSender;
        private readonly ICategoryService categoryService;

        public ArtistController(
            IArtistService artistService
            , ICategoryService categoryService
            )
        {
            this.artistService = artistService;
            this.categoryService = categoryService;
        }

        [HttpGet(Name = "/All")]
        public async Task<IActionResult> All()
        {
            var artists = this.artistService
                .GetAllArtists<ArtistAllViewModel>();

            var categories = this.categoryService
                .GetAllCategories();

            var artitView = new ArtistViewModel()
            {
                ArtistAlls = artists,
                Categories = categories,
            };

            return this.View(artitView);
        }

        [Route("Artist/All/{category}")]
        public async Task<IActionResult> All([FromRoute] int category)
        {
            var artists = this.artistService
                .GetAllArtiststFrom<ArtistAllViewModel>(category);

            var categories = this.categoryService
                .GetAllCategories();

            var artitView = new ArtistViewModel()
            {
                ArtistAlls = artists,
                Categories = categories,
            };

            return this.View(artitView);
        }

        public async Task<IActionResult> Profile(string id)
        {
            var artist = this.artistService.GetArtist(id).To<ArtistProfileViewModel>().ToList().First();

            return this.View(artist);
        }

        public async Task<IActionResult> Dashboard()
        {
            return this.View();
        }

    }
}