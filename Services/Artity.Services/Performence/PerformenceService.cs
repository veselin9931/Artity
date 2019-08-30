namespace Artity.Services.Performence
{
    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;

    using Artity.Data.Models;

    using Artity.Web.InputModels.Performence;

    using Microsoft.AspNetCore.Identity;

    using System.Linq;

    using Artity.Services.File;

    using Artity.Web.InputModels.Picture;

    using Artity.Services.Mapping;

    using System.Collections.Generic;

    public class PerformenceService : IPerformenceService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<Performence> repository;
        private readonly IRepository<Artist> repositoryArtists;
        private readonly ICloudinaryService cloudinaryService;
        private readonly IPicureService fileService;

        public PerformenceService(UserManager<ApplicationUser> userManager,
            IRepository<Artity.Data.Models.Performence> repository,
            IRepository<Artist> repositoryArtists,
            ICloudinaryService cloudinaryService,
            IPicureService fileService
            )
        {
            this.userManager = userManager;
            this.repository = repository;
            this.repositoryArtists = repositoryArtists;
            this.cloudinaryService = cloudinaryService;
            this.fileService = fileService;
        }

        public async Task<bool> ApprovedPerformence(string id)
        {

            var approvedArtist = this.repository.All()
                .FirstOrDefault(a => a.Id == id);
            approvedArtist.IsApproved = true;

            this.repository.Update(approvedArtist);
            var result = await this.repository.SaveChangesAsync();

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

            var artist = this.repositoryArtists.All()
                .FirstOrDefault(a => a.Id == user.ArtistId);

            artist.Performences.Add(performence);
            await this.repository.AddAsync(performence);
            this.repositoryArtists.Update(artist);

            await this.repository.SaveChangesAsync();
            await this.repositoryArtists.SaveChangesAsync();

            return true;
        }

        public IEnumerable<TViewModel> GetAll<TViewModel>(bool approved)
        {
            return this.repository
                .All()
                .Where(a => a.IsApproved == approved && a.IsDeleted != true)
                .OrderBy(a => a.CreatedOn)
                .To<TViewModel>().ToList();
        }

        public IEnumerable<TViewModel> GetAll<TViewModel>(string artistId)
        {
            return this.repositoryArtists
               .All()
               .FirstOrDefault(a => a.Id == artistId)
               .Performences
               .AsQueryable()
               .To<TViewModel>().ToList();
        }

        public IEnumerable<TViewModel> GetAllFrom<TViewModel>(string category)
        {
            return this.repository
                 .All()
                 .Where(a => a.Category.Name == category && a.IsApproved == true)
                 .OrderBy(a => a.CreatedOn)
                 .To<TViewModel>().ToList();
        }

        public IQueryable GetPerformence(string id)
        {
            return this.repository
                  .All()
                  .Where(a => a.Id == id && a.IsApproved == true);
        }

        public string GetPerformenceByName(string name)
        {
            return this.repository
                .All()
                .FirstOrDefault(a => a.Title == name && a.IsApproved == true).Id;
        }

        public async Task<bool> RefusePerformence(string id)
        {
            this.repository.All()
                 .FirstOrDefault(a => a.Id == id)
                 .IsDeleted = true;

            var result = await this.repository.SaveChangesAsync();

            return result > 0;
        }
    }
}