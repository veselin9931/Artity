namespace Artity.Web.Areas.Administration.Controllers
{
    using Artity.Web.Areas.Administration.ViewModels.Dashboard;

    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    using Services.Data.Artists;
    using Services.Data.Performence;

    public class DashboardController : AdministrationController
    {
        private readonly IArtistService artistService;
        private readonly IPerformenceService performenceService;

        public DashboardController(IArtistService artistService, IPerformenceService performenceService)
        {
            this.artistService = artistService;
            this.performenceService = performenceService;
        }

        public async Task<IActionResult> Index()
        {
            var viewModel = new IndexViewModel
            {
                allArtist = await this.artistService.GetAllArtistsAsync<ApprovedArtistViewModel>(false),
                allArtistsForEdit = await this.artistService.GetAllArtistsAsync<ArtistsEditingViewModel>(),
                allPerformence = this.performenceService.GetAll<ApprovedPerformenceViewModel>(false),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> Approved(string id)
        {
            try
            {

                bool result = await this.artistService.ApprovedArtistAsync(id);
                var viewModel = new IndexViewModel
                {
                    allArtist = await this.artistService.GetAllArtistsAsync<ApprovedArtistViewModel>(false),
                    allArtistsForEdit = await this.artistService.GetAllArtistsAsync<ArtistsEditingViewModel>(),
                    allPerformence = this.performenceService.GetAll<ApprovedPerformenceViewModel>(false),
                };

                if (result)
                {
                    return this.View("Index", viewModel);
                }

                return this.View("Error");
            }
            catch (System.Exception)
            {

                return this.View("Error");
            }
        }

        public async Task<IActionResult> ApprovedPerformence(string id)
        {
            try
            {
                bool result = await this.performenceService.ApprovedPerformence(id);
                var viewModel = new IndexViewModel
                {
                    allArtist = await this.artistService.GetAllArtistsAsync<ApprovedArtistViewModel>(false),
                    allArtistsForEdit = await this.artistService.GetAllArtistsAsync<ArtistsEditingViewModel>(),
                    allPerformence = this.performenceService.GetAll<ApprovedPerformenceViewModel>(false),
                };

                if (result)
                {
                    return this.View("Index", viewModel);
                }

                return this.View("Error");
            }
            catch (System.Exception)
            {

                return this.View("Error");
            }
        }

        public async Task<IActionResult> RefusalPerfoermence(string id)
        {
            try
            {

                bool result = await this.performenceService.RefusePerformence(id);
                var viewModel = new IndexViewModel
                {
                    allArtist = await this.artistService.GetAllArtistsAsync<ApprovedArtistViewModel>(false),
                    allArtistsForEdit = await this.artistService.GetAllArtistsAsync<ArtistsEditingViewModel>(),
                    allPerformence = this.performenceService.GetAll<ApprovedPerformenceViewModel>(false),
                };

                if (result)
                {
                    return this.View("Index", viewModel);
                }

                return this.View("Error");
            }
            catch (System.Exception)
            {

                return this.View("Error");
            }
        }

        public async Task<IActionResult> Delete(string id)
        {
            try
            {

                bool result = await this.artistService.RefuseArtistAsync(id, "Sory but");
                var viewModel = new IndexViewModel
                {
                    allArtist = await this.artistService.GetAllArtistsAsync<ApprovedArtistViewModel>(false),
                    allArtistsForEdit = await this.artistService.GetAllArtistsAsync<ArtistsEditingViewModel>(),
                    allPerformence = this.performenceService.GetAll<ApprovedPerformenceViewModel>(false),
                };

                if (result)
                {
                    return this.View("Index", viewModel);
                }

                return this.View("Error");
            }
            catch (System.Exception)
            {

                return this.View("Error");
            }
        }

        public async Task<IActionResult> Refusal(string id)
        {
            try
            {

                bool result = await this.artistService.RefuseArtistAsync(id, "Sory but");
                var viewModel = new IndexViewModel
                {
                    allArtist = await this.artistService.GetAllArtistsAsync<ApprovedArtistViewModel>(false),
                };

                if (result)
                {
                    return this.View("Index", viewModel);
                }

                return this.View("Error");
            }
            catch (System.Exception)
            {

                return this.View("Error");
            }
        }
    }
}
