namespace Artity.Services.Data.Social
{
    using System.Threading.Tasks;

    using Artity.Services.ServiceModels;

    public interface ISocialService
    {
        Task<bool> AddSocial(SocialServiceModel socialServiceModel);

        Task<bool> SetSocialAsync(string artistId, SocialServiceModel socialServiceModel)
    }
}
