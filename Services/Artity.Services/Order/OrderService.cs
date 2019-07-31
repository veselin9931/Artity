namespace Artity.Services.Order
{
    using System;

    using System.Threading.Tasks;

    using Artity.Data.Common.Repositories;

    using Artity.Services.Artists;

    using Artity.Web.InputModels.Order;

    public class OrderService : IOrderService
    {
        private readonly IRepository<Data.Models.Order> repositoryOrder;
        private readonly IUserService userService;
        private readonly IArtistService artistService;

        public OrderService(
            IRepository<Data.Models.Order> repositoryOrder,
            IUserService userService,
            IArtistService artistService)
        {
            this.repositoryOrder = repositoryOrder;
            this.userService = userService;
            this.artistService = artistService;
        }

        public async Task<bool> CreateOrder(OrderCreateInputModel inputModel)
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
    }
}
