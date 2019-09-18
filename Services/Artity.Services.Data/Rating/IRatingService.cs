namespace Artity.Services.Data.Rating
{
    using System.Threading.Tasks;

    using Artity.Data.Models.Enums;

    public interface IRatingService
    {
        Task<RatingModel> RateArtist(string userId, string ratedId, int ratingValue);

        bool IsRated(string userId, string ratedName);

        Task<RatingModel> RatePerformence(string userId, string performenceName, int ratingValue);

        double GetRate(RatingType type, string rateId);

    }
}
