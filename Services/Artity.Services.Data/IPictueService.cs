namespace Artity.Services.Data
{
    using System.Threading.Tasks;

    public interface IPictueService
    {
        Task<string> AddPictureToDb(string title, string description, string link);

        Task<TPictureModel> GetPicture<TPictureModel>(string id);

        Task<bool> DeletePicture(string id);

        Task<bool> SetArtistPicture(string pictureId,string artistId);

        Task<bool> SetUserProfilePicture(string pictureId, string userId);
    }
}
