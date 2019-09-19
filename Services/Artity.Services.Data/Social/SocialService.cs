namespace Artity.Services.Data.Social
{
    using System;

    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;

    using Artity.Services.ServiceModels;

    using Artity.Data.Models;

    using Artity.Services.Mapping;

    public class SocialService : ISocialService
    {
        private readonly IDeletableEntityRepository<Social> socialRepository;

        public SocialService(IDeletableEntityRepository<Social> socialRepository)
        {
            this.socialRepository = socialRepository;
        }

        public async Task<bool> AddSocial(SocialServiceModel socialServiceModel)
        {
            Social social = socialServiceModel.MapTo<Social>();

            await this.socialRepository.AddAsync(social);
            var result = await this.socialRepository.SaveChangesAsync();

            return result > 0;
        }
    }
}
