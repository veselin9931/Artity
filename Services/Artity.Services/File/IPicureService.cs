namespace Artity.Services.File
{
    using System.Threading.Tasks;

    using Artity.Data.Models;

    using Artity.Web.ViewModels.Picture;

    public interface IPicureService
    {
        Task<bool> GenerateProfilePicture(PictureInputModel picture, ApplicationUser user);

        Task<Picture> AddPictureToDb(PictureInputModel picture, ApplicationUser user);
    }
}
