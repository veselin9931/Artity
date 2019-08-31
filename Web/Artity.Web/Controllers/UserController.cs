namespace Artity.Web.Controllers
{
    using System;

    using System.Collections.Generic;

    using System.Linq;

    using System.Threading.Tasks;

    using Artity.Common;
    using Artity.Services;
    using Artity.Services.Offert;
    using Artity.Services.Order;
    using Artity.Web.ViewModels.Offert;
    using Artity.Web.ViewModels.Order;
    using Microsoft.AspNetCore.Authorization;

    using Microsoft.AspNetCore.Mvc;

    public class UserController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly IUserService userService;
        private IOffertService offertService;

        public UserController(IOrderService orderService, IUserService userService)
        {
            this.orderService = orderService;
            this.userService = userService;
        }


        [Authorize(Roles = GlobalConstants.AllRoles)]
        [Route("/Reservations")]
        [HttpGet]
        public async Task<IActionResult> Reservations()
        {
            //TODO : Check exeptions
            var user = this.userService.GetApplicationUserByName(this.User.Identity.Name);
            if (user.Artist == null)
            {
                var userOrders = this.orderService.GetAllUserArtistOrders<UserArtistOrderViewModel>(user.Id);
                var model1 = new UserOrdersViewModel() { UserArtistOrder = userOrders };
                return this.View(model1);
            }

            var artistOrderViewModels = this.orderService.AllPrivateOrders<UserArtistOrderViewModel>(user.Id);
            var model2 = new UserOrdersViewModel() { UserArtistOrder = artistOrderViewModels };
            return this.View(model2);

        }


        [Authorize(Roles = GlobalConstants.AllRoles)]
        [Route("/Reservations/Delete/{id}")]
        [HttpGet]
        public async Task<IActionResult> DeleteReservation(string id)
        {
            //TODO : Check exeptions
            var result = await this.orderService.DeleteOrderById(id);
            if (result)
            {
                var userId = this.userService.GetApplicationUserByName(this.User.Identity.Name).Id;
                var artistOrderViewModels = this.orderService.GetAllUserArtistOrders<UserArtistOrderViewModel>(userId);
                var model = new UserOrdersViewModel() { UserArtistOrder = artistOrderViewModels };
                return this.View("Reservations",model);
            };
            return this.Json(result);
        }
    }
}