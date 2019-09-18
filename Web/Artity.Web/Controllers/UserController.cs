namespace Artity.Web.Controllers
{
    using System;

    using System.Collections.Generic;

    using System.Linq;

    using System.Threading.Tasks;

    using Artity.Common;
    using Artity.Services;
    using Artity.Web.ViewModels.Offert;
    using Artity.Web.ViewModels.Order;
    using Microsoft.AspNetCore.Authorization;

    using Microsoft.AspNetCore.Mvc;

    using Services.Data.Offert;
    using Services.Data.Order;
    using Services.Data.User;

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
            if (this.User.IsInRole(GlobalConstants.ArtistRoleName))
            {
                return await this.ArtistReservation(user.ArtistId);
            }

            return await this.UserReservation(user.Id);
        }


        public async Task<IActionResult> ArtistReservation(string id)
        {

            var artistOrderViewModels = this.orderService.AllOrdersInStatus<ArtistOrdersViewModel>(id, Data.Models.Enums.OrderStatus.Accepted);
            return this.View("ArtistReservation", artistOrderViewModels);

        }

        public async Task<IActionResult> UserReservation(string id)
        {

            var artistOrderViewModels = this.orderService.GetAllUserArtistOrders<UserArtistOrderViewModel>(id);
            var artistPerformenceOrderViewModels = this.orderService.GetAllUserPerformenceOrders<UserPerformenceOrderViewModel>(id);
            var model = new UserOrdersViewModel() { UserArtistOrder = artistOrderViewModels, UserPerformenceOrder = artistPerformenceOrderViewModels};
            return this.View("UserReservation", model);

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
                return this.Redirect("/Reservations");
            };
            return this.Json(result);
        }
    }
}