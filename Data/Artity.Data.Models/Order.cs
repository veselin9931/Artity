namespace Artity.Data.Models
{
    using System;

    using Artity.Data.Common.Models;

    using Artity.Data.Models.Enums;

    public class Order : BaseModel<string>, IDeletableEntity
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime IssuedOn { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public OrderType Type { get; set; }

        public string Message { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

    }
}
