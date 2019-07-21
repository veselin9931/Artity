namespace Artity.Services.File
{
    using System.Threading.Tasks;

    using Artity.Data.Models;

    using Artity.Web.ViewModels.Picture;

    public interface IPicureService
    {

        //TODO add parametar username

        Task<bool> GenerateProfilePicture(PictureInputModel picture, ApplicationUser user);

        Task<Picture> AddPictureToDb(PictureInputModel picture, ApplicationUser user);

        Task<string> AddPictureToDb(PictureInputModel picture);

        Task<bool> SetArtistPicture(PictureInputModel picture, ApplicationUser user);
    }
}
