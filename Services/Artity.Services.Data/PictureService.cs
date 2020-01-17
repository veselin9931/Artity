namespace Artity.Services.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;
    using Artity.Services.Data.ServiceModels;
    using Artity.Services.Mapping;

    public class PictureService : IPictueService
    {
        private readonly IDeletableEntityRepository<Picture> pictureRepository;

        public PictureService(IDeletableEntityRepository<Picture> pictureRepository)
        {
            this.pictureRepository = pictureRepository;
        }

        public Task<string> AddPictureToDb(string title, string description, string link)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeletePicture(string id)
        {
            throw new NotImplementedException();
        }

        public TPictureModel GetPicture<TPictureModel>(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return default;

                // TODO: exeption
            }

            var picture = this.pictureRepository.All().FirstOrDefault(p => p.Id == id);

            if (picture == null)
            {
                return default;

                // TODO: exeption
            }

            var mapObJ = picture.MapTo<PictureServiceModel>();

            return mapObJ.MapTo<TPictureModel>();
        }

        public Task<bool> SetArtistPicture(string pictureId, string artistId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SetUserProfilePicture(string pictureId, string userId)
        {
            throw new NotImplementedException();
        }

        public Task<TPictureModel> UpdatePicture<TPictureModel>(string id)
        {
            throw new NotImplementedException();
        }
    }
}
