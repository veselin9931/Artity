namespace Artity.Web.Controllers
{
    using Artity.Common;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            if (this.User.IsInRole(GlobalConstants.ArtistRoleName))
            {
                return this.View("ArtistDashboard");
            }
            else if (this.User.IsInRole(GlobalConstants.UserRoleName))
            {
                return this.View("Artist/All");
            }
            else if (this.User.IsInRole(GlobalConstants.AdministratorRoleName))
            {
                return this.RedirectToAction(GlobalConstants.Index, GlobalConstants.Dashboard, new { area = GlobalConstants.AdminArea});
            }

            return this.View();
        }

        public IActionResult Contacts()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => this.View();
    }
}
