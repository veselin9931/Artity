using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artity.Common;
using Artity.Data.Models.Enums;
using Artity.Web.InputModels.Order;
using Artity.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using Artity.Web.ViewModels.Performence;
using Artity.Services.Mapping;

namespace Artity.Web.Controllers
{
    using Services.Data.Order;
    using Services.Data.Performence;

    public class OrderArtistController : BaseController
    {
        public OrderArtistController(IOrderService orderService, IPerformenceService performenceService)
        {
            this.OrderService = orderService;
            this.PerformenceService = performenceService;
        }

        public IOrderService OrderService { get; }
        public IPerformenceService PerformenceService { get; }


        [Authorize(Roles = GlobalConstants.AllRoles)]
        [Route("/Order/Create/{ArtistNikname}")]
        [HttpPost]
        public async Task<IActionResult> Create([FromRoute]string ArtistNikname, ArtistOrderCreateInputModel model)
        {
            model.ArtistNikname = ArtistNikname;
            model.Username = this.User.Identity.Name;

            if (this.ModelState.IsValid)
            {
                try
                {
                    bool result = await this.OrderService.CreateArtistOrder(model);
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

            //TODO: Refactoring this

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

            var iputModel = new ArtistOrderCreateInputModel() { ArtistNikname = ArtistNikname };

            return this.View(iputModel);
        }


        [Authorize(Roles = GlobalConstants.AllRoles)]
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

            var iputModel = new ArtistOrderCreateInputModel() { ArtistNikname = ArtistNikname };

            return this.View(iputModel);
        }


        [Authorize(Roles = GlobalConstants.AllRoles)]
        [Route("/CreatePerformenceOrder/{id}/{artistNikname}")]
        [HttpGet]
        public IActionResult CreatePerformenceOrder([FromRoute]string id, string artistNikname)
        {

            string performenceTitle;

            try
            {
                performenceTitle = this.PerformenceService.GetPerformence(id).To<PerformneceProfileViewModel>().ToList().First().Title;
                var model = new PerformenceOrderCreateInputModel() { ArtistNikname = artistNikname, PerformenceName = performenceTitle };
                return this.View(model);
            }
            catch (Exception)
            {

                return this.View("Error", new ErrorViewModel() { RequestId = "This performence is not valid" });
            }
        }


        [Authorize(Roles = GlobalConstants.AllRoles)]
        [Route("/CreatePerformenceOrder/{id}/{artistNikname}")]
        [HttpPost]
        public async Task<IActionResult> CreatePerformenceOrder([FromRoute]string id, string artistNikname, PerformenceOrderCreateInputModel model)
        {
            model.ArtistNikname = artistNikname;

            
            model.Username = this.User.Identity.Name;

            model.PerformenceName = this.PerformenceService.GetPerformence(id).To<PerformneceProfileViewModel>().ToList().First().Title;

            if (this.ModelState.IsValid)
            {
                try
                {
                    bool result = await this.OrderService.CreatePerformenceOrder(model);
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

            var errors = this.ModelState.Values.SelectMany(v => v.Errors);

            foreach (var error in errors)
            {
                this.ModelState.AddModelError(string.Empty, error.ErrorMessage);
            }

            return this.View();
        }

    }
}
