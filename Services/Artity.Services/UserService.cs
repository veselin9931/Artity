using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public ApplicationUser GetApplicationUserByName(string name)
        {
            return context.Users.
                FirstOrDefault(a => a.UserName.ToLower() == name.ToLower());

        }

        public async Task<string> GetArtistEmail(string id)
        {
           return this.context.Users.FirstOrDefault(u => u.ArtistId == id).Email;
        }

        public async Task SetFirstLogin(ApplicationUser user)
        {
            var dbuser = await this.context.Users.FindAsync(user.Id); 
           user.FirstLogin = true;
            await this.context.SaveChangesAsync();

        }
    }
}
