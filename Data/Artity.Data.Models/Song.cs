namespace Artity.Data.Models
{
    using System;

    using Artity.Data.Common.Models;

    public class Song : BaseDeletableModel<string>
    {
        public Song()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public DateTime UploadDate { get; set; }

        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
