namespace Artity.Data.Models
{
    using System;

    using System.Collections.Generic;

    using Artity.Data.Common.Models;

    public class Performence : BaseModel<string>, IDeletableEntity
    {
        public Performence()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public double Rating { get; set; }

        public virtual IList<Rating> Ratings { get; set; }

        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
