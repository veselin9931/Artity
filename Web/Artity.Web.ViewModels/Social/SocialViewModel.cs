using Artity.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Web.ViewModels.Social
{
    public class SocialViewModel : IMapFrom<Data.Models.Social>
    {
        public string Facebook { get; set; }

        public string Youtube { get; set; }

        public string WebSite { get; set; }
    }
}
