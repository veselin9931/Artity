namespace Artity.Data.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using Artity.Data.Common.Models;

    using Artity.Data.Models.Enums;

    public class Offert : BaseModel<string>, IDeletableEntity
    {
        public Offert()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public decimal Price { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        [StringLength(800, MinimumLength = 4)]
        public string Features { get; set; }

        [DefaultValue(false)]
        public bool Contract { get; set; }

        public string Review { get; set; }

        [Required]
        public string Town { get; set; }

        public string Tel { get; set; }

        public string Message { get; set; }

        [Required]
        public OrderType Type { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }



    }
}
