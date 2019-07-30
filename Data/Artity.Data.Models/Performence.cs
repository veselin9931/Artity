namespace Artity.Data.Models
{
    using System;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using Artity.Common;
    using Artity.Data.Common.Models;

    public class Performence : BaseModel<string>, IDeletableEntity
    {
        public Performence()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Ratings = new List<Rating>();
            this.Pictures = new List<Picture>();

        }

        [Required]
        [StringLength(50, ErrorMessage = PerformenceErrors.StringLenght, MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        [StringLength(50000, ErrorMessage = PerformenceErrors.StringLenght,MinimumLength =5)]
        public string Description { get; set; }

        [Required]
        [Range(typeof(decimal), "0", "100000", ErrorMessage = PerformenceErrors.Price)]
        public decimal Price { get; set; }

        [Range(0,5)]
        public double Rating => this.Ratings.Count > 0 ?
            this.Ratings.Average(a => a.RatingValue) : 0.0;

        public virtual IList<Rating> Ratings { get; set; }

        [Required]
        public string PerformencePhotoId { get; set; }

        public virtual Picture PerformencePhoto { get; set; }

        public virtual IList<Picture> Pictures { get; set; }

        public string CategoryId { get; set; }

        public virtual Category Category { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }


        public string SocialId { get; set; }

        public virtual Social Social { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
