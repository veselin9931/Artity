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
        private readonly IUserService user;
        private readonly IArtistService artistService;

        public OrderService(
            IRepository<Data.Models.Order> repositoryOrder,
            IUserService user,
            IArtistService artistService)
        {
            this.repositoryOrder = repositoryOrder;
            this.user = user;
            this.artistService = artistService;
        }

        public Task<bool> CreateOrder(OrderCreateInputModel inputModel)
        {
            var order = AutoMapper.Mapper.Map<Data.Models.Order>(inputModel);

            

            throw new NotImplementedException();
        }
    }
}
