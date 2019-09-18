namespace Artity.Services.Data.User
{
    using System.Threading.Tasks;

    using Artity.Data.Models;

    public interface IUserService
    {
         ApplicationUser GetApplicationUserByName(string name);

        void AddArtistSettings(ApplicationUser user, Artist artist);

         Task SetFirstLogin(ApplicationUser user);

         Task<string> GetArtistEmail(string id);

         Task<string> GetArtistId(string id);
    }
}
