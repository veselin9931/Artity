namespace Artity.Services.File
{
    using System;
    using System.Threading.Tasks;
    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;
    using System.Linq;
    using Artity.Web.ViewModels.Picture;

    public class PictureService : IPicureService
    {
        private readonly IRepository<Picture> context;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;

        public PictureService(IRepository<Picture> context, IDeletableEntityRepository<ApplicationUser> userRepository)
        {
            this.context = context;
            this.userRepository = userRepository;
        }

        public async Task<Picture> AddPictureToDb(PictureInputModel picture, ApplicationUser user)
        {
            var pic = new Picture { Link = picture.Link, Description = picture.Description, Title = picture.Title, UploadDate = DateTime.UtcNow };
            await this.context.AddAsync(pic);
            await this.context.SaveChangesAsync();
            return pic;
        }

        public async Task<string> AddPictureToDb(PictureInputModel picture)
        {
            var pic = new Picture { Link = picture.Link, Description = picture.Description, Title = picture.Title, UploadDate = DateTime.UtcNow };
            await this.context.AddAsync(pic);
            await this.context.SaveChangesAsync();
            return pic.Id;
        }

        public async Task<bool> GenerateProfilePicture(PictureInputModel picture, ApplicationUser user)
        {
            var newPic = new Picture() { Link = picture.Link, Title = picture.Title, Description = picture.Description };
            await this.context.AddAsync(newPic);
            await this.context.SaveChangesAsync();
            user.PofilePicture = newPic;
            int result = await this.userRepository.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }

            return false;

        }

        public async Task<bool> SetArtistPicture(PictureInputModel picture, ApplicationUser user)
        {
            var newPic = new Picture() { Link = picture.Link, Title = picture.Title, Description = picture.Description };
            await this.context.AddAsync(newPic);
            await this.context.SaveChangesAsync();
            user.Artist.ProfilePicture = newPic;
            int result = await this.userRepository.SaveChangesAsync();
            if (result > 0)
            {
                return true;
            }

            return false;
        }
    }
}
