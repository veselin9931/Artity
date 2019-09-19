namespace Artity.Services.Data.Order
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Artity.Data.Models.Enums;
    using Artity.Web.InputModels.Order;

    public interface IOrderService
    {

        Task<bool> CreateArtistOrder(ArtistOrderCreateInputModel inputModel);

        Task<bool> CreatePerformenceOrder(PerformenceOrderCreateInputModel inputModel);

        IEnumerable<TViewModel> AllOrders<TViewModel>(string artistId);

        IEnumerable<TViewModel> AllPerformenceOrders<TViewModel>(string artistId);

        IEnumerable<TViewModel> AllPrivateOrders<TViewModel>(string artistId);

        IEnumerable<TViewModel> GetAllUserPerformenceOrders<TViewModel>(string userId);

        IEnumerable<TViewModel> GetAllUserArtistOrders<TViewModel>(string userId);

        IEnumerable<TViewModel> AllOrdersInStatus<TViewModel>(string artistId, OrderStatus status);

        Task<bool> DeleteOrderById(string id);

        Task<bool> ApprovedReservation(string orderId);

        Task<bool> RefuseReservation(string orderId);
    }
}
