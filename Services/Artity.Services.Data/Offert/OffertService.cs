namespace Artity.Services.Data.Offert
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;
    using Artity.Data.Models;
    using Artity.Data.Models.Enums;

    using Mapping;

    using ServiceModels;

    using User;

    public class OffertService : IOffertService
    {
        private readonly IRepository<Offert> repository;
        private readonly IUserService userService;

        public OffertService(IRepository<Offert> repository)
        {
            this.repository = repository;
        }

        public OffertService(IRepository<Offert> repository, IUserService userService)
        {
            this.repository = repository;
            this.userService = userService;
        }

        public async Task<bool> CreateOffert(string title, int type, string review, string features, bool contract, string userId, string tel, decimal price, string town)
        {
            var artistId = await this.userService.GetArtistId(userId);

            var offer = new Offert()
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

        public async Task<bool> DeleteOffert(string id)
        {
            var offert = this.repository
                .All()
                .FirstOrDefault(a => a.Id == id);

            if (offert != null)
            {
                this.repository
                   .Delete(offert);

                int result = await this.repository.SaveChangesAsync();
                return result > 0;

            }

            throw new NullReferenceException();
        }

        public async Task<bool> EditOffert(string id, string title, int type, string message, string features, bool contract, string userId, string tel, decimal price, string town)
        {
            var offert = this.repository
               .All()
               .FirstOrDefault(a => a.Id == id);

            if (offert != null)
            {
                offert.Title = title;
                offert.Type = (OrderType)type;
                offert.Message = message;
                offert.Features = features;
                offert.Contract = contract;
                offert.Tel = tel;
                offert.Price = price;
                offert.Town = town;

                this.repository.Update(offert);

                int result = await this.repository.SaveChangesAsync();
                return result > 0;

            }

            throw new NullReferenceException();
        }

        public IEnumerable<TViewModel> GetAllOfferts<TViewModel>(string artistid)
        {
          return this.repository
                .All()
                .Where(a => a.ArtistId == artistid && a.IsDeleted != true)
                .To<TViewModel>();
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

        public TViewModel GetOffert<TViewModel>(string artistid)
        {
           return this.repository.All()
                 .FirstOrDefault(a => a.Id == artistid && a.IsDeleted != true)
                 .MapTo<TViewModel>();
        }
    }
}
