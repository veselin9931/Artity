using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Artity.Data.Models
{
    public class Artist
    {

        public Artist()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Offerts = new List<Offert>();
            this.Ratings = new List<Rating>();
        }
        public string Id { get; set; }

        public string Nikname { get; set; }

        public string WorkNumber { get; set; }

        public string AboutMe { get; set; }

        public double Rating => 
            Ratings.Sum(r => r.RatingValue) / Ratings.Count();

        public string CategoryId { get; set; }

        public Category Category { get; set; }

        public string ProfilePictureId { get; set; }

        public Picture ProfilePicture { get; set; }

        public IList<Offert> Offerts { get; set; }

        public IList<Rating> Ratings { get; set; }

        public IList<Performence> Performences { get; set; }


    }
}
