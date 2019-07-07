using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Data.Models
{
    public class Song
    {
        public Song()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public DateTime UploadDate { get; set; }

        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
