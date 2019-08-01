﻿using Artity.Services.Order;
using Artity.Web.InputModels.Order;
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
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string a = "sad")
        {
            return this.Redirect(Common.GlobalConstants.HomeUrl);
        }

    }
}
