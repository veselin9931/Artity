namespace Artity.Web.Controllers
{
    using System;

    using System.Collections.Generic;

    using System.Linq;

    using System.Threading.Tasks;

    using Artity.Common;
    using Artity.Services;
    using Artity.Services.Order;
    using Artity.Web.ViewModels.Order;
    using Microsoft.AspNetCore.Authorization;

    using Microsoft.AspNetCore.Mvc;

    public class UserController : BaseController
    {
        private readonly IOrderService orderService;
        private readonly IUserService userService;

        public UserController(IOrderService orderService, IUserService userService)
        {
            this.orderService = orderService;
            this.userService = userService;
        }

        [Authorize(Roles = GlobalConstants.UserRoleName)]
        [Route("/Reservations")]
        [HttpGet]
        public async Task<IActionResult> Reservations()
        {
            //TODO : Check exeptions
            var userId = this.userService.GetApplicationUserByName(this.User.Identity.Name).Id;
            var artistOrderViewModels = this.orderService.GetAllUserArtistOrders<UserArtistOrderViewModel>(userId);
            var model = new UserOrdersViewModel() { UserArtistOrder = artistOrderViewModels };
            return this.View(model);
        }

        [Authorize(Roles = GlobalConstants.UserRoleName)]
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