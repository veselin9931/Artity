namespace Artity.Data.Models
{
    using System;

    using Artity.Data.Common.Models;

    public class Picture : BaseModel<string>, IDeletableEntity
    {
        public Picture()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public DateTime UploadDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
