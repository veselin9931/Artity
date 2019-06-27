using Artity.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Data.Models
{
    public class Order
    {
        public Order()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string ArtistId { get; set; }
        public Artist Artist { get; set; }

        public OrderType Type { get; set; }

        public string Message { get; set; }

    }
}
