namespace Artity.Services.Data.Performence
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;
    using Artity.Services.Data.Artists;
    using Artity.Services.Data.File;

    using Artity.Services.Mapping;

    using Artity.Web.InputModels.Performence;

    using Artity.Web.InputModels.Picture;

    public class PerformenceService : IPerformenceService
    {
        private readonly IDeletableEntityRepository<Performence> performenceRepository; 
        private readonly ICloudinaryService cloudinaryService;
        private readonly IPicureService fileService;
        private readonly IArtistService artistService;

        public PerformenceService(
            IDeletableEntityRepository<Performence> performenceRepository,
            ICloudinaryService cloudinaryService,
            IPicureService fileService,
            IArtistService artistService
            )
        {

            this.performenceRepository = performenceRepository;
            this.cloudinaryService = cloudinaryService;
            this.fileService = fileService;
            this.artistService = artistService;
        }

        public async Task<bool> ApprovedPerformence(string id)
        {

            var approvedPerformence = this.performenceRepository.All()
                .FirstOrDefault(a => a.Id == id);
            approvedPerformence.IsApproved = true;

            this.performenceRepository.Update(approvedPerformence);
            var result = await this.performenceRepository.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> CreatePerformence(PerformenceCreateInputModel inputModel, ApplicationUser user)
        {
            Performence performence = AutoMapper.Mapper.Map<Performence>(inputModel);

            if (performence == null)
            {
                return false;
            }

            performence.ArtistId = user.ArtistId;

            var pictureName = performence.Id;

            var pictureUrl = await this.cloudinaryService.UploadPictureAsync(inputModel.PerformencePhoto, pictureName);

            performence.PerformencePhoto.Title = pictureName;
            performence.PerformencePhoto.Link = pictureUrl;
            performence.PerformencePhoto.Description = inputModel.Description;

            PictureInputModel picture = AutoMapper.Mapper.Map<PictureInputModel>(performence.PerformencePhoto);

            var pictureId = await this.fileService.AddPictureToDb(picture);

            performence.PerformencePhotoId = pictureId;

            await this.performenceRepository.AddAsync(performence);
            await this.performenceRepository.SaveChangesAsync();

            bool result = await this.artistService.SetPerformence(user.ArtistId, performence);

            return result;
        }

        public IEnumerable<TViewModel> GetAll<TViewModel>(bool approved)
        {
            return this.performenceRepository
                .All()
                .Where(a => a.IsApproved == approved && a.IsDeleted != true)
                .OrderBy(a => a.CreatedOn)
                .To<TViewModel>().ToList();
        }

        public IEnumerable<TViewModel> GetAllByArtistId<TViewModel>(string artistId)
        {
            return this.artistService.GetAllPerformence<TViewModel>(artistId);
        }

        public IEnumerable<TViewModel> GetAllFrom<TViewModel>(string category)
        {
            return this.performenceRepository
                 .All()
                 .Where(a => a.Category.Name == category && a.IsApproved == true)
                 .OrderBy(a => a.CreatedOn)
                 .To<TViewModel>().ToList();
        }

        public IQueryable GetPerformence(string id)
        {
            return this.performenceRepository
                  .All()
                  .Where(a => a.Id == id && a.IsApproved == true);
        }

        public string GetPerformenceByName(string name)
        {
            return this.performenceRepository
                .All()
                .FirstOrDefault(a => a.Title == name && a.IsApproved == true).Id;
        }

        public async Task<bool> RefusePerformence(string id)
        {
            this.performenceRepository.All()
                 .FirstOrDefault(a => a.Id == id)
                 .IsDeleted = true;

            var result = await this.performenceRepository.SaveChangesAsync();

            return result > 0;
        }
    }
}