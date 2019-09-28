namespace Artity.Web.Controllers
{
    using Artity.Common;
    using Artity.Services;
    using Artity.Web.ViewModels.Artist;
    using Microsoft.AspNetCore.Mvc;
    using Artity.Services.Mapping;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.Threading.Tasks;

    using Artity.Web.ViewModels.Order;
    using Artity.Web.ViewModels.Offert;

    using Services.Data.Artists;
    using Services.Data.Offert;
    using Services.Data.Order;
    using Services.Data.User;

    public class HomeController : BaseController
    {
        private readonly IUserService userService;
        private readonly IArtistService artistService;
        private readonly IOrderService orderService;
        private readonly IOffertService offertService;

        public HomeController(
            IUserService userService,
            IArtistService artistService,
            IOrderService orderService, 
            IOffertService offertService
            )
        {
            this.userService = userService;
            this.artistService = artistService;
            this.orderService = orderService;
            this.offertService = offertService;
        }

        public async Task<IActionResult> Index()
        {
            if (this.User.IsInRole(GlobalConstants.ArtistRoleName))
            {
                var currentUsername = this.User.Identity.Name;

                var user = this.userService.GetApplicationUserByName(currentUsername);

                var viewModel = await this.artistService.GetArtistAsync<ArtistDashboardViewModel>(user.ArtistId);

                var artistOrders = this.orderService
                    .AllOrdersInStatus<ArtistOrdersViewModel>(user.ArtistId, Data.Models.Enums.OrderStatus.Sent);
                viewModel.Orders = artistOrders;

                var offerts = this.offertService.GetAllOfferts<OffertViewModel>(user.ArtistId);
                viewModel.Offerts = offerts;

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
