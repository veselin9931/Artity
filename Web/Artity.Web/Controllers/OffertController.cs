﻿using Artity.Services.Offert;
using Artity.Services.Order;
using Artity.Web.InputModels.Order;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Artity.Services.Mapping;
using Artity.Web.InputModels.Type;
using Artity.Web.InputModels.Offert;
using Artity.Services;
using Artity.Web.ViewModels.Offert;

namespace Artity.Web.Controllers
{
    public class OffertController : BaseArtistController
    {
        private readonly IOrderService orderService;
        private readonly IOffertService offertService;
        private readonly IUserService userService;

        public OffertController(IOrderService orderService, IOffertService offertService, IUserService userService)
        {
            this.orderService = orderService;
            this.offertService = offertService;
            this.userService = userService;
        }

        public async Task<IActionResult> Create()
        {
            var types = this.offertService.GetAllOffertTypes().MapTo<OffertTypeInputModel[]>();

            var result = new OffertInputModel()
            {
                Categories = types,
            };

            return this.View(result);
        }

        [HttpGet]
        [Route("Offert/{offertId}")]
        public async Task<IActionResult> Offert(string offertId)
        {
            var result = this.offertService.GetOffert<OffertViewModel>(offertId);

            return this.View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OffertInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return await this.Create();
            }

            var user = this.userService.GetApplicationUserByName(this.User.Identity.Name);
            await this.offertService.CreateOffert(input.Title,input.Type, input.Review, input.Features, input.Contract, user.Id, input.Tel, input.Price, input.Town);
            return this.Redirect(Common.GlobalConstants.HomeUrl);
        }

        public async Task<IActionResult> Delete(string offertId)
        {
           var result = await this.offertService.DeleteOffert(offertId);

           if (result == true)
            {
                return this.Redirect("/Offerts");
            }

           return this.NotFound();
        }

        [HttpPost]
        [Route("Offert/Edit/{offertId}")]
        public async Task<IActionResult> Edit(OffertEditInputModel input, [FromRoute]string offertId)
        {
            if (!this.ModelState.IsValid)
            {
                return await this.Create();
            }

            var user = this.userService.GetApplicationUserByName(this.User.Identity.Name);
            await this.offertService.EditOffert(offertId,input.Title, input.Type, input.Review, input.Features, input.Contract, user.Id, input.Tel, input.Price, input.Town);
            return this.Redirect("/Offerts");
        }
    }
}
