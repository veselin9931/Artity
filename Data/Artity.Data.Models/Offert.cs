using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Data.Models
{
    public class Offert
    {
        public string Id { get; set; }

        public decimal Price { get; set; }

        public DateTime Еngagement { get; set; }

        public string Features { get; set; }

        public string Message { get; set; }

        public OfertType Type { get; set; }

    }
}
