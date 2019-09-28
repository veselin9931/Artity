namespace Artity.Services.Data.Rating
{
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;
    using Artity.Data.Models.Enums;
    using Artity.Services.Data.Artists;

    public class RatingService : IRatingService
    {
        private readonly IArtistService artistService;
        private readonly IDeletableEntityRepository<Performence> perfomenceRepo;
        private readonly IDeletableEntityRepository<Rating> ratingRepo;

        public RatingService(
            IArtistService artistService,
            IDeletableEntityRepository<Performence> perfomenceRepo,
            IDeletableEntityRepository<Rating> ratingRepo
            )
        {
            this.artistService = artistService;
            this.perfomenceRepo = perfomenceRepo;
            this.ratingRepo = ratingRepo;
        }

        public double GetRate(RatingType type, string rateId)
        {
            var rating = this.ratingRepo.All()
                      .Where(a => a.RatedId == rateId && a.Type == type)
                      .Select(a => a.RatingValue);

            if (rating.ToList().Count == 0)
            {
                return 0;
            }

            return rating.Average();

        }

        public bool IsRated(string userId, string ratedId)
        {
            return this.ratingRepo.All()
                .Any(a => a.UserId == userId && a.RatedId == ratedId);
        }

        public async Task<RatingModel> RateArtist(string userId, string ratedId, int ratingValue)
        {
            var ratedArtistId = await this.artistService.GetArtistIdByNameAsync(ratedId);

            var model = new RatingModel();

            if (ratedArtistId != null)
            {
                model.RatedId = ratedArtistId;

                if (!this.IsRated(userId, ratedArtistId))
                {
                    var rating = new Rating
                    {
                        RatingValue = ratingValue,
                        RatedId = ratedArtistId,
                        UserId = userId,
                        Type = RatingType.Artist,
                    };
                    await this.ratingRepo.AddAsync(rating);
                    await this.ratingRepo.SaveChangesAsync();
                    model.Rating = this.GetRate(rating.Type, model.RatedId);

                }
                else
                {
                    model.Rating = this.GetRate(RatingType.Artist, model.RatedId);
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
            var performence = this.perfomenceRepo.All().FirstOrDefault(p => p.Title == performenceName);

            var model = new RatingModel();

            if (performence != null)
            {
                model.RatedId = performence.Id;

                if (!this.IsRated(userId, performence.Id))
                {
                    var rating = new Rating() { RatingValue = ratingValue, RatedId = performence.Id, UserId = userId, Type = RatingType.Performence };
                    await this.ratingRepo.AddAsync(rating);
                    await this.ratingRepo.SaveChangesAsync();
                    model.Rating = this.GetRate(rating.Type, performence.Id);
                }
                else
                {
                    model.Rating = this.GetRate(RatingType.Performence, model.RatedId);
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