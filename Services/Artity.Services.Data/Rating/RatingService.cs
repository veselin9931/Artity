namespace Artity.Services.Data.Rating
{
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;
    using Artity.Data.Models.Enums;

    public class RatingService : IRatingService
    {
        private readonly IRepository<Artist> artistRepo;
        private readonly IRepository<Performence> perfomenceRepo;
        private readonly IRepository<Rating> ratingRepo;

        public RatingService(
            IRepository<Artist> artistRepo,
            IRepository<Artity.Data.Models.Performence> perfomenceRepo,
            IRepository<Rating> ratingRepo
            )
        {
            this.artistRepo = artistRepo;
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
            var ratedArtist = this.artistRepo.All().FirstOrDefault(p => p.Nikname == ratedId);

            var model = new RatingModel();

            if (ratedArtist != null)
            {
                model.RatedId = ratedArtist.Id;

                if (!this.IsRated(userId, ratedArtist.Id))
                {
                    var rating = new Rating
                    {
                        RatingValue = ratingValue,
                        RatedId = ratedArtist.Id,
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