namespace Artity.Web.Controllers
{

    using System.Threading.Tasks;
    using Artity.Common;
    using Artity.Data.Models;
    using Artity.Data.Models.Enums;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Rating;


    [Authorize(Roles = GlobalConstants.AllRoles)]
    public class RatingController : Controller
    {
        private readonly IRatingService ratingService;
        private readonly UserManager<ApplicationUser> userManager;

        public RatingController(IRatingService ratingService, UserManager<ApplicationUser> userManager)
        {
            this.ratingService = ratingService;
            this.userManager = userManager;
        }

        [Authorize(Roles = GlobalConstants.UserRoleName)]
        [Route("Rate/{rateValue}/Artist/{artist}/")]
        public async Task<JsonResult> RateArtist([FromRoute]int rateValue, [FromRoute]string artist)
        {
            var userId = this.userManager.GetUserId(this.User);

            var rate = await this.ratingService.RateArtist(userId, artist, rateValue);
            return this.Json(rate);
        }

        [AllowAnonymous]
        [Route("GetRate/Artist/{artistId}/")]
        public async Task<JsonResult> GetArtistRate([FromRoute]string artistId)
        {
            var rate = this.ratingService.GetRate(RatingType.Artist, artistId);
            return this.Json(rate);
        }

        [AllowAnonymous]
        [Route("GetRate/Performence/{performenceId}/")]
        public async Task<JsonResult> GetPerformenceRate([FromRoute]string performenceId)
        {
            var rate = this.ratingService.GetRate(RatingType.Performence, performenceId);
            return this.Json(rate);
        }

        [Route("Rate/{rateValue}/Performence/{performence}/")]
        public async Task<JsonResult> RatePerformence([FromRoute]int rateValue, [FromRoute]string performence)
        {
            var userId = this.userManager.GetUserId(this.User);

            var rate = await this.ratingService.RatePerformence(userId, performence, rateValue);
            return this.Json(rate);
        }


    }
}
