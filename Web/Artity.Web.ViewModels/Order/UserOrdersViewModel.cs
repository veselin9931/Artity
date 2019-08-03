using Artity.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Artity.Web.ViewModels.Order
{
    public class UserOrdersViewModel
    {
        public IEnumerable<UserArtistOrderViewModel> UserArtistOrder { get; set; }

        public IEnumerable<UserPerformenceOrderViewModel> UserPerformenceOrder { get; set; }
    }
}
