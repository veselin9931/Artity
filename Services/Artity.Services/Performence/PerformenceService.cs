namespace Artity.Services.Performence
{
    using System;

    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;

    using Artity.Data.Models;

    using Artity.Web.ViewModels.Performence;

    using Microsoft.AspNetCore.Identity;

    using System.Linq;

    public class PerformenceService : IPerformenceService
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IRepository<Performence> repository;
        private readonly IRepository<Artist> repositoryArtists;

        public PerformenceService(UserManager<ApplicationUser> userManager, IRepository<Artity.Data.Models.Performence> repository, IRepository<Artist> repositoryArtists)
        {
            this.userManager = userManager;
            this.repository = repository;
            this.repositoryArtists = repositoryArtists;
        }

        public async Task<bool> CreatePerformence(PerformenceCreateInputModel inputModel, ApplicationUser user)
        {
            Performence performence = AutoMapper.Mapper.Map<Performence>(inputModel);

            performence.ArtistId = user.ArtistId;
            performence.PerformencePhotoId = "0a32f4ee-8839-4572-b708-c84eb71ca21c";

            var artist = this.repositoryArtists.All()
                .FirstOrDefault(a => a.Id == user.ArtistId);

            artist.Performences.Add(performence);
            await this.repository.AddAsync(performence);
            this.repositoryArtists.Update(artist);

            await this.repository.SaveChangesAsync();
            await this.repositoryArtists.SaveChangesAsync();


            if (performence == null)
            {
                return false;
            }

            return true;
        }
    }
}