namespace Artity.Services.Order
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;

    using Artity.Services.Artists;
    using Artity.Services.Performence;
    using Artity.Web.InputModels.Order;
    using Artity.Services.Mapping;

    public class OrderService : IOrderService
    {
        private readonly IRepository<Data.Models.Order> repositoryOrder;
        private readonly IUserService userService;
        private readonly IArtistService artistService;
        private readonly IPerformenceService performenceService;

        public OrderService(
            IRepository<Data.Models.Order> repositoryOrder,
            IUserService userService,
            IArtistService artistService,
            IPerformenceService performenceService
            )
        {
            this.repositoryOrder = repositoryOrder;
            this.userService = userService;
            this.artistService = artistService;
            this.performenceService = performenceService;
        }

        public IEnumerable<TViewModel> AllOrders<TViewModel>(string artistId)
        {
            return
                 this.repositoryOrder.All()
                 .Where(a => a.ArtistId == artistId)
                 .OrderBy(a => a.CreatedOn)
                 .To<TViewModel>();
        }

        public IEnumerable<TViewModel> AllPerformenceOrders<TViewModel>(string artistId)
        {
            return
             this.repositoryOrder.All()
             .Where(a => a.ArtistId == artistId && a.Performence != null)
             .OrderBy(a => a.CreatedOn)
             .To<TViewModel>();
        }

        public IEnumerable<TViewModel> AllPrivateOrders<TViewModel>(string artistId)
        {
            return
             this.repositoryOrder.All()
             .Where(a => a.ArtistId == artistId && a.Performence == null)
             .OrderBy(a => a.CreatedOn)
             .To<TViewModel>();
        }

        public async Task<bool> CreateArtistOrder(ArtistOrderCreateInputModel inputModel)
        {
            var order = AutoMapper.Mapper.Map<Data.Models.Order>(inputModel);

            var user = this.userService.GetApplicationUserByName(inputModel.Username);

            var artist = await this.artistService.GetArtistIdByName(inputModel.ArtistNikname);

            if (user == null || artist == null)
            {
                // TODO: Refactor
                throw new ArgumentNullException("Artist or User is invalid");
            }

            order.User = user;

            order.ArtistId = artist;

            order.Stauts = Data.Models.Enums.OrderStatus.Sent;

            await this.repositoryOrder.AddAsync(order);
            var result = await this.repositoryOrder.SaveChangesAsync();

            return result > 0;
        }

       
        public async Task<bool> CreatePerformenceOrder(PerformenceOrderCreateInputModel inputModel)
        {
            var order = AutoMapper.Mapper.Map<Data.Models.Order>(inputModel);

            var user = this.userService.GetApplicationUserByName(inputModel.Username);

            var artist = await this.artistService.GetArtistIdByName(inputModel.ArtistNikname);

            var performence = this.performenceService.GetPerformenceByName(inputModel.PerformenceName);


            if (user == null || artist == null || performence == null)
            {
                // TODO: Refactor
                throw new ArgumentNullException("Artist or User is invalid");
            }

            order.User = user;

            order.ArtistId = artist;

            order.PerformenceId = performence;

            order.Stauts = Data.Models.Enums.OrderStatus.Sent;

            await this.repositoryOrder.AddAsync(order);
            var result = await this.repositoryOrder.SaveChangesAsync();

            return result > 0;

        }
    }
}
