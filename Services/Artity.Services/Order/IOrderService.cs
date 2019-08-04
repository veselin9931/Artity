namespace Artity.Services.Order
{
    using Artity.Data.Models;

    using Artity.Web.InputModels.Order;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading.Tasks;


    public interface IOrderService
    {
        #region CreateServices
        Task<bool> CreateArtistOrder(ArtistOrderCreateInputModel inputModel);

        Task<bool> CreatePerformenceOrder(PerformenceOrderCreateInputModel inputModel);
        #endregion

        #region GetServices

        IEnumerable<TViewModel> AllOrders<TViewModel>(string artistId);

        IEnumerable<TViewModel> AllPerformenceOrders<TViewModel>(string artistId);

        IEnumerable<TViewModel> AllPrivateOrders<TViewModel>(string artistId);

        IEnumerable<TViewModel> GetAllUserPerformenceOrders<TViewModel>(string userId);

        IEnumerable<TViewModel> GetAllUserArtistOrders<TViewModel>(string userId);
        #endregion

        #region DeleteServices

        Task<bool> DeleteOrderById(string id);
        #endregion

    }
}
