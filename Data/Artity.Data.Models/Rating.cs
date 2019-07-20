namespace Artity.Data.Models
{

    using System;

    using System.ComponentModel.DataAnnotations;

    using Artity.Data.Common.Models;

    public class Rating : BaseModel<string>, IDeletableEntity
    {
        public Rating()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        [Range(1, 5)]
        public int RatingValue { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

    }
}
