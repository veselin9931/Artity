using System;
using System.Threading.Tasks;
using Artity.Data.Models;
using Artity.Web.ViewModels.Order;

namespace Artity.Services.Order
{
    public class OrderService : IOrderService
    {
        public Task<bool> CreateOrder(OrderCreateInputModel inputModel, ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
