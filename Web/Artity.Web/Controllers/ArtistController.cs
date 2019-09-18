namespace Artity.Web.Controllers
{
    using Artity.Services;
    using Artity.Services.Messaging;
    using Artity.Web.ViewModels.Artist;
    using Artity.Services.Mapping;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using System.Linq;

    using Microsoft.AspNetCore.Authorization;
    using Artity.Common;
    using Artity.Services.ServiceModels;
    using Artity.Web.ViewModels.Social;
    using Artity.Web.InputModels.Social;

    using Services.Data.Artists;
    using Services.Data.Category;
    using Services.Data.Order;
    using Services.Data.Rating;

    public class ArtistController : BaseController
    {
        private readonly IArtistService artistService;
        private readonly ISendGrid emailSender;
        private readonly ICategoryService categoryService;
        private readonly IRatingService ratingService;
        private readonly IOrderService orderService;

        public ArtistController(
            IArtistService artistService
            , ICategoryService categoryService,
            IRatingService ratingService,
            IOrderService orderService
            )
        {
            this.artistService = artistService;
            this.categoryService = categoryService;
            this.ratingService = ratingService;
            this.orderService = orderService;
        }

        [HttpGet(Name = "/All")]
        public async Task<IActionResult> All()
        {
            var artists = this.artistService
                .GetAllArtists<ArtistAllViewModel>(true);

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

        [Authorize(Roles = GlobalConstants.Artist)]
        public async Task<IActionResult> Dashboard()
        {
            return this.View();
        }

        [Authorize(Roles = GlobalConstants.Artist)]
        [Route("/ApprovedReservation/{id}")]
        [HttpGet]
        public async Task<IActionResult> ApprovedReservation(string id)
        {
            var result = await this.orderService.ApprovedReservation(id);
            if (result)
            {
                return this.Redirect("/");

            }

            return this.NotFound();
        }

        [Authorize(Roles = GlobalConstants.Artist)]
        [Route("/RefuseReservation/{id}")]
        [HttpGet]
        public async Task<IActionResult> RefuseReservation(string id)
        {
            var result = await this.orderService.RefuseReservation(id);
            if (result)
            {
                return this.Redirect("/");
            }

            return this.NotFound();
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.Artist)]
        public async Task<IActionResult> AddSocial([FromRoute]string id, [FromForm]SocialServiceModel input)
        {
            try
            {
                bool result = await this.artistService
                     .AddSocial(id, input);

                return this.Redirect(GlobalConstants.AccountMenager);
            }
            catch (System.Exception)
            {

                return this.NotFound();
            }
        }

        [HttpPost]
        [Authorize(Roles = GlobalConstants.Artist)]
        [Route("Artist/AddSocial/{id}")]
        public async Task<IActionResult> EditSocial(string id, SocialServiceModel input)
        {
          

                bool result = await this.artistService
                     .AddSocial(id, input);

                return this.Redirect(GlobalConstants.AccountMenager);
      

          
        }


        [HttpGet]
        [Route("Artist/AddSocial/{artistId}")]
        [Authorize(Roles = GlobalConstants.Artist)]
        public async Task<IActionResult> AddSocial([FromRoute]string artistId)
        {
            return this.View(new SocialInputModel() {ArtistId = artistId});
        }

        [HttpGet]
        [Authorize(Roles = GlobalConstants.Artist)]
        public async Task<IActionResult> EditSocial(string id)
        {
            var result = await this.artistService.GetSocial(id);
            return this.View("AddSocial", result.MapTo<SocialViewModel>());
        }

    }
}