namespace Artity.Data.Models
{
    using System;

    using System.Collections.Generic;

    using Artity.Data.Common.Models;

    using Artity.Data.Models.Enums;

    public class Category : BaseModel<string>, IDeletableEntity
    {
        public Category()
        {
            this.Artists = new List<Artist>();
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public CategoryType CategoryType { get; set; }

        public virtual Picture Picture { get; set; }

        public string PictureId { get; set; }

        public virtual IList<Artist> Artists { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
