using Artity.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Data.Models
{
    public class Offert
    {
        public Offert()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public decimal Price { get; set; }

        public DateTime Еngagement { get; set; }

        public string Features { get; set; }

        public string Message { get; set; }

        public OrderType Type { get; set; }

        public string ArtistId { get; set; }

        public Artist Artist { get; set; }

    }
}
