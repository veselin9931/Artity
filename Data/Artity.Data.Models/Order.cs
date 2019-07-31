namespace Artity.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Artity.Data.Common.Models;

    using Artity.Data.Models.Enums;

    public class Order : BaseModel<string>, IDeletableEntity
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        public DateTime EventDate { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        [Required]
        public OrderType Type { get; set; }

        [Required]
        public OrderStatus Stauts { get; set; }

        public string Place { get; set; }

        public DateTime Duration { get; set; }

        public string Message { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

    }
}
