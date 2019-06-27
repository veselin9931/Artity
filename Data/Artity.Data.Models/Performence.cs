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

        public IList<Rating> Ratings { get; set; }
    }
}
