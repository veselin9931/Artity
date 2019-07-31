using Artity.Services.Order;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Artity.Web.Controllers
{
    public class OffertController : BaseArtistController
    {
        private readonly IOrderService orderService;

        public OffertController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task<IActionResult> Create()
        {
            this.orderService.CreateOrder(new InputModels.Order.OrderCreateInputModel { Duration = DateTime.UtcNow, EventDate = DateTime.Today, Message = "bashkdajksdjas", Username = " Gosho", Place = "Rim ", Type = "1" });
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string a = "sad")
        {
            return this.Redirect(Common.GlobalConstants.HomeUrl);
        }

    }
}
