namespace Artity.Web.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Services.Data.Category;
    using Artity.Services.Data.Performence;
    using Artity.Services.Mapping;
    using Artity.Web.InputModels.Performence;
    using Artity.Web.ViewModels.Performence;
    using Microsoft.AspNetCore.Mvc;

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
                .GetAll<PerformenceAllViewModel>(true);

            var categories = await this.categoryService
                .GetAllCategoriesNamesAsync();

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
            if (this.ModelState.IsValid)
            {
                var user = await this.userManager.GetUserAsync(this.User);
                var viewModel = await this.performenceService.CreatePerformence(createInputModel, user);
                return this.Redirect(Common.GlobalConstants.HomeUrl);
            }

            return View();
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
