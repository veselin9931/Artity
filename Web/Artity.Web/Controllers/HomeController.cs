namespace Artity.Web.Controllers
{
    using Artity.Common;
    using Artity.Services;
    using Artity.Services.Artists;
    using Artity.Web.ViewModels.Artist;
    using Microsoft.AspNetCore.Mvc;
    using Artity.Services.Mapping;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.Threading.Tasks;
    using Artity.Services.Order;
    using Artity.Web.ViewModels.Order;

    public class HomeController : BaseController
    {
        private readonly IUserService userService;
        private readonly IArtistService artistService;
        private readonly IOrderService orderService;

        public HomeController(
            IUserService userService,
            IArtistService artistService,
            IOrderService orderService
            )
        {
            this.userService = userService;
            this.artistService = artistService;
            this.orderService = orderService;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(GlobalConstants.ArtistRoleName))
            {
                var currentUsername = this.User.Identity.Name;

                var user = this.userService.GetApplicationUserByName(currentUsername);

                var viewModel = await this.artistService.GetArtist(user.ArtistId).To<ArtistDashboardViewModel>().FirstAsync();

                var artistOrders = this.orderService.AllOrders<ArtistOrdersViewModel>(user.ArtistId);
                viewModel.Orders = artistOrders;

                return this.View("ArtistDashboard", viewModel);
            }
            else if (this.User.IsInRole(GlobalConstants.UserRoleName))
            {
                return this.RedirectToAction("All", "Artist");
            }
            else if (this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.RedirectToAction(GlobalConstants.Index, GlobalConstants.Dashboard, new { area = GlobalConstants.AdminArea});
            }

            return this.View();
        }

        public IActionResult Contacts()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}
