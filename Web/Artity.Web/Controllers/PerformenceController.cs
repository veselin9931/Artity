namespace Artity.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using Artity.Web.ViewModels.Performence;

    using Artity.Services.Performence;

    public class PerformenceController : BaseArtistController
    {
        private readonly IPerformenceService performenceService;
        private readonly Microsoft.AspNetCore.Identity.UserManager<Data.Models.ApplicationUser> userManager;

        public PerformenceController(IPerformenceService performenceService, Microsoft.AspNetCore.Identity.UserManager<Data.Models.ApplicationUser> userManager)
        {
            this.performenceService = performenceService;
            this.userManager = userManager;
        }

        public async Task<IActionResult> All()
        {
            return this.Ok();
        }

        [HttpGet(Name = "Create")]
        public async Task<IActionResult> Create()
        {
            
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PerformenceCreateInputModel createInputModel)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            var viewModel = await this.performenceService.CreatePerformence(createInputModel, user);
            return this.Redirect(Common.GlobalConstants.HomeUrl);
        }

        public async Task<IActionResult> Edit()
        {
            return this.Ok();
        }

        public async Task<IActionResult> Delete()
        {
            return this.Ok();
        }


    }
}
