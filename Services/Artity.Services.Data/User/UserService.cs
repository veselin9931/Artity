namespace Artity.Services.Data.User
{
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;

    using Microsoft.EntityFrameworkCore;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> context;
        private readonly IDeletableEntityRepository<Artist> repository;

        public UserService(IDeletableEntityRepository<ApplicationUser> context, IDeletableEntityRepository<Artist> repository)
        {
            this.context = context;
            this.repository = repository;
        }

        public void AddArtistSettings(ApplicationUser user, Artist artist)
        {
            this.repository.AddAsync(artist).GetAwaiter().GetResult();
            this.repository.SaveChangesAsync().GetAwaiter().GetResult();
            user.ArtistId = artist.Id;
            this.context.Update(user);
            this.context.SaveChangesAsync().GetAwaiter().GetResult();
        }

        public ApplicationUser GetApplicationUserByName(string name)
        {
            return this.context.All().
                FirstOrDefault(a => a.UserName.ToLower() == name.ToLower());

        }

        public async Task<string> GetArtistEmail(string id)
        {
           return this.context.All().FirstOrDefault(u => u.ArtistId == id).Email;
        }

        public async Task<string> GetArtistId(string id)
        {
          return this.context
                .All()
                .FirstOrDefault(a => a.Id == id).ArtistId;
        }

        public async Task SetFirstLogin(ApplicationUser user)
        {
            var dbuser = await this.context.All().FirstOrDefaultAsync(x => x.Id == user.Id);
            user.FirstLogin = true;
            await this.context.SaveChangesAsync();
        }
    }
}
