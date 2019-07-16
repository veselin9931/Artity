namespace Artity.Data.Models
{
    using System;

    using System.Collections.Generic;

    using System.Linq;

    using Artity.Data.Common.Models;

    public class Artist : BaseModel<string>, IDeletableEntity
    {
        public Artist()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Offerts = new List<Offert>();
            this.Ratings = new List<Rating>();
        }

        public string Nikname { get; set; }

        public string WorkNumber { get; set; }

        public string Description { get; set; }

        public string AboutMe { get; set; }

        public double Rating =>
            this.Ratings.Sum(r => r.RatingValue) / this.Ratings.Count();

        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string ProfilePictureId { get; set; }

        public virtual Picture ProfilePicture { get; set; }

        public virtual IList<Offert> Offerts { get; set; }

        public virtual IList<Rating> Ratings { get; set; }

        public virtual IList<Performence> Performences { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
