namespace Artity.Data.Models
{
    using System;

    public class Picture
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public DateTime UploadDate { get; set; }
    }
}
