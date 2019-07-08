namespace Artity.Services
{
    using System;
    using System.Threading.Tasks;
    using Artity.Data;
    using Artity.Data.Models;

    public class PictureService : IPicureService
    {
        private readonly ApplicationDbContext context;

        public PictureService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Picture> AddPictureToDb(string link, string title, string description, ApplicationUser user)
        {
            var pic = new Picture { Link = link, Description = description, Title = title, UploadDate = DateTime.UtcNow };
            await this.context.Pictures.AddAsync(pic);
            await this.context.SaveChangesAsync();
            return pic;
        }

        public async Task<bool> GenerateProfilePicture(string link, string title, string description, ApplicationUser user)
        {
            var pic = new Picture { Link = link, Description = description, Title = title, UploadDate = DateTime.UtcNow };
            user.PofilePictureId = pic.Id;
            await this.context.Pictures.AddAsync(pic);
            await this.context.SaveChangesAsync();
            this.context.Users.Update(user);
            var upadteuser = this.context.Users.Find(user.Id);

            return upadteuser.PofilePicture != null;
        }
    }
}
