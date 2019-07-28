namespace Artity.Web.Controllers
{

    using System.Threading.Tasks;
    using Artity.Data.Models;
    using Artity.Services.Rating;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class RatingController : BaseController
    {
        private readonly IRatingService ratingService;
        private readonly UserManager<ApplicationUser> userManager;

        public RatingController(IRatingService ratingService, UserManager<ApplicationUser> userManager)
        {
            this.ratingService = ratingService;
            this.userManager = userManager;
        }

        [Route("Rate/{rateValue}/Artist/{artist}/")]
        public async Task<JsonResult> Up([FromRoute]int rateValue, [FromRoute]string artist)
        {
            var userId = this.userManager.GetUserId(this.User);

            var rate = await this.ratingService.RateArtist(userId, artist, rateValue);
            return this.Json(rate);
        }

        [Route("/{type}/{id}/Up")]
        public async Task<IActionResult> Down(string type, string id)
        {
            return this.View();
        }

    }
}
