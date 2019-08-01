using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artity.Common;
using Artity.Data.Models.Enums;
using Artity.Services.Order;
using Artity.Web.InputModels.Order;
using Artity.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        [Route("/Order/Create/{ArtistNikname}")]
        [HttpPost]
        public async Task<IActionResult> Create([FromRoute]string ArtistNikname, OrderCreateInputModel model)
        {
            model.ArtistNikname = ArtistNikname;
            model.Username = this.User.Identity.Name;

            if (this.ModelState.IsValid)
            {
                try
                {
                    bool result = await this.OrderService.CreateOrder(model);
                    if (result)
                    {
                        return this.Redirect(GlobalConstants.HomeUrl);
                    }
                }
                catch (ArgumentNullException a)
                {
                    return this.View("Error", new ErrorViewModel() { RequestId = a.Message });
                }
            }

            this.ViewBag.TypeOptions = new List<SelectListItem>
            {
              new SelectListItem {Text = OrderType.Charity.ToString(), Value = "3"},
              new SelectListItem {Text = OrderType.Price.ToString(), Value = "1"},
              new SelectListItem {Text = OrderType.PerHour.ToString(), Value = "4"},
              new SelectListItem {Text = OrderType.Contract.ToString(), Value = "2"},
            };

            var errors = this.ModelState.Values.SelectMany(v => v.Errors);

            foreach (var error in errors)
            {
                this.ModelState.AddModelError(string.Empty, error.ErrorMessage);
            }

            var iputModel = new OrderCreateInputModel() { ArtistNikname = ArtistNikname };

            return this.View(iputModel);
        }


        [Authorize(Roles = GlobalConstants.UserRoleName)]
        [Route("/Order/Create/{ArtistNikname}")]
        [HttpGet]
        public IActionResult Create([FromRoute]string ArtistNikname)
        {
            this.ViewBag.TypeOptions = new List<SelectListItem>
            {
              new SelectListItem {Text = OrderType.Charity.ToString(), Value = "3"},
              new SelectListItem {Text = OrderType.Price.ToString(), Value = "1"},
              new SelectListItem {Text = OrderType.PerHour.ToString(), Value = "4"},
              new SelectListItem {Text = OrderType.Contract.ToString(), Value = "2"},
            };

            var iputModel = new OrderCreateInputModel() { ArtistNikname = ArtistNikname };

            return this.View(iputModel);
        }

    }
}
