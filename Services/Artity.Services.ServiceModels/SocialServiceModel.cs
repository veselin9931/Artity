using Artity.Data.Models;
using Artity.Services.Mapping;

namespace Artity.Services.ServiceModels
{
    public class SocialServiceModel : IMapTo<Social>, IMapFrom<Social>
    {
        public string Facebook { get; set; }

        public string Youtube { get; set; }

        public string WebSite { get; set; }

    }
}
