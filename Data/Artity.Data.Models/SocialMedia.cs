namespace Artity.Data.Models
{
    using System;

    using Artity.Data.Common.Models;

    public class SocialMedia
    {
        public SocialMedia()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Facebook { get; set; }

        public string Instagram { get; set; }

        public string Website { get; set; }

        public string Phone { get; set; }

        public string Youtube { get; set; }

        public string Twitter { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
