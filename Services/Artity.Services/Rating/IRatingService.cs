using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Artity.Services.Rating
{
    public interface IRatingService
    {
         Task<RatingModel> RateArtist(string userId, string ratedId, int ratingValue);

        // Task<bool> RatePerformence(string userId, string ratedId, int ratingValue);
        bool IsRated(string userId, string ratedName);
    }
}
