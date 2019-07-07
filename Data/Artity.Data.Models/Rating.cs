using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public virtual ApplicationUser User { get; set; }

        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }

        //TODO Range Attribute 0-5
        [Range(1,5)]
        public int RatingValue { get; set; }

    }
}
