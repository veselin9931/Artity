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
            this.Pictures = new List<Picture>();

        }

        //[Required]
        //[StringLength(50, ErrorMessage = PerformenceErrors.StringLenght, MinimumLength = 4)]
        public string Title { get; set; }

        //[Required]
        //[StringLength(50000, ErrorMessage = PerformenceErrors.StringLenght,MinimumLength =5)]
        public string Description { get; set; }

        //[Required]
        //[Range(typeof(decimal), "0", "100000", ErrorMessage = PerformenceErrors.Price)]
        public decimal Price { get; set; }

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

        [Required]
        public bool IsApproved { get; set; }

    }
}
