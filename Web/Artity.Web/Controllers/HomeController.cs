namespace Artity.Web.Controllers
{
    using System.Threading.Tasks;

    using Artity.Common;
    using Artity.Services.Data.Artists;
    using Artity.Services.Data.Offert;
    using Artity.Services.Data.Order;
    using Artity.Services.Data.User;
    using Artity.Web.Areas.Administration.Controllers;
    using Artity.Web.Extensions;
    using Artity.Web.ViewModels.Artist;
    using Artity.Web.ViewModels.Offert;
    using Artity.Web.ViewModels.Order;
    using Microsoft.AspNetCore.Mvc;

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
                return this.RedirectTo<ArtistController>(x => x.All());
            }
            else if (this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.RedirectTo<DashboardController>(x => x.Index());
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
