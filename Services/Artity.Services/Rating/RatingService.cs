using Artity.Data.Common.Repositories;
using System;
using Artity.Data.Models;
using System.Threading.Tasks;
using Artity.Common;
using System.Linq;
using Artity.Data.Models.Enums;

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

        public bool IsRated(string userId, string ratedId)
        {
            return this.ratingRepo.All().Any(a => a.UserId == userId && a.RatedId == ratedId);
        }

        public async Task<RatingModel> RateArtist(string userId, string ratedId, int ratingValue)
        {
            var ratedArtist = this.artistRepo.All().FirstOrDefault(p => p.Nikname == ratedId);

            var model = new RatingModel();

            model.RatedId = ratedId;

            if (ratedArtist != null)
            {
                if (!this.IsRated(userId, ratedArtist.Id))
                {
                    var rating = new Data.Models.Rating() { RatingValue = ratingValue, RatedId = ratedArtist.Id, UserId = userId,  Type = RatingType.Artist };
                    await this.ratingRepo.AddAsync(rating);
                    await this.ratingRepo.SaveChangesAsync();
                    model.Rating = ratingValue;
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

        public async Task<RatingModel> RatePerformence(string userId, string performenceName, int ratingValue)
        {
            var ratedId = this.perfomenceRepo.All().FirstOrDefault(p => p.Title == performenceName);

            var model = new RatingModel();

            model.RatedId = performenceName;

            if (ratedId != null)
            {
                if (!this.IsRated(userId, ratedId.Id))
                {
                    var rating = new Data.Models.Rating() { RatingValue = ratingValue, RatedId = ratedId.Id, UserId = userId, Type = RatingType.Performence };
                    await this.ratingRepo.AddAsync(rating);
                    await this.ratingRepo.SaveChangesAsync();
                    model.Rating = ratingValue;
                }
                else
                {
                    model.Error = "Alrady rated";
                }
            }
            else
            {
                model.Error = "Incorect performence";
            }

            return model;
        }
    }

}