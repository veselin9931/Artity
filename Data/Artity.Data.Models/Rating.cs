using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Data.Models
{
    public class Rating
    {
        public Rating()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public string ArtistId { get; set; }

        public Artist Artist { get; set; }

        //TODO Range Attribute 0-5
        public int RatingValue { get; set; }

    }
}
