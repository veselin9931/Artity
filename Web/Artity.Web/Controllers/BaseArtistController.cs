namespace Artity.Web.Controllers
{
    using Artity.Common;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.ArtistRoleName)]
    public abstract class BaseArtistController : Controller
    {
    }
}
