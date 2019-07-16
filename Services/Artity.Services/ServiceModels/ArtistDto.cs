namespace Artity.Services.ServiceModels
{
    using Artity.Data.Models;
    using Artity.Services.Mapping;
    using System.Collections.Generic;
    using System.Linq;
    public class ArtistDto : IMapTo<Artist>
    {

        public string Id { get; set; }

        public string Nikname { get; set; }

        public string WorkNumber { get; set; }

        public string AboutMe { get; set; }

        public double Rating =>
            Ratings.Sum(r => r.RatingValue) / Ratings.Count();

        public virtual Category Category { get; set; }

        public virtual Picture ProfilePicture { get; set; }

        public virtual IList<Rating> Ratings { get; set; }


    }

}