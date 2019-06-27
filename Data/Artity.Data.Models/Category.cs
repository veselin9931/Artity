using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Data.Models
{
    public class Category
    {
        public Category()
        {
            this.Artists = new List<Artist>();
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public Enum CategoryType { get; set; }

        public Picture PictureId { get; set; }

        public IList<Artist> Artists { get; set; }
    }
}
