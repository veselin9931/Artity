namespace Artity.Web.Controllers
{
    using Artity.Web.ViewModels.Performence;

    using Artity.Services.Performence;

    using Artity.Services;

    using Microsoft.AspNetCore.Mvc;

    using System.Threading.Tasks;

    using Artity.Services.Mapping;
    using System.Linq;

    public class PerformenceController : BaseController
    {
        private readonly IPerformenceService performenceService;
        private readonly Microsoft.AspNetCore.Identity.UserManager<Data.Models.ApplicationUser> userManager;
        private readonly ICategoryService categoryService;

        public PerformenceController(IPerformenceService performenceService,
            Microsoft.AspNetCore.Identity.UserManager<Data.Models.ApplicationUser> userManager,
            ICategoryService categoryService)
        {
            this.performenceService = performenceService;
            this.userManager = userManager;
            this.categoryService = categoryService;
        }


        [HttpGet(Name = "/All")]
        public async Task<IActionResult> All()
        {
            var performences = this.performenceService
                .GetAll<PerformenceAllViewModel>();

            var categories = this.categoryService
                .GetAllCategories();

            var artitView = new PerformenceViewModel()
            {
                 Performences = performences,
                 Categories = categories,
            };

            return this.View(artitView);
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
        public async Task<IActionResult> Profile(string id)
        {
            var performence = this.performenceService.GetPerformence(id).To<PerformneceProfileViewModel>().ToList().First();
            return this.View(performence);
        }

        public async Task<IActionResult> Delete()
        {
            return this.Ok();
        }


    }
}
