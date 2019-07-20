namespace Artity.Data.Models
{
    using System;

    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Artity.Data.Common.Models;

    public class Performence : BaseModel<string>, IDeletableEntity
    {
        public Performence()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public double Rating { get; set; }

        public virtual IList<Rating> Ratings { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
