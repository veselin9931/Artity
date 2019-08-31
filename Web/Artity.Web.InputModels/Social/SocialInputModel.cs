namespace Artity.Web.InputModels.Social
{
    using System.ComponentModel.DataAnnotations;
    using Artity.Services.Mapping;
    using Artity.Services.ServiceModels;

    public class SocialInputModel : IMapTo<SocialServiceModel>, IMapFrom<SocialServiceModel>
    {
        public string ArtistId { get; set; }

        [Phone]
        [Display(Name = "Facebook")]
        public string Facebook { get; set; }

        [Phone]
        [Display(Name = "Youtube")]
        public string Youtube { get; set; }

        [Phone]
        [Display(Name = "Website")]
        public string Website { get; set; }
    }
}
