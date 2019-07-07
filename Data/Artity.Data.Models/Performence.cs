using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Data.Models
{
    public class Performence
    {
        public Performence()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }


        public double Rating { get; set; }

        public virtual IList<Rating> Ratings { get; set; }

        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
