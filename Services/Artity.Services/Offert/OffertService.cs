using System;
using System.Collections.Generic;
using System.Text;
using Artity.Data.Models.Enums;
using Artity.Services.ServiceModels;
using System.Linq;
using System.Threading.Tasks;
using Artity.Data.Common.Repositories;
using Artity.Services.Artists;

namespace Artity.Services.Offert
{
    public class OffertService : IOffertService
    {
        private readonly IRepository<Data.Models.Offert> repository;
        private readonly IUserService userService;

        public OffertService(IRepository<Data.Models.Offert> repository)
        {
            this.repository = repository;
        }

        public OffertService(IRepository<Data.Models.Offert> repository, IUserService userService)
        {
            this.repository = repository;
            this.userService = userService;
        }

        public async Task<bool> CreateOffert(string title, int type, string review, string features, bool contract, string userId, string tel, decimal price, string town)
        {
            var artistId = await this.userService.GetArtistId(userId);

            var offer = new Data.Models.Offert()
            {
                Title = title,
                Type = (OrderType)type,
                Review = review,
                Features = features,
                Contract = contract,
                ArtistId = artistId,
                Tel = tel,
                Price = price,
                Town = town,
            };

           await this.repository.AddAsync(offer);
           var result = await this.repository.SaveChangesAsync();

            return result > 0;
        }

        public IEnumerable<OffertTypeServiceModel> GetAllOffertTypes()
        {
            var types = new List<OffertTypeServiceModel>();
            string[] names = Enum.GetNames(typeof(OrderType));
            int[] values = (int[])Enum.GetValues(typeof(OrderType));

            for (int i = 0; i < values.Length; i++)
            {
                types.Add(new OffertTypeServiceModel() { Name = names[i], EnumValue = values[i] });
            }
            return types;
        }
    }
}
