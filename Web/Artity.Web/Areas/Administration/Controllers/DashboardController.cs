namespace Artity.Web.Areas.Administration.Controllers
{
    using Artity.Services.Artists;
    using Artity.Services.Data;
    using Artity.Web.Areas.Administration.ViewModels.Dashboard;

    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class DashboardController : AdministrationController
    {
        private readonly ISettingsService settingsService;
        private readonly IArtistService artistService;

        public DashboardController(ISettingsService settingsService, IArtistService artistService)
        {
            this.settingsService = settingsService;
            this.artistService = artistService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                SettingsCount = this.settingsService.GetCount(),
                allArtist = this.artistService.GetAllArtists<ApprovedArtistViewModel>(false),
                allArtistsForEdit = this.artistService.GetAllArtists<ArtistsEditingViewModel>(),
            };
            return this.View(viewModel);
        }

        public async Task<IActionResult> Approved(string id)
        {
            try
            {

                bool result = await this.artistService.ApprovedArtist(id);
                var viewModel = new IndexViewModel
                {
                    SettingsCount = this.settingsService.GetCount(),
                    allArtist = this.artistService.GetAllArtists<ApprovedArtistViewModel>(false),
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

                bool result = await this.artistService.RefuseArtist(id, "Sory but");
                var viewModel = new IndexViewModel
                {
                    SettingsCount = this.settingsService.GetCount(),
                    allArtist = this.artistService.GetAllArtists<ApprovedArtistViewModel>(false),
                    allArtistsForEdit = this.artistService.GetAllArtists<ArtistsEditingViewModel>(),
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

                bool result = await this.artistService.RefuseArtist(id, "Sory but");
                var viewModel = new IndexViewModel
                {
                    SettingsCount = this.settingsService.GetCount(),
                    allArtist = this.artistService.GetAllArtists<ApprovedArtistViewModel>(false),
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
