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
    using Artity.Data.Models.Enums;
    using Artity.Data.Models;

    public class OrderService : IOrderService
    {
        private readonly IRepository<Data.Models.Order> repositoryOrder;
        private readonly IUserService userService;
        private readonly IArtistService artistService;
        private readonly IPerformenceService performenceService;
        private readonly IRepository<Artist> artistRepo;

        public OrderService(
            IRepository<Data.Models.Order> repositoryOrder,
            IUserService userService,
            IArtistService artistService,
            IPerformenceService performenceService,
            IRepository<Artist> artistRepo
            )
        {
            this.repositoryOrder = repositoryOrder;
            this.userService = userService;
            this.artistService = artistService;
            this.performenceService = performenceService;
            this.artistRepo = artistRepo;
        }

        public IEnumerable<TViewModel> AllOrders<TViewModel>(string artistId)
        {
            return
                 this.repositoryOrder.All()
                 .Where(a => a.ArtistId == artistId && a.IsDeleted == false)
                 .OrderBy(a => a.CreatedOn)
                 .To<TViewModel>();
        }

        public IEnumerable<TViewModel> AllOrdersInStatus<TViewModel>(string artistId, OrderStatus status)
        {
            return
                 this.repositoryOrder.All()
                 .Where(a => a.ArtistId == artistId &&
                 a.IsDeleted == false &&
                 a.Status == status)
                 .OrderBy(a => a.CreatedOn)
                 .To<TViewModel>();
        }

        public IEnumerable<TViewModel> AllPerformenceOrders<TViewModel>(string artistId)
        {
            return
             this.repositoryOrder.All()
             .Where(a => a.ArtistId == artistId && a.Performence != null && a.IsDeleted == false)
             .OrderBy(a => a.CreatedOn)
             .To<TViewModel>();
        }

        public IEnumerable<TViewModel> AllPrivateOrders<TViewModel>(string artistId)
        {
            return
             this.repositoryOrder.All()
             .Where(a => a.ArtistId == artistId && a.Performence == null && a.IsDeleted == false)
             .OrderBy(a => a.CreatedOn)
             .To<TViewModel>();
        }

        public IEnumerable<TViewModel> GetAllUserArtistOrders<TViewModel>(string userId)
        {
            return
             this.repositoryOrder.All()
             .Where(a => a.UserId == userId && a.Performence == null && a.IsDeleted == false)
             .OrderBy(a => a.CreatedOn)
             .To<TViewModel>();
        }



        public IEnumerable<TViewModel> GetAllUserPerformenceOrders<TViewModel>(string userId)
        {
            return
             this.repositoryOrder.All()
             .Where(a => a.UserId == userId && a.Performence != null)
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

            order.Status = Data.Models.Enums.OrderStatus.Sent;

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

            order.Status = Data.Models.Enums.OrderStatus.Sent;

            await this.repositoryOrder.AddAsync(order);
            var result = await this.repositoryOrder.SaveChangesAsync();

            return result > 0;

        }

        public async Task<bool> DeleteOrderById(string id)
        {
            var order = this.repositoryOrder
                 .All()
                 .FirstOrDefault(a => a.Id == id);

            if (order == null)
            {
                throw new ArgumentNullException();
            }

            this.repositoryOrder.Delete(order);
            var result = await this.repositoryOrder.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> ApprovedReservation(string orderId)
        {
            var order = this.repositoryOrder
                 .All()
                 .FirstOrDefault(a => a.Id == orderId);

            if (order == null)
            {
                throw new ArgumentNullException();
            }

            order.Status = Data.Models.Enums.OrderStatus.Accepted;

            this.repositoryOrder.Update(order);
            var result = await this.repositoryOrder.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> RefuseReservation(string orderId)
        {
            var order = this.repositoryOrder
                .All()
                .FirstOrDefault(a => a.Id == orderId);

            if (order == null)
            {
                throw new ArgumentNullException();
            }

            order.Status = Data.Models.Enums.OrderStatus.Refused;

            this.repositoryOrder.Update(order);
            var result = await this.repositoryOrder.SaveChangesAsync();

            return result > 0;
        }
    }
}
