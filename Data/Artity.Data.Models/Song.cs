namespace Artity.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Artity.Data.Common.Models;

    public class Song : BaseDeletableModel<string>
    {
        public Song()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Link { get; set; }

        public DateTime UploadDate { get; set; }

        [Required]
        public string ArtistId { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
