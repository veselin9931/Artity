using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Artity.Web.Controllers
{
    public class ArtistController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}