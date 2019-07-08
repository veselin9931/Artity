namespace Artity.Services
{
    using Artity.Data.Models;
    using System.Threading.Tasks;

    public interface IPicureService
    {
        Task<bool> GenerateProfilePicture(string link, string title, string description, ApplicationUser user);

        Task<Picture> AddPictureToDb(string link, string title, string description, ApplicationUser user);

       
    }
}
