using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Artity.Data;
using Artity.Data.Models;

namespace Artity.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext context;

        public UserService(ApplicationDbContext context)
        {
            this.context = context;
        }

    
        public void AddArtistSettings(ApplicationUser user, Artist artist)
        {
            this.context.Artists.Add(artist);
            this.context.SaveChanges();
            user.ArtistId = artist.Id;
            this.context.Users.Update(user);
            this.context.SaveChanges();
        }

        public  ApplicationUser GetApplicationUserByName(string name)
        {


          return   context.Users.FirstOrDefault(a=> a.Email == name);

        }
    }
}
