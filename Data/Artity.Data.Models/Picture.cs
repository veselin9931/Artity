namespace Artity.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Artity.Data.Common.Models;
    using Artity.Services.Mapping;


    public class Picture : BaseModel<string>, IDeletableEntity
    {
        public Picture()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Link { get; set; }

        public DateTime UploadDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
