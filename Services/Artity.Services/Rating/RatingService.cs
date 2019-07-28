using Artity.Data.Common.Repositories;
using System;
using Artity.Data.Models;
using System.Threading.Tasks;
using Artity.Common;
using System.Linq;

namespace Artity.Services.Rating
{
    public class RatingService : IRatingService
    {
        private readonly IRepository<Artist> artistRepo;
        private readonly IRepository<Data.Models.Performence> perfomenceRepo;
        private readonly IRepository<Data.Models.Rating> ratingRepo;

        public RatingService(
            IRepository<Artist> artistRepo,
            IRepository<Artity.Data.Models.Performence> perfomenceRepo,
            IRepository<Data.Models.Rating> ratingRepo
            )
        {
            this.artistRepo = artistRepo;
            this.perfomenceRepo = perfomenceRepo;
            this.ratingRepo = ratingRepo;
        }

        public bool IsRated(string userId, string ratedName)
        {

            var artist = this.artistRepo.All().FirstOrDefault(a => a.Nikname == ratedName);
            return this.ratingRepo.All().Any(a => a.UserId == userId && a.ArtistId == artist.Id);
        }

        public async Task<RatingModel> RateArtist(string userId, string ratedId, int ratingValue)
        {
            var ratedArtist = this.artistRepo.All().FirstOrDefault(p => p.Nikname == ratedId);

            var model = new RatingModel();

            model.RatedId = ratedId;

            if (ratedArtist != null)
            {
                if (!this.IsRated(userId, ratedId))
                {
                    var rating = new Data.Models.Rating() { RatingValue = ratingValue, ArtistId = ratedArtist.Id, UserId = userId };
                    await this.ratingRepo.AddAsync(rating);
                    await this.ratingRepo.SaveChangesAsync();
                    ratedArtist.Ratings.Add(rating);
                    this.artistRepo.Update(ratedArtist);
                    await this.artistRepo.SaveChangesAsync();
                    model.Rating = ratedArtist.Rating;
                }
                else
                {
                    model.Error = "Alrady rated";
                }
            }
            else
            {
                model.Error = "Incorect artist";
            }

            return model;

        }

    }

}