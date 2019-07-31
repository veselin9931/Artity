using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artity.Common;
using Artity.Services.Order;
using Artity.Web.InputModels.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Artity.Web.Controllers
{
    public class OrderArtistController : BaseController
    {
        public OrderArtistController(IOrderService orderService)
        {
            this.OrderService = orderService;
        }

        public IOrderService OrderService { get; }

        [Authorize(Roles = GlobalConstants.UserRoleName)]
        [Route("/Order/Create/{username}")]
        [HttpPost]
        public IActionResult Create([FromRoute]string username, OrderCreateInputModel model)
        {
            if (this.ModelState.IsValid)
            {
                model.Username = username;
                this.OrderService.CreateOrder(model);
                //TODO: Cach exeptions

                return this.Ok();
            }

           

            return this.View();
        }


        [Authorize(Roles = GlobalConstants.UserRoleName)]
        [Route("/Order/Create/{username}")]
        [HttpGet]
        public IActionResult Create([FromRoute]string username)
        {
            return this.View();
        }

    }
}
