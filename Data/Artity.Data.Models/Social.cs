using Artity.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Data.Models
{
    public class Social : BaseModel<string>, IDeletableEntity
    {
        public Social()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Facebook { get; set; }

        public string Youtube { get; set; }

        public string WebSite { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }
    }
}
