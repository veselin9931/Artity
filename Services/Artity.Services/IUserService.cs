using Artity.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Services
{
    public interface IUserService
    {
         ApplicationUser GetApplicationUserByName(string name);

        void AddArtistSettings(ApplicationUser user, Artist artist);

    }
}
