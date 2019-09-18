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
using Microsoft.AspNetCore.Authorization;

namespace Artity.Web.Controllers
{
    using Services.Data.Offert;
    using Services.Data.Order;
    using Services.Data.User;

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

        [HttpGet]
        [Route("Offert/Edit/{offertId}")]
        public async Task<IActionResult> Edit( [FromRoute]string offertId)
        {

            var types = this.offertService.GetAllOffertTypes().MapTo<OffertTypeInputModel[]>();

            var user = this.userService.GetApplicationUserByName(this.User.Identity.Name);
            var offert = this.offertService.GetOffert<OffertEditInputModel>(offertId);
            offert.Categories = types;

            return this.View(offert);
        }

        [HttpPost]
        [Route("Offert/Edit/{offertId}")]
        public async Task<IActionResult> Edit(OffertEditInputModel input, [FromRoute]string offertId)
        {
            if (!this.ModelState.IsValid)
            {
                return await this.Edit(offertId);
            }

            var user = this.userService.GetApplicationUserByName(this.User.Identity.Name);
            await this.offertService.EditOffert(offertId, input.Title, input.Type, input.Review, input.Features, input.Contract, user.Id, input.Tel, input.Price, input.Town);
            return this.Redirect($"/Offert/{offertId}");
        }
    }
}
