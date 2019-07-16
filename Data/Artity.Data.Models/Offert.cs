namespace Artity.Data.Models
{
    using System;

    using Artity.Data.Common.Models;

    using Artity.Data.Models.Enums;

    public class Offert : BaseModel<string>, IDeletableEntity
    {
        public Offert()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public decimal Price { get; set; }

        public DateTime Еngagement { get; set; }

        public string Features { get; set; }

        public string Message { get; set; }

        public OrderType Type { get; set; }

        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

    }
}
