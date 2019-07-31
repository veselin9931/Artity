using Artity.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Artity.Services
{
    public interface IUserService
    {
         ApplicationUser GetApplicationUserByName(string name);

        void AddArtistSettings(ApplicationUser user, Data.Models.Artist artist);

         Task SetFirstLogin(ApplicationUser user);



    }
}
